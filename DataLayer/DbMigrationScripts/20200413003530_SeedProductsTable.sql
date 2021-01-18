INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) Values (1,'A', 1.25, 3, 3.00 )

GO

INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) Values (2,'B', 4.25, 1, 4.25 )

GO

INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) Values (3,'C', 1.00, 6, 5.00 )

GO

INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) Values (4,'D', 0.75, 1, 0.75 )

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200413003530_SeedProductsTable', N'3.1.3');

GO

