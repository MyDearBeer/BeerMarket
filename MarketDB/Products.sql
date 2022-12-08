USE MarketDB
GO

CREATE TABLE TypeItem
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
name VARCHAR(40) NOT NULL UNIQUE,
);

INSERT TypeItem
VALUES
('Алкоголь'),
('Закуска'),
('Тютюнові вироби'),
('Аксесуари')


SELECT * FROM Type


DROP TABLE Type

CREATE TABLE Factory
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
name VARCHAR(50) NOT NULL UNIQUE,
address VARCHAR(200) DEFAULT('Адреса не вказана'),
img VARCHAR(100) DEFAULT('defaultFactory.png'),
);

INSERT INTO Factory
VALUES
('Перша приватна броварня','вул. Дж. Вашингтона, 10, м. Львів, Україна','brovarnya.png'),
('Львівське','вул. Клепарівська, 18, 79007, м. Львів, Україна','lvivske.png'),
('Garage','Пирогівський шлях, 137, 03026, м. Київ, Україна','garage.png'),
('Інше',DEFAULT,DEFAULT)


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
(2,1,'Львівське 1715',4.5,20,'lviv1715.png','«Львівське» — це найдавніше українське пиво, яке почали варити монахи ще у далекому 1715 році. Смак цього славетного бурштинового напою пройшов довгий шлях крізь сторіччя. Сьогодні «Львівське» стало частиною культури та історії нашої землі, символом епох та гордістю країни. Насолоджуйся «Львівським» — першим українським пивом!'),
(3,1,'Garage Fun ZERO зі смаком Лайму',4.3,28,'garageLime.png','Безалкогольне пиво Seth & Riley’s Garage Fun Zero зі смаком Лайму – це 0 алкоголю та максимум фану. Має освіжаючий смак лайму з приємним солодкуватим відтінком та фруктовим післясмаком.'),
(3,1,'Garage Hard Lemon',4.4,29,'garageLemon.png','S&R Garage Hard Lemon (Лимон) освіжаючий хард дрінк з лимонним смаком і характерною терпкою ноткою. Має приємний смак і відмінно освіжає в літню спеку.'),
(1,1,'Бочкове',4.3,30,'privatnaBo4ok.png', 'Вариться реальним приватним пивоваром, а не корпораціє, з класичної сировини без додавання мальтозної патоки або інших замінників, з гірко-ароматичних сортів хмелю: Hersbrucker, Hallertaur Magnum, Hallertau Tradition що відрізняють цей фірмовий сорт від стандартних євролагерів.'),
(4,2,'Чіпси Іспанські',5,55,'cheepSpain.png','Тонкі в`ялено-сушені шматочки курячого філе з гострими спеціями. Пряна солодкувато-солона закуска, яка добре підійде до більшості сортів пива і не завадить повною мірою насолодитися смаком напою.'),
(4,2,'Арахіс смажений солений',5,25,'saltNuts.png','Арахіс - ідеальна закуска до будь-якого виду пива. Він відмінно поєднується і зі світлими та з темними сортами. Підсмажений, помірно солоний арахіс легко вгамує почуття голоду. До того ж вживання арахісу сприяє відновленню клітин організму, покращує пам`ять, увагу, слух, нормалізує функцію нервової системи, серця та печінки. До речі, смажений арахіс не тільки смачніший, але й кориснішій за сирий.')

SELECT * FROM Item



DROP TABLE Item

CREATE TABLE ItemInfo
(
ID INT PRIMARY KEY IDENTITY NOT NULL,
itemID INT REFERENCES Item(ID) ON DELETE CASCADE,
title VARCHAR(50) DEFAULT ('Характеристики невідомі'),
value VARCHAR(20) DEFAULT ('Відсутній опис товару'),
);


INSERT ItemInfo
VALUES
(1,'Тип продукту:','Пиво'),
(1,'Вміст спирту:','4,8'),
(2,'Тип продукту:','Пиво'),
(2,'Вміст спирту:','0,5'),
(3,'Тип продукту:','Пиво'),
(3,'Вміст спирту:','4,5'),
(4,'Тип продукту:','Пиво'),
(4,'Вміст спирту:','5,1'),
(5,'Тип продукту:','М`ясо'),
(6,'Тип продукту:','Солона закуска')

SELECT * FROM ItemInfo

DROP TABLE ItemInfo


alcohol DECIMAL (4,1) DEFAULT (0.0) NULL,