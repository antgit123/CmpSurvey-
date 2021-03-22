if not exists (select * from sysobjects where name='Survey')
CREATE TABLE Survey
(
     id int primary key identity,
     name varchar(50) NOT NULL
)

if not exists (select * from sysobjects where name='Questions')
CREATE TABLE Questions
(
     id int primary key identity,
	 createdBy varchar(40) NOT NULL,
	 createdDataTime datetime NOT NULL,
	 title varchar(150) NOT NULL,
	 subtitle varchar(150),
	 questionType int,
	 surveyId int
	 FOREIGN KEY(surveyId) REFERENCES Survey(id) ON DELETE CASCADE
)

if not exists (select * from sysobjects where name='Options')
CREATE TABLE Options(
	id int primary key identity,
	optionId char(1) NOT NULL,
	optionText varchar(100) NOT NULL,
	questionId int,
	FOREIGN KEY(questionId) REFERENCES Questions(id) ON DELETE CASCADE
)

DELETE FROM dbo.Survey
DELETE FROM dbo.Questions
Delete From dbo.Options

INSERT INTO Survey Values('Survey 1')
INSERT INTO Survey Values('Survey 2')
INSERT INTO Survey Values('Survey 3')
INSERT INTO Questions Values('Elisabeth Winters','20200518 10:34:09 AM','How many astronauts landed on the moon?',' ',3,1)
INSERT INTO Questions Values('Maryam Ryan','20200523 11:34:09 AM','How many devs does it take to change a lightbulb?','This is not a trick question ',3,1)
INSERT INTO Questions Values('Andre Grid','20200527 08:14:09 AM','What is the temperature today?','We need to send this to the Bureau of Meteorology.',3,2)
INSERT INTO Questions Values('John','20200527 07:14:09 AM','What is the capital of Australia?','GK.',2,2)
INSERT INTO Questions Values('Jack','20200527 11:14:09 AM','How many continents in the world?','World',1,3)
INSERT INTO Questions Values('Rick','20200721 09:14:09 AM','What is the sum of 5 and 4?','Maths',1,3)
INSERT INTO Options Values('1','1',1)
INSERT INTO Options Values('2','3',1)
INSERT INTO Options Values('3','18',1)
INSERT INTO Options Values('1','One',2)
INSERT INTO Options Values('2','Two',2)
INSERT INTO Options Values('3','Three thousand three hundred eighty-seven',2)
INSERT INTO Options Values('1','10 degree',3)
INSERT INTO Options Values('2','20 degree',3)
INSERT INTO Options Values('3','30 degree',3)
INSERT INTO Options Values('1','Melbourne',4)
INSERT INTO Options Values('2','Sydney',4)
INSERT INTO Options Values('3','Canberra',4)
INSERT INTO Options Values('1','4',5)
INSERT INTO Options Values('2','6',5)
INSERT INTO Options Values('3','7',5)
INSERT INTO Options Values('1','10',6)
INSERT INTO Options Values('2','9',6)
INSERT INTO Options Values('3','8',6)