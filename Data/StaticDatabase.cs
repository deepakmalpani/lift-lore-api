public static class StaticDatabase
{
    public static List<WorkoutPlan> WorkoutPlans {get; set;} = new();
    public static List<WorkoutDay> WorkoutDays {get; set;} = new();
    public static List<Exercise> Exercises {get; set;} = new();
    public static List<WorkoutLog> WorkoutLogs {get; set;} = new();
}