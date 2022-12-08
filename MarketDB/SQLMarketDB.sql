CREATE DATABASE MarketDB
ON
(
NAME ='MarketDB',
FILENAME ='D:\DB\Market\MarketDB.mdf',
SIZE = 10 MB,
MAXSIZE = 100 MB,
FILEGROWTH = 10 MB
)
LOG ON
(
NAME ='LogMarketDB',
FILENAME ='D:\DB\Market\MarketDB.ldf',
SIZE = 5 MB,
MAXSIZE = 50 MB,
FILEGROWTH = 5 MB
)
collate Cyrillic_General_CI_AS


USE master
GO
DROP DATABASE MarketDB