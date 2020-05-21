USE Smart_poll;

SELECT * FROM Poll
WHERE Id NOT IN (
SELECT OptionPoll.PollId From ClientAnswer
INNER JOIN OptionPoll ON ClientAnswer.OptionId = OptionPoll.Id
WHERE ClientAnswer.ClientId = 4
GROUP BY OptionPoll.PollId) 
AND IsPrivate = 0 AND DeadLine > GETDATE()
--INNER JOIN Poll ON Poll.Id = OptionPoll.Id
--WHERE ClientAnswer.ClientId = 1