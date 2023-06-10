using AOC.Interfaces;
using System.Diagnostics;

namespace AOC.Helpers {
	public static class PuzzleHelper {

		public static TimeSpan ExecutePuzzle(int yearInput, int puzzleInput) {
			var puzzle = SelectProblem(yearInput, puzzleInput) ?? throw new Exception("Puzzle Not Found");

			Console.WriteLine($"Results of the problem {puzzleInput} of the year {yearInput}");

			Stopwatch sw = new();
			sw.Start();

			puzzle.Solve();

			sw.Stop();

			return TimeSpan.FromTicks(sw.ElapsedTicks);
		}

		private static IPuzzle? SelectProblem(int yearInput, int puzzleInput) {

			var puzzle = GetPuzzle(yearInput, puzzleInput) ?? throw new Exception("Puzzle Not Found");

			var puzzleInstance = (IPuzzle?)Activator.CreateInstance(puzzle) ?? throw new Exception("Puzzle Not Found");
			puzzleInstance.Year = yearInput;
			puzzleInstance.Puzzle = puzzleInput;

			return puzzleInstance;
		}

		public static string[] GetYears() {
			List<Type> puzzles = GetPuzzles();

			var years = puzzles.Select(x => int.Parse(x.FullName.Split('.')[2].Replace("_", "")))
							   .Distinct()
							   .OrderByDescending(x => x)
							   .Select(x => x.ToString())
							   .ToArray() ?? throw new Exception("Puzzle Not Found");

			return years;
		}

		public static string[] GetProblemsOfYear(int year) {
			List<Type> puzzles = GetPuzzles();

			puzzles = puzzles.Where(x => x.FullName.Contains(year.ToString())).ToList();

			var problems = puzzles.Select(x => {
				var name = x.FullName.Split('.')[^2];
				var number = name.Split("Problem")[1];
				var finalname = "Problem " + number;
				return finalname;
			}).Distinct()
			  .OrderBy(x => x)
			  .Select(x => x.ToString())
			  .ToArray() ?? throw new Exception("Puzzle Not Found");

			return problems;
		}

		private static Type? GetPuzzle(int yearInput, int puzzleInput) {
			Type? puzzle = null;

			var puzzles = GetPuzzles();

			var number = (puzzleInput <= 9 ? "0" : "") + puzzleInput;

			puzzles = puzzles.Where(x => x.FullName.Contains(yearInput.ToString()) && x.FullName.Contains(number + ".")).ToList();

			if (puzzles.Count == 1) {
				puzzle = puzzles[0];
			} else {
				throw new Exception($"Multiples Puzzles to Puzzle {puzzleInput} of the year {yearInput}");
			}

			return puzzle;
		}

		private static List<Type> GetPuzzles() {
			List<Type> puzzles = new();
			Type[] types = typeof(Program).Assembly.GetTypes();

			types = types.Where(x => x.FullName.Contains("AOC") && !x.FullName.Contains("IPuzzle")).ToArray();

			foreach (Type type in types) {
				if (!type.IsNestedPrivate && typeof(IPuzzle).IsAssignableFrom(type)) {
					puzzles.Add(type);
				}
			}

			return puzzles;
		}
	}
}
