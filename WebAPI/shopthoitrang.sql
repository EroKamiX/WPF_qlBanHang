-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               Microsoft SQL Server 2014 - 12.0.4100.1
-- Server OS:                    Windows NT 6.3 <X64> (Build 19044: )
-- HeidiSQL Version:             12.2.0.6576
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for ShopThoiTrang
CREATE DATABASE IF NOT EXISTS "ShopThoiTrang";
USE "ShopThoiTrang";

-- Dumping structure for table ShopThoiTrang.Categories
CREATE TABLE IF NOT EXISTS "Categories" (
	"Id" INT NOT NULL,
	"Name" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Slug" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"ParentId" INT NULL DEFAULT NULL,
	"Orders" INT NULL DEFAULT NULL,
	"Metakey" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metadesc" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Categories: -1 rows
/*!40000 ALTER TABLE "Categories" DISABLE KEYS */;
INSERT INTO "Categories" ("Id", "Name", "Slug", "ParentId", "Orders", "Metakey", "Metadesc", "Created_By", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(1, 'Thời trang nam', 'thoi-trang-nam', 0, NULL, 'Thời trang nam', 'Thời trang nam', 1, '2022-12-11 23:13:37.9500000', 1, '2023-04-07 22:43:31.7672120', 1),
	(14, 'Thời Trang Nữ', 'thoi-trang-nu', 0, NULL, 'Thời Trang Nữ', 'Thời Trang Nữ', NULL, '2023-04-07 22:40:40.3373549', NULL, '2023-04-07 22:40:40.3373824', 0),
	(15, 'Giày Nam Nữ Đủ cả', 'giay-nam', 0, NULL, 'Giày Nam', 'Giày Nam', NULL, '2023-04-07 22:48:40.5645437', NULL, '2023-04-08 09:36:32.5121562', 0);
/*!40000 ALTER TABLE "Categories" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Contacts
CREATE TABLE IF NOT EXISTS "Contacts" (
	"Id" INT NOT NULL,
	"FullName" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Email" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Phone" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Title" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Content" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Contacts: -1 rows
/*!40000 ALTER TABLE "Contacts" DISABLE KEYS */;
/*!40000 ALTER TABLE "Contacts" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Menus
CREATE TABLE IF NOT EXISTS "Menus" (
	"Id" INT NOT NULL,
	"Name" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Link" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Type" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Table" INT NOT NULL,
	"ParentId" INT NOT NULL,
	"Orders" INT NOT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Menus: -1 rows
/*!40000 ALTER TABLE "Menus" DISABLE KEYS */;
/*!40000 ALTER TABLE "Menus" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.OrderDetails
CREATE TABLE IF NOT EXISTS "OrderDetails" (
	"Id" INT NOT NULL,
	"OrderId" INT NOT NULL,
	"ProductId" INT NOT NULL,
	"Price" FLOAT NOT NULL,
	"Qty" INT NOT NULL,
	"Amount" FLOAT NOT NULL,
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_OrderDetails_Orders_OrderId" ("OrderId"),
	FOREIGN KEY INDEX "FK_OrderDetails_Products_ProductId" ("ProductId"),
	CONSTRAINT "FK_OrderDetails_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE,
	CONSTRAINT "FK_OrderDetails_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Dumping data for table ShopThoiTrang.OrderDetails: -1 rows
/*!40000 ALTER TABLE "OrderDetails" DISABLE KEYS */;
INSERT INTO "OrderDetails" ("Id", "OrderId", "ProductId", "Price", "Qty", "Amount") VALUES
	(2, 1, 2, 53451234, 34, 4);
/*!40000 ALTER TABLE "OrderDetails" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Orders
CREATE TABLE IF NOT EXISTS "Orders" (
	"Id" INT NOT NULL,
	"UserId" INT NOT NULL,
	"Name" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Phone" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Email" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Note" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_Orders_Users_UserId" ("UserId"),
	CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Dumping data for table ShopThoiTrang.Orders: -1 rows
/*!40000 ALTER TABLE "Orders" DISABLE KEYS */;
INSERT INTO "Orders" ("Id", "UserId", "Name", "Phone", "Email", "Note", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(1, 1, 'Quan', '0326528238', NULL, NULL, NULL, 1, NULL, 1);
/*!40000 ALTER TABLE "Orders" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Posts
CREATE TABLE IF NOT EXISTS "Posts" (
	"Id" INT NOT NULL,
	"TopicId" INT NOT NULL,
	"Title" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Slug" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Detail" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metakey" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metadesc" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Img" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_Posts_Topics_TopicId" ("TopicId"),
	CONSTRAINT "FK_Posts_Topics_TopicId" FOREIGN KEY ("TopicId") REFERENCES "Topics" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Dumping data for table ShopThoiTrang.Posts: -1 rows
/*!40000 ALTER TABLE "Posts" DISABLE KEYS */;
INSERT INTO "Posts" ("Id", "TopicId", "Title", "Slug", "Detail", "Metakey", "Metadesc", "Img", "Created_By", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(1, 5, 'Ve dep', 've-dep', 've dep linh tinh', 've dep linh tinh', 've dep linh tinh', NULL, 1, '2023-04-08 15:57:42.0000000', 1, '2023-04-08 15:57:44.0000000', 1);
/*!40000 ALTER TABLE "Posts" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Products
CREATE TABLE IF NOT EXISTS "Products" (
	"Id" INT NOT NULL,
	"CategoryId" INT NOT NULL,
	"Name" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Slug" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Detail" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metakey" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metadesc" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Img" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Number" INT NOT NULL,
	"Price" FLOAT NOT NULL,
	"Pricesale" FLOAT NOT NULL,
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_Products_Categories_CategoryId" ("CategoryId"),
	CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Dumping data for table ShopThoiTrang.Products: -1 rows
/*!40000 ALTER TABLE "Products" DISABLE KEYS */;
INSERT INTO "Products" ("Id", "CategoryId", "Name", "Slug", "Detail", "Metakey", "Metadesc", "Img", "Number", "Price", "Pricesale", "Created_By", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(1, 1, 'Áo khoác kaki hai lớp mangto', 'ao-khoac-kaki-hai-lop-mangto', 'Áo khoác kaki hai lớp mangto', 'Áo khoác kaki hai lớp mangto', 'Áo khoác kaki hai lớp mangto', 'ao-khoac-kaki-hai-lop-mangto.jpg', 123432, 450000, 400000, 1, '2022-12-11 23:18:30.9470000', 1, '2022-12-11 23:18:30.9470000', 1),
	(2, 1, 'Áo thun nam giarasv', 'ao-thun-nam-giarasv', 'Áo thun nam giarasv', 'Áo thun nam giarasv', 'Áo thun nam giarasv', 'ao-thun-nam-giarasv.jpg', 34234, 350000, 275000, 1, '2022-12-11 23:19:22.1200000', 1, '2022-12-11 23:19:22.1200000', 1);
/*!40000 ALTER TABLE "Products" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Sliders
CREATE TABLE IF NOT EXISTS "Sliders" (
	"Id" INT NOT NULL,
	"Name" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Link" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Img" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Orders" INT NOT NULL,
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Sliders: -1 rows
/*!40000 ALTER TABLE "Sliders" DISABLE KEYS */;
/*!40000 ALTER TABLE "Sliders" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Topics
CREATE TABLE IF NOT EXISTS "Topics" (
	"Id" INT NOT NULL,
	"Name" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Slug" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"ParentId" INT NOT NULL,
	"Orders" INT NOT NULL,
	"Metakey" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Metadesc" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NOT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Topics: -1 rows
/*!40000 ALTER TABLE "Topics" DISABLE KEYS */;
INSERT INTO "Topics" ("Id", "Name", "Slug", "ParentId", "Orders", "Metakey", "Metadesc", "Created_By", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(5, 'thoi trang', 'thoi-trang', 0, 1, 'thoi-trang', 'thoi-trang', 1, '2023-04-08 15:56:57.0000000', 1, '2023-04-08 15:56:58.0000000', 1);
/*!40000 ALTER TABLE "Topics" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.Users
CREATE TABLE IF NOT EXISTS "Users" (
	"Id" INT NOT NULL,
	"FullName" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Email" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Phone" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Address" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Username" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Password" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"rePassword" NVARCHAR(max) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"oldPassword" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Img" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Roles" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Created_By" INT NULL DEFAULT NULL,
	"Created_At" DATETIME2(7) NULL DEFAULT NULL,
	"Updated_By" INT NULL DEFAULT NULL,
	"Updated_At" DATETIME2(7) NULL DEFAULT NULL,
	"Status" INT NULL DEFAULT NULL,
	PRIMARY KEY ("Id")
);

-- Dumping data for table ShopThoiTrang.Users: -1 rows
/*!40000 ALTER TABLE "Users" DISABLE KEYS */;
INSERT INTO "Users" ("Id", "FullName", "Email", "Phone", "Address", "Username", "Password", "rePassword", "oldPassword", "Img", "Roles", "Created_By", "Created_At", "Updated_By", "Updated_At", "Status") VALUES
	(1, 'Trần Nhật Quang', 'trannhatquang107@gmail.com', '0377092001', NULL, 'admin', 'JdVa0oOqQAr0ZMdtcTwHrQ==', 'JdVa0oOqQAr0ZMdtcTwHrQ==', 'JdVa0oOqQAr0ZMdtcTwHrQ==', 'user-default.jpg', 'Admin', 0, '2022-12-11 23:12:21.7970000', 0, '2022-12-11 23:12:21.7970000', 1);
/*!40000 ALTER TABLE "Users" ENABLE KEYS */;

-- Dumping structure for table ShopThoiTrang.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId" NVARCHAR(150) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"ProductVersion" NVARCHAR(32) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	PRIMARY KEY ("MigrationId")
);

-- Dumping data for table ShopThoiTrang.__EFMigrationsHistory: -1 rows
/*!40000 ALTER TABLE "__EFMigrationsHistory" DISABLE KEYS */;
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
	('20230225033903_InitialCreate', '3.1.32');
/*!40000 ALTER TABLE "__EFMigrationsHistory" ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
