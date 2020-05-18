CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [cariKod] NVARCHAR(50) NULL, 
    [cariIsim] NVARCHAR(50) NULL, 
    [adres] NVARCHAR(250) NULL, 
    [ilceKod] INT NULL, 
    [ilceAdi] NVARCHAR(30) NULL, 
    [ilKod] INT NULL, 
    [ilAdi] NVARCHAR(30) NULL, 
    [ulkeKodu] INT NULL, 
    [ulkeAdi] NVARCHAR(30) NULL, 
    [telefonKod] INT NULL, 
    [telefonNumara] INT NULL, 
    [faxKod] INT NULL, 
    [faxNumara] INT NULL, 
    [vergiDairesiNo] NVARCHAR(50) NULL, 
    [tcKimlikNumarası] BIGINT NULL, 
    [postakodu] INT NULL, 
    [tip] NCHAR(10) NULL, 
    [emailAdres] NVARCHAR(250) NULL, 
    [webAdres] NVARCHAR(250) NULL
)
