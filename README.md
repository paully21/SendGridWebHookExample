SendGridWebHookExample
======================

This example demonstrates how to accept SendGrid Webhook events using ASP.NET WebAPI. 

There is a SQL script (CreateDataTable.sql) in the SendGridWebHookLibrary project that can be used to set up the required database table in your database.

There is also a sample (.mdf) database included in the Website/App_Data data directory.


Getting started
---------------

The example is meant to be self contained.  It can be tested using Fiddler (a fiddler script is included in the Website directory).

Once the solution is published to an Internet-accessible Web server, you can use SendGrid's Event Notification integration test. This is located under the Apps -> Event Notification -> Settings link in the logged-in user area of [sendgrid.com](http://sendgrid.com).


Viewing the results
-------------------

The example's home page (index) contains a KendoUI grid.  This grid will (using a live connection to a SignalR hub) update as new events are posted. The default sort of the grid is EventDate descending, so the newest events should always be on the first page of results.


More information
----------------

I plan to do a detailed [blog post](http://www.allpaul.com) to outline more details. 
