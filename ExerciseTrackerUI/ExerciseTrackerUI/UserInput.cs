using ExerciseTrackerUI.Models;

namespace ExerciseTrackerUI;

public class UserInput
{
    public async Task Menu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Shift menu\n");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press '1' to view all Exercises");
            Console.WriteLine("Press '2' to add a exercise");
            Console.WriteLine("Press '3' to delete a exercise");
            Console.WriteLine("Press '4' to update a exercise");
            Console.WriteLine("----------------------------------");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await ShowExercises();
                    break;

                case "2":
                    await AddExercise();
                    break;

                /*     case "3":
                         await
                                    break;

                     case "4":
                         await
                                    break;*/

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    public async Task ShowExercises()
    {
        var exercises = await ExerciseHtpp.GetAllExercises();

        foreach (var exercise in exercises)
        {
            Console.WriteLine($"{exercise.Id} {exercise.StartTime}");
        }
    }

    public async Task AddExercise()

    {
        var exercise = new Exercise();
        Console.WriteLine("Please enter the exercise name or type 0  to go back to menu");
        var name = Console.ReadLine();
        if (name == "0") return;
        while (string.IsNullOrEmpty(name)) Console.WriteLine("Input can not be empty try again.");

        Console.WriteLine("Please enter the start date in the HH:mm format");
        var startDate = Console.ReadLine();
        while (!DateTime.TryParseExact(startDate, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _) || string.IsNullOrEmpty(startDate))
        {
            Console.WriteLine("Invalid date time");
            startDate = Console.ReadLine();
        }

        Console.WriteLine("Please enter the end date in the HH:mm format");
        var endDate = Console.ReadLine();

        while (DateTime.Parse(endDate) <= DateTime.Parse(startDate))
        {
            Console.WriteLine("End time can't be lower than start time");
            endDate = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(endDate, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _) || string.IsNullOrEmpty(startDate))
        {
            Console.WriteLine("Invalid date time");
            endDate = Console.ReadLine();
        }

        Console.WriteLine("Add a comment to your workout or press any key to skip ");
        var comment = Console.ReadLine();

        exercise.ExerciseName = name;
        exercise.StartTime = DateTime.Parse(startDate);
        exercise.EndTime = DateTime.Parse(endDate);
        exercise.Duration = DateTime.Parse(endDate) - DateTime.Parse(startDate);
        exercise.Comments = comment;
        await ExerciseHtpp.AddExercise(exercise);
    }
}