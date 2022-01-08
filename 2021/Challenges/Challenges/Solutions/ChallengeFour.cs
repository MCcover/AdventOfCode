using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Interfaces;
using Challenges.Utils;

namespace Challenges.Solutions {

	internal class ChallengeFour : IResolveChallenge {
		private const int NUMBER = 4;

		public static string? Resolve() {
			var bingo = InputFile.GetTextFile(NUMBER).Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

			int[] numbers = bingo[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			bingo.RemoveAt(0);

			List<Bingo> bingos = new();

			bingo.ForEach(table => bingos.Add(new Bingo(table)));

			List<(Bingo bingo, int lastNumber)> finished = ResolveAll(numbers, bingos);

			string result = "Part One: " + ResolvePartOne(finished) + "\n";
			result += "\t\t    Part Two: " + ResolvePartTwo(finished);
			return result;
		}

		public static string ResolvePartOne(List<(Bingo bingo, int lastNumber)> finished) => (finished[0].bingo.GetSumUnMarked() * finished[0].lastNumber).ToString();

		public static string ResolvePartTwo(List<(Bingo bingo, int lastNumber)> finished) => (finished[^1].bingo.GetSumUnMarked() * finished[^1].lastNumber).ToString();

		private static List<(Bingo bingo, int lastNumber)> ResolveAll(int[] numbers, List<Bingo> bingos) {
			List<(Bingo bingo, int lastNumber)> finished = new();
			foreach (var number in numbers) {
				foreach (var bingo in bingos) {
					bingo.MarkAllMatchs(number);
					if (!bingo.Complete && bingo.IsBingoSolved()) {
						bingo.Complete = true;
						finished.Add((bingo, number));
					}
				}
			}
			return finished;
		}

		#region Representation

		internal class Bingo {
			public NumbersBingo[,] Numbers { get; set; }
			public bool Complete { get; set; }

			public Bingo(string bingo) {
				string[] lines = bingo.Split("\n");

				Numbers = new NumbersBingo[lines.Length, lines.Length];
				for (int i = 0; i < lines.Length; i++) {
					string[] columns = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
					for (int j = 0; j < lines.Length; j++) {
						Numbers[i, j] = new NumbersBingo(int.Parse(columns[j]), false);
					}
				}
			}

			public void MarkAllMatchs(int number) {
				if (!Complete) {
					int rows = Numbers.GetUpperBound(0);
					int columns = Numbers.GetUpperBound(1);
					for (int row = 0; row <= rows; row++) {
						for (int column = 0; column <= columns; column++) {
							if (Numbers[row, column].Number == number) {
								Numbers[row, column].Marked = true;
							}
						}
					}
				}
			}

			public bool IsBingoSolved() {
				int rows = Numbers.GetUpperBound(0);
				int columns = Numbers.GetUpperBound(1);

				for (int row = 0; row <= rows; row++) {
					int marketRowCount = 0;
					int marketColumnCount = 0;
					for (int column = 0; column <= columns; column++) {
						bool IsRowComplete = IsBingo(row, column, ref marketRowCount, rows);
						bool IsColumnComplete = IsBingo(column, row, ref marketColumnCount, columns);

						if (IsRowComplete || IsColumnComplete) {
							return true;
						}
					}
				}
				return false;
			}

			public int GetSumUnMarked() {
				int sumUnMarked = 0;
				for (int i = 0; i <= Numbers.GetUpperBound(0); i++) {
					for (int j = 0; j <= Numbers.GetUpperBound(1); j++) {
						if (!Numbers[i, j].Marked) {
							sumUnMarked += Numbers[i, j].Number;
						}
					}
				}
				return sumUnMarked;
			}

			private bool IsBingo(int a, int b, ref int markedCount, int lenght) {
				if (Numbers[a, b].Marked) {
					markedCount++;
					if (markedCount == lenght + 1) {
						return true;
					}
				}
				return false;
			}
		}

		internal class NumbersBingo {
			public int Number { get; set; }
			public bool Marked { get; set; }

			public NumbersBingo(int number, bool marked) {
				Number = number;
				Marked = marked;
			}
		}

		#endregion Representation
	}
}