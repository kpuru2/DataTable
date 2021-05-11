CREATE TABLE Accounts
(
Number VARCHAR(100) NOT NULL,
Type VARCHAR(100) NOT NULL,
VendorNumber BIGINT NOT NULL,
CONSTRAINT PK_Accounts_Id PRIMARY KEY (Number),
CONSTRAINT FK_Accounts_VendorNumber FOREIGN KEY (VendorNumber) REFERENCES Vendors (Number)
)
GO