CREATE TABLE Payments
(
Id BIGINT NOT NULL,
TaxYear INT NOT NULL,
AccountNumber VARCHAR(100) NOT NULL,
Status VARCHAR(100) NOT NULL,
Amount DECIMAL(10,2),
PaidDate DATETIME,
CONSTRAINT PK_Payments_Id PRIMARY KEY (Id),
CONSTRAINT FK_Payments_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES Accounts (Number)
)
GO