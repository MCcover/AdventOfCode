using AOC.Helpers;

class Program {
	static void Main(string[] args) {

		bool exit = false;
		do {
			var baseColor = Console.ForegroundColor;

			int selectedYear = SelectYear();

			int selectedProblem = SelectProblem(selectedYear);

			try {
				PuzzleHelper.ExecutePuzzle(selectedYear, selectedProblem);
			} catch (Exception ex) {
				ConsoleHelper.WriteLineWithColor(ex.Message, ConsoleColor.Red, baseColor);
			}

			Console.WriteLine();
			Console.WriteLine("Back to the Principal Menu?");

			MenuHelper.SetVariables(2, 5, 11);
			exit = MenuHelper.MultipleChoice(false, "YES", "NO") == 1;

			MenuHelper.ResetVariables();

			Console.Clear();
		} while (!exit);
	}

	private static int SelectProblem(int year) {
		Console.WriteLine("Problems of the year " + year);

		MenuHelper.SetVariables(5, 0, 1);
		var problems = PuzzleHelper.GetProblemsOfYear(year);

		int selectedProblemMenu = MenuHelper.MultipleChoice(false, problems);
		int selectedProblem = int.Parse(problems[selectedProblemMenu].Split(' ')[1]);

		Console.Clear();
		MenuHelper.ResetVariables();
		return selectedProblem;
	}

	private static int SelectYear() {
		Console.Write("Year to Solve? ");
		MenuHelper.SetVariables(1, 0, 1);
		var years = PuzzleHelper.GetYears();
		int selectedYearMenu = MenuHelper.MultipleChoice(false, years);
		int selectedYear = int.Parse(years[selectedYearMenu]);

		Console.Clear();
		MenuHelper.ResetVariables();
		return selectedYear;
	}

	

}
