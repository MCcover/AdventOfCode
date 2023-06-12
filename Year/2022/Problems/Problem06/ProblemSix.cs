

using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem06 {
	public class ProblemSix : IPuzzle, IReadTest<string> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		private const int SIZE_CHUNK_PACKAGE = 4;
		private const int SIZE_CHUNK_MESSAGE = 14;

		public string SolvePartOne() {
			var text = ReadTests();

			return FindPosition(text, SIZE_CHUNK_PACKAGE);
		}


		public string SolvePartTwo() {
			var text = ReadTests();

			return FindPosition(text, SIZE_CHUNK_MESSAGE);
		}

		private string FindPosition(string text, int chunkSize) {
			int pos = 0;
			bool found = false;

			while (text.Length > 0 && !found) {
				var chars = new HashSet<char>();

				for (int i = 0; i < chunkSize; i++) {
					chars.Add(text[i]);
				}

				if (chars.Count == chunkSize) {
					found = true;
					pos += chunkSize;
				} else {
					pos++;
					text = text.Remove(0, 1);
				}
			}

			return pos.ToString();
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public string ReadTests() {
			return FileHelper.GetFileText(Year, Puzzle);
		}
	}
}
