ALTER TABLE [Orders] ADD [CustomerName] nvarchar(200) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210113033208_AddNewField_CustomerName_to_OrderTable', N'3.1.3');

GO

