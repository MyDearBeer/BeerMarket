USE MarketDB
GO

CREATE TABLE TypeItem
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
name VARCHAR(40) NOT NULL UNIQUE,
);

INSERT TypeItem
VALUES
('��������'),
('�������'),
('������� ������'),
('���������')


SELECT * FROM Type


DROP TABLE Type

CREATE TABLE Factory
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
name VARCHAR(50) NOT NULL UNIQUE,
address VARCHAR(200) DEFAULT('������ �� �������'),
img VARCHAR(100) DEFAULT('defaultFactory.png'),
);

INSERT INTO Factory
VALUES
('����� �������� ��������','���. ��. ����������, 10, �. ����, ������','brovarnya.png'),
('��������','���. �����������, 18, 79007, �. ����, ������','lvivske.png'),
('Garage','����������� ����, 137, 03026, �. ���, ������','garage.png'),
('����',DEFAULT,DEFAULT)


SELECT * FROM Factory


DROP TABLE Factory

CREATE TABLE Item
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
factoryID INT REFERENCES Factory(ID) ON DELETE NO ACTION NOT NULL,
typeID INT REFERENCES TypeItem(ID) ON DELETE CASCADE NOT NULL,
name VARCHAR(50) NOT NULL UNIQUE,
rating DECIMAL(4,1),
price INT NOT NULL,
img VARCHAR(100) NULL,
description TEXT
);

INSERT Item
VALUES
(2,1,'�������� 1715',4.5,20,'lviv1715.png','��������� � �� ��������� ��������� ����, ��� ������ ������ ������ �� � �������� 1715 ����. ���� ����� ���������� ������������ ����� ������� ������ ���� ���� �������. ������� ��������� ����� �������� �������� �� ����� ���� ����, �������� ���� �� ������� �����. ������������ ���������� � ������ ���������� �����!'),
(3,1,'Garage Fun ZERO � ������ �����',4.3,28,'garageLime.png','������������� ���� Seth & Riley�s Garage Fun Zero � ������ ����� � �� 0 �������� �� �������� ����. �� ��������� ���� ����� � ������� ������������ ������� �� ��������� ����������.'),
(3,1,'Garage Hard Lemon',4.4,29,'garageLemon.png','S&R Garage Hard Lemon (�����) ��������� ���� ���� � �������� ������ � ����������� ������� ������. �� ������� ���� � ������ ����� � ���� �����.'),
(1,1,'�������',4.3,30,'privatnaBo4ok.png', '�������� �������� ��������� ���������, � �� ����������, � �������� �������� ��� ��������� ��������� ������ ��� ����� ��������, � ����-����������� ����� �����: Hersbrucker, Hallertaur Magnum, Hallertau Tradition �� ��������� ��� �������� ���� �� ����������� ����������.'),
(4,2,'׳��� ��������',5,55,'cheepSpain.png','���� �`�����-����� �������� �������� ���� � �������� ��������. ����� �����������-������ �������, ��� ����� ����� �� ������� ����� ���� � �� �������� ������ ���� ������������ ������ �����.'),
(4,2,'������ �������� �������',5,25,'saltNuts.png','������ - �������� ������� �� ����-����� ���� ����. ³� ������ ��������� � � ������� �� � ������� �������. ϳ���������, ������ ������� ������ ����� ����� ������� ������. �� ���� � �������� ������� ������ ���������� ����� ��������, ������� ���`���, �����, ����, �������� ������� ������� �������, ����� �� �������. �� ����, �������� ������ �� ����� ��������, ��� � ��������� �� �����.')

SELECT * FROM Item



DROP TABLE Item

CREATE TABLE ItemInfo
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
itemID INT REFERENCES Item(ID) ON DELETE CASCADE,
title VARCHAR(50) DEFAULT ('�������������� ������'),
value VARCHAR(20) DEFAULT ('³������ ���� ������'),
);


INSERT ItemInfo
VALUES
(1,'��� ��������:','����'),
(1,'���� ������:','4,8'),
(2,'��� ��������:','����'),
(2,'���� ������:','0,5'),
(3,'��� ��������:','����'),
(3,'���� ������:','4,5'),
(4,'��� ��������:','����'),
(4,'���� ������:','5,1'),
(5,'��� ��������:','�`���'),
(6,'��� ��������:','������ �������')

SELECT * FROM ItemInfo

DROP TABLE ItemInfo


alcohol DECIMAL (4,1) DEFAULT (0.0) NULL,