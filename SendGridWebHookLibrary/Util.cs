using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SendGridWebHookLibrary
{
    public class Util
    {
        public static DateTime TimeStampToDateTime(double timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime();
            return dateTime;
        }

        //This method mostly taken from https://gist.github.com/jferguson/1681480
        //Many thanks to Jarod Ferguson (@jarodf)
        public static void BulkInsert<T>(string connection, string tableName, IList<T> list, string[] propsToSkip)
        {
            using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))
                    //Dirty hack to make sure we only have system data types 
                    //i.e. filter out the relationships/collections
                                            .Cast<PropertyDescriptor>()
                                            .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System")
                                                //skip properties to skip                    
                                                                    && !propsToSkip.Contains(propertyInfo.Name)
                                                //skip properties marked with NotMapped attributes
                                                                    && IsMapped(propertyInfo))
                                            .ToArray();
                int propertyCount = 0;
                foreach (var propertyDescriptor in props)
                {
                    PropertyInfo propertyInfo = propertyDescriptor.ComponentType.GetProperty(propertyDescriptor.Name);
                    //Get underlying table's column name instead of property name
                    bulkCopy.ColumnMappings.Add(propertyDescriptor.Name, GetTableColumnName(propertyInfo));
                    table.Columns.Add(propertyDescriptor.Name, Nullable.GetUnderlyingType(propertyDescriptor.PropertyType) ?? propertyDescriptor.PropertyType);
                    propertyCount++;
                }

                var values = new object[propertyCount];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }

                    table.Rows.Add(values);
                }
                bulkCopy.BatchSize = 5000;
                bulkCopy.BulkCopyTimeout = 12000;
                bulkCopy.WriteToServer(table);
            }
        }

        public static bool IsMapped(PropertyDescriptor propertyDescriptor)
        {
            var property = propertyDescriptor.ComponentType.GetProperty(propertyDescriptor.Name);
            var type = typeof(NotMappedAttribute);
            var prop = property.GetCustomAttributes(type, false);
            return prop.Count() == 0;
        }

        public static string GetTableColumnName(PropertyInfo property)
        {
            var type = typeof(ColumnAttribute);
            var prop = property.GetCustomAttributes(type, false);

            if (prop.Count() > 0)
                return ((ColumnAttribute)prop.First()).Name;
            return property.Name;
        }
    }
}
