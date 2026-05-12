public class WorkoutDay
{
    public int Id {get; set;}
    public int WorkoutPlanId {get; set;}
    public string DayofWeek {get; set;} = "";
    public string Name {get; set;} = "";
    public bool isRestDay {get; set;}
}