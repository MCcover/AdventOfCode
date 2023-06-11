

using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem03 {
	public class ProblemThree : IPuzzle, IReadTest<string[]> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public string SolvePartOne() {
			var sum = 0;
			var lines = ReadTests();

			foreach (var line in lines) {
				var mid = line.Length / 2;
				var rightSide = line[..(mid)];
				var leftSide = line[(mid)..];

				foreach (var item in leftSide) {
					if (rightSide.Contains(item)) {
						sum += item > 96 ? item - 96 : item - 64 + 26;
						break;
					}
				}

			}

			return sum.ToString();
		}

		public string SolvePartTwo() {
			var sum = 0;
			var lines = ReadTests();

			var parts = lines.Split(3);

			foreach (var part in parts) {
				var elfOne = part[0];
				var elfTwo = part[1];
				var elfThree = part[2];

				var inter = elfOne.Intersect(elfTwo).Intersect(elfThree).Single();

				sum += inter > 96 ? inter - 96 : inter - 64 + 26;
			}

			return sum.ToString();
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public string[] ReadTests() {
			return FileHelper.GetFileAllLines(Year, Puzzle);
		}
	}
}
