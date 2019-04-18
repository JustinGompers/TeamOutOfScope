-- *************************************************************************************************
-- This script creates all of the database objects (tables, constraints, etc) for the database
-- *************************************************************************************************

USE master;
GO
DROP DATABASE IF EXISTS FlashCardDB;
GO
CREATE DATABASE FlashCardDB;
GO
Use FlashCardDB;
GO

Begin Transaction

CREATE TABLE User_info (
	Person_id integer identity (1,1) NOT NULL,
	Username varchar(200) NOT NULL,
	FirstName varchar(100) NOT NULL,
	LastName varchar(200) NOT NULL,
	Password varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	CONSTRAINT pk_User_info_User_id PRIMARY KEY (Person_id)
);

CREATE TABLE Card (
	Card_id integer identity (1,1) NOT NULL,
	Question varchar(300) NOT NULL,
	Image varchar (300),
	Answer varchar (1000) NOT NULL,
	CONSTRAINT pk_Card_Card_id PRIMARY KEY (Card_id)
);

CREATE TABLE Category (
	Category_id integer identity (1,1) NOT NULL,
	Name varchar(100)
	CONSTRAINT pk_Category_Category_id PRIMARY KEY (Category_id)
);

CREATE TABLE Deck (
	Deck_id integer identity (1,1) NOT NULL,
	Name varchar(100) NOT NULL,
	Category_id integer NOT NULL,
	Share_Deck BIT NOT NULL
	CONSTRAINT pk_Deck_Deck_id PRIMARY KEY (Deck_id),
	CONSTRAINT fk_CategoryDeck_id FOREIGN KEY (Category_id) REFERENCES Category(Category_id) 
);

CREATE TABLE Tags (
	tags_id integer identity (1,1) NOT NULL,
	Name varchar(100) NOT NULL
	CONSTRAINT pk_Tags_tags_id PRIMARY KEY (tags_id)
);


CREATE TABLE Deck_Cards (
	Deck_id integer NOT NULL,
	Card_id integer NOT NULL
	CONSTRAINT fk_Deck_id FOREIGN KEY (Deck_id) REFERENCES Deck(Deck_id),
	CONSTRAINT fk_Card_id FOREIGN KEY (Card_id) REFERENCES Card(Card_id)
);

CREATE TABLE User_Decks (
	Person_id integer NOT NULL,
	Deck_id integer NOT NULL
	CONSTRAINT fk_UserDeck_id FOREIGN KEY (Person_id) REFERENCES User_info(Person_id),
	CONSTRAINT fk_DeckUser_id FOREIGN KEY (Deck_id) REFERENCES Deck(Deck_id)
);

CREATE TABLE Card_Tags (
	Card_id integer NOT NULL,
	Tag_id integer NOT NULL
	CONSTRAINT fk_CardTag_id FOREIGN KEY (Card_id) REFERENCES Card(Card_id),
	CONSTRAINT fk_TagCard_id FOREIGN KEY (Tag_id) REFERENCES Tags(tags_id)
);

Commit Transaction

INSERT INTO Category (Name) VALUES ('Math'),('English'),('Science'),('Geography'),('Social Studies'),('Cooking'),('Technology'),('Other')