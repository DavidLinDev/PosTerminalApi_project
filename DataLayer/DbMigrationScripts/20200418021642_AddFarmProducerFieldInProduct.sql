ALTER TABLE [Products] ADD [FarmProducer] nvarchar(50) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200418021642_AddFarmProducerFieldInProduct', N'3.1.3');

GO

