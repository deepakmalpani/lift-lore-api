using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public static class WorkoutDaysEndpoints
{
    public static void RegisterWorkoutDaysEndpoints(this WebApplication app)
    {
        app.MapPost("/{planId}/days", async (int planId, [FromBody] List<CreateWorkoutDay> workoutDays) =>
        {
            if (workoutDays == null || !workoutDays.Any())
        {
            return Results.BadRequest("Workout days list cannot be null or empty");
        }
        var parentWorkoutPlan = StaticDatabase.WorkoutPlans.FirstOrDefault(m => m.Id == planId);
        if (parentWorkoutPlan == null)
        {
            return Results.NotFound($"Plan with ID {planId} does not exist");
        }
        int nextId = StaticDatabase.WorkoutDays.Any() ?
                        StaticDatabase.WorkoutDays.Max(m => m.Id) + 1 :
                        1;
        var newWorkoutDayList = new List<WorkoutDay>();
        foreach (var workoutDay in workoutDays)
        {
            var newWorkoutDay = new WorkoutDay()
            {
                Id = nextId++,
                WorkoutPlanId = parentWorkoutPlan.Id,
                DayOfWeek = workoutDay.DayOfWeek,
                Name = workoutDay.Name,
                IsRestDay = workoutDay.IsRestDay
            };
            newWorkoutDayList.Add(newWorkoutDay);
        }
        StaticDatabase.WorkoutDays.AddRange(newWorkoutDayList);
        return Results.Created($"/{planId}/days", newWorkoutDayList);
        });
    }
}