﻿namespace ExerciseTrackerUI.Models;

public class Exercise
{
    public int Id { get; set; }
    public string? ExerciseName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Comments { get; set; }
}