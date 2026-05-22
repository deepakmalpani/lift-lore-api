using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

[Route("api/[controller]")]
[ApiController]
public class WorkoutPlansController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateWorkoutPlan([FromBody] CreateWorkoutPlan workoutPlan)
    {
        var newWorkoutPlan = new WorkoutPlan()
        {
            Id = StaticDatabase.WorkoutPlans.Count + 1,
            Name = workoutPlan.Name,
            Description = workoutPlan.Description,
            CreatedAt = DateTime.UtcNow
        };
        return CreatedAtAction(nameof(CreateWorkoutPlan), new {id = newWorkoutPlan.Id}, newWorkoutPlan);
    }
}