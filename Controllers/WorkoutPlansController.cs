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
        StaticDatabase.WorkoutPlans.Add(newWorkoutPlan);
        return CreatedAtAction(nameof(GetWorkoutPlanById), new {id = newWorkoutPlan.Id}, newWorkoutPlan);
    }
    [HttpGet("{id}")]
    public IActionResult GetWorkoutPlanById(int id)
    {
        var plan = StaticDatabase.WorkoutPlans.FirstOrDefault(p => p.Id == id);

        if(plan == null)
        {
            return NotFound();
        }
        return Ok(plan);
    }
}