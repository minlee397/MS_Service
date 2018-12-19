CREATE DATABASE Quan_Ly_Dien_Thoai
GO
USE Quan_Ly_Dien_Thoai

/*Tao cac table*/
GO
CREATE TABLE PRODUCT(
	ProductID		int IDENTITY,
	NameProduct		nvarchar(500),
	Detail			nvarchar(1000),
	Price			float,
	Quantity		int,
	ImageProduct	nvarchar(500),
	Is_Visible		int,
	Is_Avtive		int
	PRIMARY KEY (ProductID)
)

GO
CREATE TABLE PRODUCT_CATEGORY(
	ID_PC			int IDENTITY,
	ProductID		int,
	CategoryID		int,
	PRIMARY KEY(ID_PC)
)

GO
CREATE TABLE CATEGORY(
	CategoryID		int IDENTITY,
	CategoryName	nvarchar(500),
	Quantity		int,
	Is_active		int,
	Archive			int
	PRIMARY KEY(CategoryID)
)

GO
CREATE TABLE ACCOUNT(
	AccountID		int IDENTITY,
	AccountName		nvarchar(500),
	Acc_Password	varchar(100),
	PhoneNumber		varchar(10),
	Acc_Address		nvarchar(500),
	Email			varchar(100),
	Acc_Type		varchar(6)	
	PRIMARY KEY(AccountID)
)

GO
CREATE TABLE RECEIPT_NOTE (
	Receipt_ID		int IDENTITY,
	AccountID		int,
	Amount			float,
	State_Receipt	int,
	Success_At		datetime,
	Is_Active		int,
	Archive			int
	PRIMARY KEY(Receipt_ID)	
)

GO
CREATE TABLE DETAIL_RECEIPT (
	ID				int IDENTITY,
	Receipt_ID		int,
	Product_ID		int,
	Quantity		int,
	State_Product	int
	PRIMARY KEY(ID)			
)

/*Tao khoa ngoai*/
GO
ALTER TABLE PRODUCT_CATEGORY 
ADD CONSTRAINT FK_PRODUCT_CATEGORY_PRODUCT
FOREIGN KEY (ProductID)
REFERENCES PRODUCT(ProductID)

GO
ALTER TABLE PRODUCT_CATEGORY
ADD CONSTRAINT FK_PRODUCT_CATEGORY_CATEGORY
FOREIGN KEY (CategoryID)
REFERENCES CATEGORY(CategoryID)

GO
ALTER TABLE RECEIPT_NOTE
ADD CONSTRAINT FK_RECEIPT_NOTE_ACCOUNT
FOREIGN KEY(AccountID)
REFERENCES ACCOUNT(AccountID)

GO
ALTER TABLE DETAIL_RECEIPT
ADD CONSTRAINT FK_DETAIL_RECEIPT
FOREIGN KEY(Receipt_ID)
REFERENCES RECEIPT_NOTE(Receipt_ID)

SELECT * FROM Quan_Ly_Dien_Thoai.INFORMATION_SCHEMA.TABLES

SELECT * FROM Products