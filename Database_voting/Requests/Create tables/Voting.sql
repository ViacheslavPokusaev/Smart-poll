USE Smart_voting_release;

CREATE TABLE Voting
(
	VotingID INT PRIMARY KEY IDENTITY,
	UserID INT NOT NULL,
	AddNewOptions BIT DEFAULT 0,
	MaxOptions INT NOT NULL CHECK(MaxOptions > 0 AND MaxOptions < 20),
	MaxVotesByOneUser INT DEFAULT 1 CHECK(MaxVotesByOneUser > 0),
	DeadLine DATE NOT NULL CHECK(DeadLine >= GETDATE()),
	QuestionInVoting NVARCHAR(300) NOT NULL,
	PublicOrPrivate BIT DEFAULT 1,
	DateCreatingVoting DATE NOT NULL DEFAULT SYSUTCDATETIME(),
	CHECK(MaxVotesByOneUser <= MaxOptions),
	CONSTRAINT FK_Voting_To_Users FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE
)