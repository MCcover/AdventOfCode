

using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem04 {
	public class ProblemFour : IPuzzle, IReadTest<string[]> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public string SolvePartOne() {
			var count = 0;

			var lines = ReadTests();

			foreach (var line in lines) {
				var elfs = line.Split(',');
				var elfOne = elfs[0];
				var elfTwo = elfs[1];

				var rangeElfOne = elfs[0].Split('-');
				var initElfOne = int.Parse(rangeElfOne[0]);
				var endElfOne = int.Parse(rangeElfOne[1]);

				var rangeElfTwo = elfs[1].Split('-');
				var initElfTwo = int.Parse(rangeElfTwo[0]);
				var endElfTwo = int.Parse(rangeElfTwo[1]);

				var rengeOneContainsRangeTwo = initElfTwo >= initElfOne && endElfTwo <= endElfOne;
				var RangeTwoContainsrengeOne = initElfOne >= initElfTwo && endElfOne <= endElfTwo;

				if (rengeOneContainsRangeTwo || RangeTwoContainsrengeOne) {
					count++;
				}

			}

			return count.ToString();
		}

		public string SolvePartTwo() {
			var count = 0;

			var lines = ReadTests();

			foreach (var line in lines) {
				var elfs = line.Split(',');
				var elfOne = elfs[0];
				var elfTwo = elfs[1];

				var rangeElfOne = elfs[0].Split('-');
				var initElfOne = int.Parse(rangeElfOne[0]);
				var endElfOne = int.Parse(rangeElfOne[1]);

				var rangeElfTwo = elfs[1].Split('-');
				var initElfTwo = int.Parse(rangeElfTwo[0]);
				var endElfTwo = int.Parse(rangeElfTwo[1]);

				if (initElfOne <= endElfTwo && endElfOne >= initElfTwo) {
					count++;
				}

			}

			return count.ToString();
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public string[] ReadTests() {
			return FileHelper.GetFileText(Year, Puzzle);
		}
	}
}
