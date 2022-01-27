https://www.entityframeworktutorial.net/code-first/column-dataannotations-attribute-in-code-first.aspx

### Column이름과 코드상에서 사용할 Property 이름을 다르게 설정할 수 있다
```cs
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    public int StudentID { get; set; }
     
    [Column("Name")]
    public string StudentName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte[] Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
}
```

![db](https://www.entityframeworktutorial.net/images/efcore/column-attribute1.png)
