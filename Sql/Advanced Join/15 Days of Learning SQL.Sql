With SubmissionsCte (Submission_Date, Hacker_Id, DC)
As
(
    select Submission_Date, Hacker_Id, DC = 1 from Submissions where Submission_Date = (Select Min(Submission_Date) from Submissions)
    union all 
    select S1.Submission_Date, S1.Hacker_Id, DC = 1 from Submissions S1 inner join SubmissionsCte sc on s1.hacker_Id = sc.Hacker_Id 
    and S1.Submission_Date = DateAdd(D,1,Sc.Submission_Date)
)
Select X.Submission_Date, Y.UHackerCount, x.Hacker_Id, H.Name 
from Hackers H
inner join (
            select    Min(T2.Hacker_Id) as Hacker_Id
                ,    T2.Submission_Date
                ,    T2.DC
            from (select s.Submission_Date, s.Hacker_Id, DC = Count(s.Submission_Id) from Submissions s group by s.Submission_Date, s.Hacker_Id) T2
            inner join (    
                            select T1.Submission_Date, Max(T1.Dc) as DC from (select s.Submission_Date, s.Hacker_Id, DC = Count(s.Submission_Id) from Submissions s group by s.Submission_Date, s.Hacker_Id) T1
                            group by T1.Submission_Date
                        ) T3
            on T2.Submission_Date = T3.Submission_Date and T2.DC = T3.DC
            group by T2.Submission_Date, T2.DC
         ) X  on H.Hacker_Id = X.Hacker_Id
inner join (
             select Submission_Date, Count(Distinct Hacker_Id) as UHackerCount
             from SubmissionsCte 
             group by Submission_Date
           ) Y on X.Submission_Date = Y.Submission_Date
order by 1