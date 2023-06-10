using AOC.Helpers;

class Program {
	static void Main(string[] args) {

		bool exit = false;
		do {
			var baseColor = Console.ForegroundColor;

			int selectedYear = SelectYear();

			int selectedProblem = SelectProblem(selectedYear);

			try {
				var time = PuzzleHelper.ExecutePuzzle(selectedYear, selectedProblem);

				WriteTime(time, baseColor);
			} catch (Exception ex) {
				WriteLineWithColor(ex.Message, ConsoleColor.Red, baseColor);
			}

			Console.WriteLine();
			Console.WriteLine("Back to the Principal Menu?");

			ConsoleHelper.SetVariables(2, 5, 6);
			exit = ConsoleHelper.MultipleChoice(false, "YES", "NO") == 1;

			ConsoleHelper.ResetVariables();

			Console.Clear();
		} while (!exit);
	}

	private static int SelectProblem(int year) {
		Console.WriteLine("Problems of the year " + year);

		ConsoleHelper.SetVariables(5, 0, 1);
		var problems = PuzzleHelper.GetProblemsOfYear(year);

		int selectedProblemMenu = ConsoleHelper.MultipleChoice(false, problems);
		int selectedProblem = int.Parse(problems[selectedProblemMenu].Split(' ')[1]);

		Console.Clear();
		ConsoleHelper.ResetVariables();
		return selectedProblem;
	}

	private static int SelectYear() {
		Console.Write("Year to Solve? ");
		ConsoleHelper.SetVariables(1, 0, 1);
		var years = PuzzleHelper.GetYears();
		int selectedYearMenu = ConsoleHelper.MultipleChoice(false, years);
		int selectedYear = int.Parse(years[selectedYearMenu]);

		Console.Clear();
		ConsoleHelper.ResetVariables();
		return selectedYear;
	}

	private static void WriteLineWithColor(string text, ConsoleColor color, ConsoleColor baseColor) {
		Console.ForegroundColor = color;
		Console.WriteLine(text);
		Console.ForegroundColor = baseColor;
	}

	private static void WriteTime(TimeSpan time, ConsoleColor baseColor) {
		var t = time.Ticks / 100;
		ConsoleColor cc;
		if (t >= 200000) {
			cc = ConsoleColor.Red;
		} else if (t >= 50000) {
			cc = ConsoleColor.Yellow;
		} else {
			cc = ConsoleColor.Green;
		}

		var text = $"({(time.Minutes != 0 ? time.Minutes + " Minutes " : "")}{(time.Seconds != 0 ? time.Seconds + " Seconds " : "")}{time.Milliseconds} Miliseconds)";

		WriteLineWithColor(text, cc, baseColor);
	}

}
