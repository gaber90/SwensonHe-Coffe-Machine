USE [SwensonHeStore]
GO
SET IDENTITY_INSERT [dbo].[Flavor] ON 
GO
INSERT [dbo].[Flavor] ([ID], [Name]) VALUES (1, N'Vanilia')
GO
INSERT [dbo].[Flavor] ([ID], [Name]) VALUES (2, N'Caramel')
GO
INSERT [dbo].[Flavor] ([ID], [Name]) VALUES (3, N'PSL')
GO
INSERT [dbo].[Flavor] ([ID], [Name]) VALUES (4, N'Mocha')
GO
INSERT [dbo].[Flavor] ([ID], [Name]) VALUES (5, N'Hazelnut')
GO
SET IDENTITY_INSERT [dbo].[Flavor] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemSize] ON 
GO
INSERT [dbo].[ItemSize] ([ID], [Name]) VALUES (1, N'Small')
GO
INSERT [dbo].[ItemSize] ([ID], [Name]) VALUES (2, N'Medium')
GO
INSERT [dbo].[ItemSize] ([ID], [Name]) VALUES (3, N'Large')
GO
SET IDENTITY_INSERT [dbo].[ItemSize] OFF
GO
SET IDENTITY_INSERT [dbo].[ModelType] ON 
GO
INSERT [dbo].[ModelType] ([ID], [Name]) VALUES (1, N'Base Model')
GO
INSERT [dbo].[ModelType] ([ID], [Name]) VALUES (2, N'Premium Model')
GO
INSERT [dbo].[ModelType] ([ID], [Name]) VALUES (3, N'Deluxe Model')
GO
SET IDENTITY_INSERT [dbo].[ModelType] OFF
GO
SET IDENTITY_INSERT [dbo].[Pack] ON 
GO
INSERT [dbo].[Pack] ([ID], [Dozen], [Qty]) VALUES (1, 1, 12)
GO
INSERT [dbo].[Pack] ([ID], [Dozen], [Qty]) VALUES (2, 3, 36)
GO
INSERT [dbo].[Pack] ([ID], [Dozen], [Qty]) VALUES (3, 5, 60)
GO
INSERT [dbo].[Pack] ([ID], [Dozen], [Qty]) VALUES (4, 7, 84)
GO
SET IDENTITY_INSERT [dbo].[Pack] OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 
GO
INSERT [dbo].[Item] ([ID], [Name]) VALUES (1, N'Cofee')
GO
INSERT [dbo].[Item] ([ID], [Name]) VALUES (2, N'Espresso')
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 
GO
INSERT [dbo].[ProductType] ([ID], [Name]) VALUES (1, N'Machines')
GO
INSERT [dbo].[ProductType] ([ID], [Name]) VALUES (2, N'Pods')
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ID], [ProductTypeID], [ItemID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Product] ([ID], [ProductTypeID], [ItemID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Product] ([ID], [ProductTypeID], [ItemID]) VALUES (3, 2, 1)
GO
INSERT [dbo].[Product] ([ID], [ProductTypeID], [ItemID]) VALUES (4, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemSKU] ON 
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (1, N'CM001 ', 10, 0, 1, NULL, NULL, 1, 1)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (2, N'CM002 ', 10, 0, 1, NULL, NULL, 2, 1)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (3, N'CM003 ', 10, 1, 1, NULL, NULL, 3, 1)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (4, N'CM101 ', 10, 0, 1, NULL, NULL, 1, 3)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (5, N'CM102 ', 10, 1, 1, NULL, NULL, 2, 3)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (6, N'CM103 ', 10, 1, 1, NULL, NULL, 3, 3)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (7, N'EM001 ', 10, 0, 2, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (8, N'CP001 ', 10, 0, 3, 1, 1, NULL, 1)
GO
INSERT [dbo].[ItemSKU] ([ID], [Code], [Qty], [HasWaterCompatibality], [ProductID], [PackID], [FlavorID], [ModelTypeID], [ItemSizeID]) VALUES (9, N'CP123 ', 10, 0, 3, 3, 3, 3, NULL)
GO
SET IDENTITY_INSERT [dbo].[ItemSKU] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210129160641_AddStoreIntialMigration', N'3.1.5')
GO
