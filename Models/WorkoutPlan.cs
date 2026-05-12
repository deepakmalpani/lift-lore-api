
using System.ComponentModel.DataAnnotations;

public class WorkoutPlan
{
    public int Id {get; set;}
    public string Name {get; set;} = "";
    public string Description {get; set;} = "";
    [DataType(DataType.Date)]
    public DateTime CreatedAt {get; set;}
}