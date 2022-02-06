보통은 아주 편리한 `LINQ`를 사용하지만 한번씩 db access를 줄이고 싶다거나.. 그럴 때 조인을 하고싶어진다.  
문법은 이런식으로 쓴다.
```cs
 var result = from school in dbContext.Schools.Where(a => a.SchoolType == SchoolTypes.Elementary)
   join student in dbContext.Students
   on school.State equals student.State
   join fee in dbContext.Fees
   on school.Fee equals fee.Amount
   select new StudentFee() { Student = student, FeeInfo = fee };
```
