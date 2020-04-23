CREATE TABLE [dbo].[Dish]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(50) NOT NULL, 
    [price] DECIMAL NOT NULL, 
    
)
