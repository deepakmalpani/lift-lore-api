using System.ComponentModel.DataAnnotations;

public class WorkoutLog
{
    public int Id {get; set;}
    public int ExerciseId {get; set;}
    public int PerformedSets {get; set;}
    public int PerformedReps {get; set;}
    public int WeightUsed {get; set;}
    [DataType(DataType.Date)]
    public DateTime PerformedAt {get; set;}
}