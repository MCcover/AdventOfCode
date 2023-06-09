

using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem01 {
	public class ProblemOne : IPuzzle, IReadTest<List<List<int>>> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public string SolvePartOne() {
			var data = ReadTests();

			var higher = 0;

			foreach (var item in data) {
				var sum = item.Sum();

				if (sum > higher) {
					higher = sum;
				}
			}

			return higher.ToString();
		}

		public string SolvePartTwo() {
			var data = ReadTests();

			var sums = new List<int>();


			foreach (var item in data) {
				sums.Add(item.Sum());
			}

			var sum = sums.OrderByDescending(x => x).Take(3).Sum();

			return sum.ToString();
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public List<List<int>> ReadTests() {
			var list = new List<List<int>>();
			var listTwo = new List<int>();

			var lines = FileHelper.GetFileText(Year, Puzzle);

			var count = 1;
			foreach (var line in lines) {
				if (line == string.Empty) {
					count++;
					list.Add(listTwo);
					listTwo = new List<int>();
				} else {
					var value = int.Parse(line);
					listTwo.Add(value);
				}
			}

			if (listTwo.Count > 0) {
				list.Add(listTwo);
			}

			return list;
		}
	}
}
