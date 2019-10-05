USE master 
GO

CREATE DATABASE StackOverflow
GO

USE StackOverflow
GO

CREATE TABLE Badges (
	Id int NOT NULL,
	UserId int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Date datetime NOT NULL,
	Class tinyint NOT NULL,
	TagBased bit NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE CloseAsOffTopicReasonTypes (
	Id smallint NOT NULL,
	IsUniversal bit NOT NULL,
	MarkdownMini nvarchar(500) NOT NULL,
	CreationDate datetime NOT NULL,
	CreationModeratorId int NULL,
	ApprovalDate datetime NULL,
	ApprovalModeratorId int NULL,
	DeactivationDate datetime NULL,
	DeactivationModeratorId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE CloseReasonTypes (
	Id tinyint NOT NULL,
	Name nvarchar(200) NOT NULL,
	Description nvarchar(500) NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE Comments (
	Id int NOT NULL,
	PostId int NOT NULL,
	Score int NOT NULL,
	Text nvarchar(600) NOT NULL,
	CreationDate datetime NOT NULL,
	UserDisplayName nvarchar(30) NULL,
	UserId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE FlagTypes (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(500) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PendingFlags (
	Id int NOT NULL,
	FlagTypeId tinyint NOT NULL,
	PostId int NOT NULL,
	CreationDate date NULL,
	CloseReasonTypeId tinyint NULL,
	CloseAsOffTopicReasonTypeId smallint NULL,
	DuplicateOfQuestionId int NULL,
	BelongsOnBaseHostAddress nvarchar(100) NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostFeedback (
	Id int NOT NULL,
	PostId int NOT NULL,
	IsAnonymous bit NULL,
	VoteTypeId tinyint NOT NULL,
	CreationDate datetime NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostHistory (
	Id int NOT NULL,
	PostHistoryTypeId tinyint NOT NULL,
	PostId int NOT NULL,
	RevisionGUID uniqueidentifier NOT NULL,
	CreationDate datetime NOT NULL,
	UserId int NULL,
	UserDisplayName nvarchar(40) NULL,
	Comment nvarchar(400) NULL,
	Text nvarchar(800) NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostHistoryTypes (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostLinks (
	Id int NOT NULL,
	CreationDate datetime NOT NULL,
	PostId int NOT NULL,
	RelatedPostId int NOT NULL,
	LinkTypeId tinyint NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostNoticeTypes (
	Id int NOT NULL,
	ClassId tinyint NOT NULL,
	Name nvarchar(80) NULL,
	Body nvarchar(800) NULL,
	IsHidden bit NOT NULL,
	Predefined bit NOT NULL,
	PostNoticeDurationId int NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostNotices (
	Id int NOT NULL,
	PostId int NOT NULL,
	PostNoticeTypeId int NULL,
	CreationDate datetime NOT NULL,
	DeletionDate datetime NULL,
	ExpiryDate datetime NULL,
	Body nvarchar(800) NULL,
	OwnerUserId int NULL,
	DeletionUserId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostTags (
	PostId int NOT NULL,
	TagId int NOT NULL,
	PRIMARY KEY ( PostId, TagId)
);       

CREATE TABLE PostTypes (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE Posts (
	Id int NOT NULL,
	PostTypeId tinyint NOT NULL,
	AcceptedAnswerId int NULL,
	ParentId int NULL,
	CreationDate datetime NOT NULL,
	DeletionDate datetime NULL,
	Score int NOT NULL,
	ViewCount int NULL,
	Body nvarchar(800) NULL,
	OwnerUserId int NULL,
	OwnerDisplayName nvarchar(40) NULL,
	LastEditorUserId int NULL,
	LastEditorDisplayName nvarchar(40) NULL,
	LastEditDate datetime NULL,
	LastActivityDate datetime NULL,
	Title nvarchar(250) NULL,
	Tags nvarchar(250) NULL,
	AnswerCount int NULL,
	CommentCount int NULL,
	FavoriteCount int NULL,
	ClosedDate datetime NULL,
	CommunityOwnedDate datetime NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE PostsWithDeleted (
	Id int NOT NULL,
	PostTypeId tinyint NOT NULL,
	AcceptedAnswerId int NULL,
	ParentId int NULL,
	CreationDate datetime NOT NULL,
	DeletionDate datetime NULL,
	Score int NOT NULL,
	ViewCount int NULL,
	Body nvarchar(800) NULL,
	OwnerUserId int NULL,
	OwnerDisplayName nvarchar(40) NULL,
	LastEditorUserId int NULL,
	LastEditorDisplayName nvarchar(40) NULL,
	LastEditDate datetime NULL,
	LastActivityDate datetime NULL,
	Title nvarchar(250) NULL,
	Tags nvarchar(250) NULL,
	AnswerCount int NULL,
	CommentCount int NULL,
	FavoriteCount int NULL,
	ClosedDate datetime NULL,
	CommunityOwnedDate datetime NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewRejectionReasons (
	Id tinyint NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(300) NOT NULL,
	PostTypeId tinyint NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewTaskResultTypes (
	Id tinyint NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(300) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewTaskResults (
	Id int NOT NULL,
	ReviewTaskId int NOT NULL,
	ReviewTaskResultTypeId tinyint NOT NULL,
	CreationDate date NULL,
	RejectionReasonId tinyint NULL,
	Comment nvarchar(150) NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewTaskStates (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(300) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewTaskTypes (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(300) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE ReviewTasks (
	Id int NOT NULL,
	ReviewTaskTypeId tinyint NOT NULL,
	CreationDate date NULL,
	DeletionDate date NULL,
	ReviewTaskStateId tinyint NOT NULL,
	PostId int NOT NULL,
	SuggestedEditId int NULL,
	CompletedByReviewTaskId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE SuggestedEditVotes (
	Id int NOT NULL,
	SuggestedEditId int NOT NULL,
	UserId int NOT NULL,
	VoteTypeId tinyint NOT NULL,
	CreationDate datetime NOT NULL,
	TargetUserId int NULL,
	TargetRepChange int NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE SuggestedEdits (
	Id int NOT NULL,
	PostId int NOT NULL,
	CreationDate datetime NULL,
	ApprovalDate datetime NULL,
	RejectionDate datetime NULL,
	OwnerUserId int NULL,
	Comment nvarchar(800) NULL,
	Text nvarchar(800) NULL,
	Title nvarchar(250) NULL,
	Tags nvarchar(250) NULL,
	RevisionGUID uniqueidentifier NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE TagSynonyms (
	Id int NOT NULL,
	SourceTagName nvarchar(35) NULL,
	TargetTagName nvarchar(35) NULL,
	CreationDate datetime NOT NULL,
	OwnerUserId int NOT NULL,
	AutoRenameCount int NOT NULL,
	LastAutoRename datetime NULL,
	Score int NOT NULL,
	ApprovedByUserId int NULL,
	ApprovalDate datetime NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE Tags (
	Id int NOT NULL,
	TagName nvarchar(35) NULL,
	Count int NOT NULL,
	ExcerptPostId int NULL,
	WikiPostId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE Users (
	Id int NOT NULL,
	Reputation int NOT NULL,
	CreationDate datetime NOT NULL,
	DisplayName nvarchar(40) NULL,
	LastAccessDate datetime NOT NULL,
	WebsiteUrl nvarchar(200) NULL,
	Location nvarchar(100) NULL,
	AboutMe nvarchar(800) NULL,
	Views int NOT NULL,
	UpVotes int NOT NULL,
	DownVotes int NOT NULL,
	ProfileImageUrl nvarchar(200) NULL,
	EmailHash varchar(32) NULL,
	AccountId int NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE VoteTypes (
	Id tinyint NOT NULL,
	Name nvarchar(50) NOT NULL,
	PRIMARY KEY ( Id )
);       

CREATE TABLE Votes (
	Id int NOT NULL,
	PostId int NOT NULL,
	VoteTypeId tinyint NOT NULL,
	UserId int NULL,
	CreationDate datetime NULL,
	BountyAmount int NULL,
	PRIMARY KEY ( Id )
);       

ALTER TABLE PostsWithDeleted 
ADD CONSTRAINT Fk_PostsWithDeleted_PostTypeId FOREIGN KEY ( PostTypeId ) 
REFERENCES PostTypes( Id );

ALTER TABLE PostHistory 
ADD CONSTRAINT Fk_PostHistory_PostHistoryTypeId FOREIGN KEY ( PostHistoryTypeId ) 
REFERENCES PostHistoryTypes( Id );

ALTER TABLE PostHistory 
ADD CONSTRAINT Fk_PostHistory_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PostHistory 
ADD CONSTRAINT Fk_PostHistory_UserId FOREIGN KEY ( UserId ) 
REFERENCES Users( Id );

ALTER TABLE Votes 
ADD CONSTRAINT Fk_Votes_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE Votes 
ADD CONSTRAINT Fk_Votes_VoteTypeId FOREIGN KEY ( VoteTypeId ) 
REFERENCES VoteTypes( Id );

ALTER TABLE Votes 
ADD CONSTRAINT Fk_Votes_UserId FOREIGN KEY ( UserId ) 
REFERENCES Users( Id );

ALTER TABLE Badges 
ADD CONSTRAINT Fk_Badges_UserId FOREIGN KEY ( UserId ) 
REFERENCES Users( Id );

ALTER TABLE Comments 
ADD CONSTRAINT Fk_Comments_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE Comments 
ADD CONSTRAINT Fk_Comments_UserId FOREIGN KEY ( UserId ) 
REFERENCES Users( Id );

ALTER TABLE PostFeedback 
ADD CONSTRAINT Fk_PostFeedback_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PostFeedback 
ADD CONSTRAINT Fk_PostFeedback_VoteTypeId FOREIGN KEY ( VoteTypeId ) 
REFERENCES VoteTypes( Id );

ALTER TABLE SuggestedEdits 
ADD CONSTRAINT Fk_SuggestedEdits_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE SuggestedEditVotes 
ADD CONSTRAINT Fk_SuggestedEditVotes_SuggestedEditId FOREIGN KEY ( SuggestedEditId ) 
REFERENCES SuggestedEdits( Id );

ALTER TABLE SuggestedEditVotes 
ADD CONSTRAINT Fk_SuggestedEditVotes_UserId FOREIGN KEY ( UserId ) 
REFERENCES Users( Id );

ALTER TABLE SuggestedEditVotes 
ADD CONSTRAINT Fk_SuggestedEditVotes_VoteTypeId FOREIGN KEY ( VoteTypeId ) 
REFERENCES VoteTypes( Id );

ALTER TABLE PostLinks 
ADD CONSTRAINT Fk_PostLinks_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PendingFlags 
ADD CONSTRAINT Fk_PendingFlags_FlagTypeId FOREIGN KEY ( FlagTypeId ) 
REFERENCES FlagTypes( Id );

ALTER TABLE PendingFlags 
ADD CONSTRAINT Fk_PendingFlags_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PendingFlags 
ADD CONSTRAINT Fk_PendingFlags_CloseReasonTypeId FOREIGN KEY ( CloseReasonTypeId ) 
REFERENCES CloseReasonTypes( Id );

ALTER TABLE PendingFlags 
ADD CONSTRAINT Fk_PendingFlags_CloseAsOffTopicReasonTypeId FOREIGN KEY ( CloseAsOffTopicReasonTypeId ) 
REFERENCES CloseAsOffTopicReasonTypes( Id );

ALTER TABLE ReviewTasks 
ADD CONSTRAINT Fk_ReviewTasks_ReviewTaskTypeId FOREIGN KEY ( ReviewTaskTypeId ) 
REFERENCES ReviewTaskTypes( Id );

ALTER TABLE ReviewTasks 
ADD CONSTRAINT Fk_ReviewTasks_ReviewTaskStateId FOREIGN KEY ( ReviewTaskStateId ) 
REFERENCES ReviewTaskStates( Id );

ALTER TABLE ReviewTasks 
ADD CONSTRAINT Fk_ReviewTasks_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE ReviewTasks 
ADD CONSTRAINT Fk_ReviewTasks_SuggestedEditId FOREIGN KEY ( SuggestedEditId ) 
REFERENCES SuggestedEdits( Id );

ALTER TABLE ReviewTaskResults 
ADD CONSTRAINT Fk_ReviewTaskResults_ReviewTaskId FOREIGN KEY ( ReviewTaskId ) 
REFERENCES ReviewTasks( Id );

ALTER TABLE ReviewTaskResults 
ADD CONSTRAINT Fk_ReviewTaskResults_ReviewTaskResultTypeId FOREIGN KEY ( ReviewTaskResultTypeId ) 
REFERENCES ReviewTaskResultTypes( Id );

ALTER TABLE ReviewRejectionReasons 
ADD CONSTRAINT Fk_ReviewRejectionReasons_PostTypeId FOREIGN KEY ( PostTypeId ) 
REFERENCES PostTypes( Id );

ALTER TABLE PostNotices 
ADD CONSTRAINT Fk_PostNotices_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PostNotices 
ADD CONSTRAINT Fk_PostNotices_PostNoticeTypeId FOREIGN KEY ( PostNoticeTypeId ) 
REFERENCES PostNoticeTypes( Id );

ALTER TABLE PostTags 
ADD CONSTRAINT Fk_PostTags_PostId FOREIGN KEY ( PostId ) 
REFERENCES Posts( Id );

ALTER TABLE PostTags 
ADD CONSTRAINT Fk_PostTags_TagId FOREIGN KEY ( TagId ) 
REFERENCES Tags( Id );

ALTER TABLE Posts 
ADD CONSTRAINT Fk_Posts_PostTypeId FOREIGN KEY ( PostTypeId ) 
REFERENCES PostTypes( Id );

ALTER TABLE PostsWithDeleted 
ADD CONSTRAINT Fk_PostsWithDeleted_OwnerUserId FOREIGN KEY ( OwnerUserId ) 
REFERENCES Users( Id );

ALTER TABLE PostsWithDeleted 
ADD CONSTRAINT Fk_PostsWithDeleted_LastEditorUserId FOREIGN KEY ( LastEditorUserId ) 
REFERENCES Users( Id );

ALTER TABLE TagSynonyms 
ADD CONSTRAINT Fk_TagSynonyms_OwnerUserId FOREIGN KEY ( OwnerUserId ) 
REFERENCES Users( Id );

ALTER TABLE TagSynonyms 
ADD CONSTRAINT Fk_TagSynonyms_ApprovedByUserId FOREIGN KEY ( ApprovedByUserId ) 
REFERENCES Users( Id );

ALTER TABLE SuggestedEdits 
ADD CONSTRAINT Fk_SuggestedEdits_OwnerUserId FOREIGN KEY ( OwnerUserId ) 
REFERENCES Users( Id );

ALTER TABLE SuggestedEditVotes 
ADD CONSTRAINT Fk_SuggestedEditVotes_TargetUserId FOREIGN KEY ( TargetUserId ) 
REFERENCES Users( Id );

ALTER TABLE CloseAsOffTopicReasonTypes 
ADD CONSTRAINT Fk_CloseAsOffTopicReasonTypes_CreationModeratorId FOREIGN KEY ( CreationModeratorId ) 
REFERENCES Users( Id );

ALTER TABLE CloseAsOffTopicReasonTypes 
ADD CONSTRAINT Fk_CloseAsOffTopicReasonTypes_ApprovalModeratorId FOREIGN KEY ( ApprovalModeratorId ) 
REFERENCES Users( Id );

ALTER TABLE CloseAsOffTopicReasonTypes 
ADD CONSTRAINT Fk_CloseAsOffTopicReasonTypes_DeactivationModeratorId FOREIGN KEY ( DeactivationModeratorId ) 
REFERENCES Users( Id );

ALTER TABLE PostNotices 
ADD CONSTRAINT Fk_PostNotices_OwnerUserId FOREIGN KEY ( OwnerUserId ) 
REFERENCES Users( Id );

ALTER TABLE PostNotices 
ADD CONSTRAINT Fk_PostNotices_DeletionUserId FOREIGN KEY ( DeletionUserId ) 
REFERENCES Users( Id );

ALTER TABLE Posts 
ADD CONSTRAINT Fk_Posts_OwnerUserId FOREIGN KEY ( OwnerUserId ) 
REFERENCES Users( Id );

ALTER TABLE Posts 
ADD CONSTRAINT Fk_Posts_LastEditorUserId FOREIGN KEY ( LastEditorUserId ) 
REFERENCES Users( Id );

ALTER TABLE PostsWithDeleted 
ADD CONSTRAINT Fk_PostsWithDeleted_AcceptedAnswerId FOREIGN KEY ( AcceptedAnswerId ) 
REFERENCES Posts( Id );

ALTER TABLE PostsWithDeleted 
ADD CONSTRAINT Fk_PostsWithDeleted_ParentId FOREIGN KEY ( ParentId ) 
REFERENCES Posts( Id );

ALTER TABLE PostLinks 
ADD CONSTRAINT Fk_PostLinks_RelatedPostId FOREIGN KEY ( RelatedPostId ) 
REFERENCES Posts( Id );

ALTER TABLE PendingFlags 
ADD CONSTRAINT Fk_PendingFlags_DuplicateOfQuestionId FOREIGN KEY ( DuplicateOfQuestionId ) 
REFERENCES Posts( Id );

ALTER TABLE Tags 
ADD CONSTRAINT Fk_Tags_ExcerptPostId FOREIGN KEY ( ExcerptPostId ) 
REFERENCES Posts( Id );

ALTER TABLE Tags 
ADD CONSTRAINT Fk_Tags_WikiPostId FOREIGN KEY ( WikiPostId ) 
REFERENCES Posts( Id );

ALTER TABLE Posts 
ADD CONSTRAINT Fk_Posts_AcceptedAnswerId FOREIGN KEY ( AcceptedAnswerId ) 
REFERENCES Posts( Id );

ALTER TABLE Posts 
ADD CONSTRAINT Fk_Posts_ParentId FOREIGN KEY ( ParentId ) 
REFERENCES Posts( Id );

ALTER TABLE ReviewTaskResults 
ADD CONSTRAINT Fk_ReviewTaskResults_RejectionReasonId FOREIGN KEY ( RejectionReasonId ) 
REFERENCES ReviewRejectionReasons( Id );

ALTER TABLE ReviewTasks 
ADD CONSTRAINT Fk_ReviewTasks_CompletedByReviewTaskId FOREIGN KEY ( CompletedByReviewTaskId ) 
REFERENCES ReviewTaskResults( Id );

-- Foreign keys work by joining a column to a unique key in another table, and that unique key must be defined as some form of unique index, be it the primary key, or some other unique index.
CREATE UNIQUE INDEX [UX_Tags_TagName] ON Tags(TagName);

ALTER TABLE TagSynonyms 
ADD CONSTRAINT Fk_TagSynonymsSourceTagName_SourceTagName FOREIGN KEY ( SourceTagName ) 
REFERENCES Tags( TagName );

ALTER TABLE TagSynonyms 
ADD CONSTRAINT Fk_TagSynonymsTargetTagName_TargetTagName FOREIGN KEY ( TargetTagName ) 
REFERENCES Tags( TagName );
GO
