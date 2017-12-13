#CREATE DATABASE CS3750P04

USE CS3750P04;


CREATE TABLE Project(
	ProjectId		INT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	ProjectName		VARCHAR(25)	NOT NULL,
	Active			BIT		NOT NULL
);

#INSERT INTO Project(ProjectName, Active) VALUES ('Test 1', 1);


CREATE TABLE User(
	UserId			INT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	ScreenName		VARCHAR(25)	NOT NULL,
	FirstName		VARCHAR(25)	NOT NULL,
	LastName		VARCHAR(25)	NOT NULL,
	IsActive		BIT		NOT NULL,
	UserHash		VARCHAR(255)	NOT NULL
);



CREATE TABLE `Group`(
	GroupId			INT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	GroupName		VARCHAR(50)	NOT NULL,
	ProjectId		INT		NOT NULL
);

#INSERT INTO `Group`(GroupName, ProjectId) VALUES('Group 1', 1);


CREATE TABLE UserProject(
	UserProjectId		INT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	UserId			INT		NOT NULL,
	GroupId			INT		NOT NULL
);

SELECT * FROM User;
SELECT * FROM `Group`;

#INSERT INTO UserProject(UserId,ProjectId,GroupId) VALUES (1,1,2);


CREATE TABLE TimeEntry(
	TimeEntryId		BIGINT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	UserId			INT		NOT NULL,
	TimeStart		DATETIME	NOT NULL,
	TimeStop		DATETIME		,
	Deleted			BIT		NOT NULL,
	EntryComment		VARCHAR(255)	NOT NULL,
	CreateDate		DATETIME	NOT NULL
);



CREATE TABLE TimeEntryHistory(
	TimeEntryHistoryId	BIGINT		NOT NULL	AUTO_INCREMENT		PRIMARY KEY,
	TimeEntryId		BIGINT		NOT NULL,
	ChangedField		VARCHAR(25)	NOT NULL,
	OldValue		VARCHAR(255)		,
	NewValue		VARCHAR(255),
	CreateDate		DATETIME		NOT NULL
);


ALTER TABLE `Group`
	ADD CONSTRAINT FK_groupProjectId
	FOREIGN KEY (ProjectId) REFERENCES Project (ProjectID)
	ON UPDATE CASCADE
	ON DELETE CASCADE

;


ALTER TABLE UserProject
	ADD CONSTRAINT FK_ProjectUserUserId
	FOREIGN KEY (UserId) REFERENCES `User` (UserId)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	ADD CONSTRAINT FK_UserProjectGroupId
	FOREIGN KEY (GroupId) REFERENCES `Group` (GroupId)
	ON UPDATE CASCADE
	ON DELETE CASCADE
;


ALTER TABLE TimeEntry
	ADD CONSTRAINT FK_TEUserId
	FOREIGN KEY (UserId) REFERENCES User (UserId)
	ON UPDATE CASCADE
	ON DELETE CASCADE
;

ALTER TABLE TimeEntryHistory
	ADD CONSTRAINT FK_TEHTimeEntryHistoryId
	FOREIGN KEY (TimeEntryId) REFERENCES TimeEntry(TimeEntryId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;

INSERT INTO User(ScreenName,FirstName,LastName,IsActive,UserHash) VALUES('William','William','Parkinson',1,'abc');

SELECT
	*
FROM
	User
