USE Smart_voting;

CREATE TABLE Voting
(
	VotingID INT PRIMARY KEY IDENTITY,
	UserID INT NOT NULL,
	AddNewOptions BIT DEFAULT 0,
	MaxOptions INT NOT NULL CHECK(MaxOptions > 0 AND MaxOptions < 20),
	MaxVotesByOneUser INT DEFAULT 1 CHECK(MaxVotesByOneUser > 0),
	DeadLine DATE NOT NULL,
	QuestionInVoting NVARCHAR(300) NOT NULL,
	CONSTRAINT FK_Voting_To_Users FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE
)