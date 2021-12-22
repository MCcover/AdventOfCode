using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges {

	public static class T {

		public static void Test() {
			List<string>? data = null;
			List<BingoBoard>? boards = new();

			try {
				using (var sr = new StreamReader(@"C:\FUENTES\AdventOfCode\2021\Inputs\4.txt")) {
					data = sr.ReadToEnd().Split($"\n\n", StringSplitOptions.RemoveEmptyEntries).ToList();
				}
			} catch (Exception ex) {
				Console.WriteLine("Error in importing input file:");
				Console.WriteLine(ex.Message);
			}

			int[] numbers = data[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			data.RemoveAt(0); // remove numbers

			foreach (var d in data) {
				string[] rows = d.Split("\n");
				int[,] tempBoard = new int[5, 5];
				for (int i = 0; i < rows.Length; i++) {
					string[] columns = rows[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
					for (int j = 0; j < columns.Length; j++)
						tempBoard[i, j] = int.Parse(columns[j]);
				}
				boards.Add(new BingoBoard(tempBoard));
			}

			List<BingoBoard>? ranked = new();

			foreach (int n in numbers) {
				foreach (var b in boards) {
					b.RegisterNumber(n);

					if (!b.Finished && b.GotBingo()) {
						b.Finished = true;
						b.WinningNumber = n;
						ranked.Add(b);
					}
				}
			}

			ranked[0].PrintBoard(fullDisplay: true);
			Console.WriteLine("Part One.");
			Console.WriteLine($"The winning number was {ranked[0].WinningNumber} and the sum is {ranked[0].GetSumUnMarked()}.");
			Console.WriteLine("The winning board has {0} as the final score.", ranked[0].GetSumUnMarked() * ranked[0].WinningNumber);
			Console.WriteLine();
			ranked[ranked.Count - 1].PrintBoard(fullDisplay: true);
			Console.WriteLine("Part Two.");
			Console.WriteLine($"The last winning board has {ranked[ranked.Count - 1].WinningNumber} as the winning number and the sum is {ranked[ranked.Count - 1].GetSumUnMarked()}.");
			Console.WriteLine("The final board has the final score: {0}", ranked[ranked.Count - 1].WinningNumber * ranked[ranked.Count - 1].GetSumUnMarked());
		}

		public class BingoBoard {
			private static int counter = 0;

			private int[,] BoardOriginal { get; set; }
			private int[,] Board { get; set; }
			public int BoardId { get; set; }
			public int WinningNumber { get; set; } = -1;
			public bool Finished { get; set; } = false;

			public BingoBoard(int[,] boardNumbers) {
				Interlocked.Increment(ref counter);
				Board = boardNumbers;
				BoardOriginal = (int[,])boardNumbers.Clone(); // keep the original board numbers
				BoardId = counter;
			}

			public void RegisterNumber(int n) {
				if (!Finished) {
					for (int a = 0; a <= 4; a++) {
						for (int b = 0; b <= 4; b++) {
							if (Board[a, b] == n) {
								Board[a, b] = -1;
							}
						}
					}
				}
			}

			public bool GotBingo() {
				// check rows
				bool bingoFound = false;
				for (int a = 0; a <= 4; a++) {
					int marked = 0;
					for (int b = 0; b <= 4; b++) {
						if (Board[a, b] == -1) {
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
						if (Board[b, a] == -1) {
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
				int total = 0;
				int bound0 = Board.GetUpperBound(0);
				int bound1 = Board.GetUpperBound(1);
				for (int a = 0; a <= bound0; a++) {
					for (int b = 0; b <= bound1; b++) {
						if (Board[a, b] > -1) {
							total = total + Board[a, b];
						}
					}
				}
				return total;
			}

			public void PrintBoard(bool fullDisplay = false) {
				int bound0 = Board.GetUpperBound(0);
				int bound1 = Board.GetUpperBound(1);

				Console.WriteLine($"-- Board {BoardId} -------");
				for (int a = 0; a <= bound0; a++) {
					for (int b = 0; b <= bound1; b++) {
						Console.Write($"{Board[a, b],3}");
					}
					Console.Write("\n");
				}
				if (fullDisplay) {
					Console.WriteLine("-- Original -------");
					for (int a = 0; a <= bound0; a++) {
						for (int b = 0; b <= bound1; b++) {
							Console.Write($"{BoardOriginal[a, b],3}");
						}
						Console.Write("\n");
					}
				}
				Console.WriteLine("-------------------");
			}
		}
	}
}