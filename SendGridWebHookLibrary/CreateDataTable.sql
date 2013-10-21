DROP TABLE [dbo].[tbl_SendGridEvents]
GO

CREATE TABLE [dbo].[tbl_SendGridEvents](
	[SendGridEventID] [int] IDENTITY(1,1) NOT NULL,
	[Event] [nvarchar](200) NULL,
	[EmailAddress] [nvarchar](300) NULL,
	[Category] [nvarchar](200) NULL,
	[Response] [nvarchar](2000) NULL,
	[Attempt] [nvarchar](200) NULL,
	[EventDate] [datetime] NULL,
	[Url] [nvarchar](200) NULL,
	[Status] [nvarchar](200) NULL,
	[Reason] [nvarchar](2000) NULL,
	[Type] [nvarchar](200) NULL,
	CONSTRAINT [PK_tbl_SendGridEvents] PRIMARY KEY CLUSTERED 
	(
		[SendGridEventID] ASC
	)
)