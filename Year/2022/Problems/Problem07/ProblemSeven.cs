using AOC.Helpers;
using AOC.Interfaces;
using System.Text.RegularExpressions;

namespace AOC.Year._2022.Problems.Problem07 {

	public class ProblemSeven : IPuzzle, IReadTest<List<int>> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public string SolvePartOne() {
			return ReadTests().Where(size => size < 100000)
							  .Sum()
							  .ToString();
		}

		public string SolvePartTwo() {
			var sizes = ReadTests();
			return sizes.Where(size => size + (70000000 - sizes.Max()) >= 30000000)
						.Min()
						.ToString();
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public List<int> ReadTests() {
			var path = new Stack<string>();
			var sizes = new Dictionary<string, int>();

			var lines = FileHelper.GetFileAllLines(Year, Puzzle);

			foreach (var line in lines) {
				if (line == "$ cd ..") {
					path.Pop();
				} else if (line.StartsWith("$ cd")) {
					var size = line.Split(" ")[2];
					var newDirectory = string.Join("", path) + size;
					path.Push(newDirectory);
				} else if (Regex.Match(line, @"\d+").Success) {
					var size = int.Parse(line.Split(" ")[0]);
					foreach (var dir in path) {
						sizes[dir] = sizes.GetValueOrDefault(dir) + size;
					}
				}
			}

			return sizes.Values.ToList();
		}
	}
}