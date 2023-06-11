

using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem02 {
	public class ProblemTwo : IPuzzle, IReadTest<string[]> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		enum RPS {
			Rock,
			Paper,
			Scissors
		}

		enum ResultsRounds {
			Defeat,
			Draw,
			Win
		}

		private Dictionary<string, RPS> _Guide = new() {
			//Oponent
			{ "A", RPS.Rock },
			{ "B", RPS.Paper },
			{ "C", RPS.Scissors },
			//Me
			{ "X", RPS.Rock },
			{ "Y", RPS.Paper },
			{ "Z", RPS.Scissors },
		};

		private Dictionary<RPS, int> _TypePoints = new() {
			{ RPS.Rock, 1},
			{ RPS.Paper, 2},
			{ RPS.Scissors, 3}
		};

		private Dictionary<ResultsRounds, int> _RoundPoints = new() {
			{ ResultsRounds.Defeat, 0},
			{ ResultsRounds.Draw, 3},
			{ ResultsRounds.Win, 6}
		};

		private Dictionary<string, ResultsRounds> _ExpectedEnd = new() {
			{ "X", ResultsRounds.Defeat },
			{ "Y", ResultsRounds.Draw },
			{ "Z", ResultsRounds.Win },
		};

		private Dictionary<ResultsRounds, Dictionary<RPS, RPS>> _WitchSelect = new() {
			{ ResultsRounds.Defeat, new() {
					{ RPS.Rock, RPS.Scissors },
					{ RPS.Scissors, RPS.Paper },
					{ RPS.Paper, RPS.Rock },
				}
			},

			{ ResultsRounds.Win, new() {
					{ RPS.Rock, RPS.Paper },
					{ RPS.Scissors, RPS.Rock },
					{ RPS.Paper, RPS.Scissors },
				}
			},

			{ ResultsRounds.Draw, new() {
					{ RPS.Rock, RPS.Rock},
					{ RPS.Scissors, RPS.Scissors},
					{ RPS.Paper, RPS.Paper},
				}
			},
		};

		public string SolvePartOne() {
			var points = 0;

			var lines = ReadTests();

			foreach (var line in lines) {
				var inputs = line.Split(' ');

				var oponent = _Guide[inputs[0]];
				var me = _Guide[inputs[1]];

				ResultsRounds myStatus = ResultsRounds.Win;

				if (oponent == RPS.Rock && me == RPS.Scissors ||
					oponent == RPS.Scissors && me == RPS.Paper ||
					oponent == RPS.Paper && me == RPS.Rock) {
					myStatus = ResultsRounds.Defeat;
				} else if (oponent == me) {
					myStatus = ResultsRounds.Draw;
				}

				points += _TypePoints[me] + _RoundPoints[myStatus];
			}

			return points.ToString();
		}

		public string SolvePartTwo() {
			var points = 0;

			var lines = ReadTests();

			foreach (var line in lines) {
				var inputs = line.Split(' ');

				var oponent = _Guide[inputs[0]];

				var expectedEnd = _ExpectedEnd[inputs[1]];

				var me = _WitchSelect[expectedEnd][oponent];

				points += _TypePoints[me] + _RoundPoints[expectedEnd];
			}

			return points.ToString();
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
