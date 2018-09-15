CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(30) NULL, 
    [PhoneNumber] NVARCHAR(15) NULL, 
    [RoomNumber] NVARCHAR(10) NULL, 
    [PayMonths] INT NULL, 
    [PaymentMonth] DATE NULL

)
