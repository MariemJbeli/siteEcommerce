USE [MovieDB]
GO

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName])
	VALUES ('0470beeb-dd84-470d-b7a1-27f7ca51093f','Admin','ADMIN')
GO


UPDATE [dbo].[AspNetUserRoles]
   SET [RoleId] = '0470beeb-dd84-470d-b7a1-27f7ca51093f'
 WHERE UserId = (SELECT [Id] FROM [dbo].[AspNetUsers] where Email='maryemjbeli@gmail.com')
GO

UPDATE [dbo].[AspNetUserRoles]
   SET [RoleId] = '0470beeb-dd84-470d-b7a1-27f7ca51093f'
 WHERE UserId = (SELECT [Id] FROM [dbo].[AspNetUsers] where Email='test@gmail.com')
GO

