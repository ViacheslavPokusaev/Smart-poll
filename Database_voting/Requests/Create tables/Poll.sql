USE Smart_poll;

CREATE TABLE Poll
(
	Id INT PRIMARY KEY IDENTITY,
	ClientId INT NOT NULL,
	IsPossibleToAddOption BIT DEFAULT 0,
	MaxOptionsInPoll INT NOT NULL CHECK(MaxOptionsInPoll > 0),
	MaxVotesByOneClient INT DEFAULT 1 CHECK(MaxVotesByOneClient > 0),
	DeadLine DATE NOT NULL CHECK(DeadLine >= GETDATE()),
	QuestionText NVARCHAR(300) NOT NULL,
	IsPublic BIT DEFAULT 1,
	DateCreatingPoll DATE NOT NULL DEFAULT SYSUTCDATETIME(),
	CHECK(MaxVotesByOneClient <= MaxOptionsInPoll),
	CONSTRAINT FK_Poll_To_Client FOREIGN KEY (ClientId) REFERENCES Client (Id) ON DELETE CASCADE
)