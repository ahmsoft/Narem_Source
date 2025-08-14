SELECT * INTO B1 FROM Comments WHERE Action='Posts' AND IsShow=1 AND Active=1; 
SELECT * INTO M1 FROM Message WHERE CatName_En LIKE '%' +REPLACE(REPLACE('Windows Software Downloads', '-', ' '),';',' ') + '%'; 
SELECT COUNT(B1.IDC) AS CommentsCount, M1.IDMessage, M1.Title_Fa, M1.Title_En, M1.PreMessage_Fa, M1.PreMessage_En, M1.Image, M1.WrittenBy_Fa, M1.WrittenBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En 
FROM M1 FULL OUTER JOIN B1 ON B1.IDElement = M1.IDMessage where M1.IDMessage is not null
GROUP BY M1.IDMessage, M1.Title_Fa, M1.Title_En, M1.PreMessage_Fa, M1.PreMessage_En, M1.Image, M1.WrittenBy_Fa, M1.WrittenBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En 
ORDER BY M1.Year_En DESC, M1.Month_En DESC, M1.Day_En DESC;
DROP TABLE B1; 
DROP TABLE M1;