using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Interfaces;
using Challenges.Utils;

namespace Challenges.Solutions {

	internal class ChallengeOne : IResolveChallenge {
		private const int NUMBER = 1;

		public static string Resolve() {
			string result = string.Empty;

			var depths = InputFile.GetTextFile(NUMBER).Split(Environment.NewLine).Select(x => int.Parse(x)).ToList();

			result = ResolvePartOne(depths);
			result += ResolvePartTwo(depths);
			return result;
		}

		private static string ResolvePartOne(List<int> depths) {
			int result = 0;

			for (int i = 1; i < depths.Count; i++) {
				if (depths[i] > depths[i - 1]) {
					result++;
				}
			}

			return "Part One: " + result.ToString() + "\n";
		}

		private static string ResolvePartTwo(List<int> depths) {
			int result = 0;

			for (int i = 3; i < depths.Count; i++) {
				int previous = depths[i - 3] + depths[i - 2] + depths[i - 1];
				int next = depths[i - 2] + depths[i - 1] + depths[i];
				if (next > previous) {
					result++;
				}
			}

			return "\t\t    Part Two: " + result.ToString() + "\n";
		}
	}
}