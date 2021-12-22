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

			string result = "Part One: " + ResolvePartOne(numbers, bingos) + "\n";
			result += "\t\t    Part Two: " + ResolvePartTwo(numbers, bingos);
			return result;
		}

		public static string ResolvePartOne(int[] numbers, List<Bingo> bingos) {
			foreach (var output in numbers) {
				foreach (var bingo in bingos) {
					bingo.MarkAllMatchs(output);
					if (bingo.IsBingoSolved()) {
						int sumUnMarked = bingo.GetSumUnMarked();
						return (sumUnMarked * output).ToString();
					}
				}
			}

			return 0.ToString();
		}

		public static string ResolvePartTwo(int[] numbers, List<Bingo> bingos) {
			List<(Bingo, int)> finished = new();
			foreach (var number in numbers) {
				foreach (var bingo in bingos) {
					if (!bingo.Complete) {
						bingo.MarkAllMatchs(number);
						if (!bingo.Complete && bingo.IsBingoSolved()) {
							bingo.Complete = true;
							finished.Add((bingo, number));
						}
					}
				}
			}

			return (finished[^1].Item1.GetSumUnMarked() * finished[^1].Item2).ToString();
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
					for (int i = 0; i < Numbers.GetUpperBound(0); i++) {
						for (int j = 0; j < Numbers.GetUpperBound(1); j++) {
							if (Numbers[i, j].Number == number) {
								Numbers[i, j].Marked = true;
							}
						}
					}
				}
			}

			public bool IsBingoSolved() {
				bool bingoFound = false;
				for (int a = 0; a <= 4; a++) {
					int marked = 0;
					for (int b = 0; b <= 4; b++) {
						if (Numbers[a, b].Marked) {
							marked++;
						}
					}
					if (marked == 5) {
						bingoFound = true;
						break;
					}
				}

				if (bingoFound) {
					return bingoFound;
				}

				// check columns
				for (int a = 0; a <= 4; a++) {
					int marked = 0;
					for (int b = 0; b <= 4; b++) {
						if (Numbers[b, a].Marked) {
							marked++;
						}
					}
					if (marked == 5) {
						bingoFound = true;
						break;
					}
				}
				if (bingoFound) {
					return bingoFound;
				}
				return bingoFound;
			}

			public int GetSumUnMarked() {
				int sumUnMarked = 0;
				for (int i = 0; i < Numbers.GetUpperBound(0); i++) {
					for (int j = 0; j < Numbers.GetUpperBound(1); j++) {
						if (!Numbers[i, j].Marked) {
							sumUnMarked += Numbers[i, j].Number;
						}
					}
				}
				return sumUnMarked;
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