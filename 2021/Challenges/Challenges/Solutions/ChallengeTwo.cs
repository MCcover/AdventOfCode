using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Interfaces;
using Challenges.Utils;

namespace Challenges.Solutions {

	internal class ChallengeTwo : IResolveChallenge {
		private const int NUMBER = 2;

		public static string Resolve() {
			var instructions = InputFile.GetTextFile(NUMBER).Split(Environment.NewLine).Select(x => x.Split(' ')).Select(x => (x[0], int.Parse(x[1]))).ToList();
			string result = ResolvePartOne(instructions);
			result += ResolvePartTwo(instructions);
			return result;
		}

		private static string ResolvePartOne(List<(string, int)> instructions) {
			int result = 0;

			int horizontalPosition = 0;
			int depth = 0;

			instructions.ForEach(x => {
				switch (x.Item1) {
					case "forward":
						horizontalPosition += x.Item2;
						break;

					case "down":
						depth += x.Item2;
						break;

					case "up":
						depth -= x.Item2;
						break;
				}
			});

			result = horizontalPosition * depth;

			return "Part One: " + result.ToString() + "\n";
		}

		private static string ResolvePartTwo(List<(string, int)> instructions) {
			int result = 0;
			int horizontalPosition = 0;
			int depth = 0;
			int aim = 0;

			instructions.ForEach(x => {
				switch (x.Item1) {
					case "forward":
						horizontalPosition += x.Item2;
						depth += aim * x.Item2;
						break;

					case "down":
						aim += x.Item2;
						break;

					case "up":
						aim -= x.Item2;
						break;
				}
			});
			result = horizontalPosition * depth;
			return "\t\t    Part Two: " + result.ToString();
		}
	}
}