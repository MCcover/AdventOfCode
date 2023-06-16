using AOC.Helpers;
using AOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Classes {
	public abstract class PuzzleBase : IPuzzle {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public void Solve() {
			var partOne = ExecuteSolve(SolvePartOne);
			Console.WriteLine("Part One: " + partOne.result);
			ConsoleHelper.WriteTime(new TimeSpan(partOne.elapsed), ConsoleColor.White);

			Console.WriteLine();

			var partTwo = ExecuteSolve(SolvePartTwo);
			Console.WriteLine("Part Two: " + partTwo.result);
			ConsoleHelper.WriteTime(new TimeSpan(partTwo.elapsed), ConsoleColor.White);

			Console.WriteLine();

			ConsoleHelper.WriteTime(new TimeSpan(partOne.elapsed + partTwo.elapsed), ConsoleColor.White, "Total Time Elapsed: ");
		}

		public abstract string SolvePartOne();

		public abstract string SolvePartTwo();

		private (long elapsed, string result) ExecuteSolve(Func<string> func) {
			var sw = new Stopwatch();
			sw.Start();
			var result = func.Invoke();
			sw.Stop();

			return (sw.ElapsedTicks, result);
		}
	}
}
