using AOC.Classes;
using AOC.Helpers;
using AOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Year._2022.Problems.Problem09 {
	public class ProblemNine : PuzzleBase, IReadTest<string[]> {

		public override string SolvePartOne() => GetTotalPositions(ReadTests(), 2).ToString();

		public override string SolvePartTwo() => GetTotalPositions(ReadTests(), 10).ToString();

		public string[] ReadTests() => FileHelper.GetFileAllLines(Year, Puzzle);

		private int GetTotalPositions(string[] lines, int knots) {
			HashSet<(int x, int y)> positions = new();

			(int x, int y)[] rope = new (int, int)[knots];

			foreach (var line in lines) {
				int count = int.Parse(line[2..]);

				(int moveX, int moveY) = GetDirection(line[0]);

				while (count-- > 0) {
					rope[0] = (rope[0].x + moveX, rope[0].y + moveY);

					for (int i = 1; i < rope.Length; i++) {
						int distanceX = Math.Abs(rope[i - 1].x - rope[i].x);
						int distanceY = Math.Abs(rope[i - 1].y - rope[i].y);

						if (distanceX > 1 || distanceY > 1) {
							rope[i] = (rope[i].x + Math.Sign(distanceX), 
									   rope[i].y + Math.Sign(distanceY));
						}
					}
					positions.Add(rope[^1]);
				}
			}

			return positions.Count;
		}

		private (int moveX, int moveY) GetDirection(char type) {
			return type switch {
				'R' => (1, 0),
				'L' => (-1, 0),
				'U' => (0, 1),
				'D' => (0, -1),
				_ => throw new NotImplementedException(),
			};
		}

	}
}
