using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Interfaces;
using Challenges.Utils;

namespace Challenges.Solutions {

	internal class ChallengeThree : IResolveChallenge {
		private const int NUMBER = 3;

		public static string? Resolve() {
			string[] reports = InputFile.GetTextFile(NUMBER).Split(Environment.NewLine);

			string result = "Part One: " + ResolvePartOne(reports) + "\n";
			result += "\t\t    Part Two: " + ResolvePartTwo(reports);
			return result;
		}

		private static string ResolvePartOne(string[] reports) {
			var gammaValue = string.Empty;
			var epsilonValue = string.Empty;

			for (int i = 0; i < reports[0].Length; i++) {
				var zeroes = 0;
				var ones = 0;

				foreach (var report in reports) {
					if (report[reports[0].Length - 1 - i] == '0') {
						zeroes++;
					} else {
						ones++;
					}
				}

				if (zeroes > ones) {
					gammaValue = "0" + gammaValue;
					epsilonValue = "1" + epsilonValue;
				} else if (zeroes < ones) {
					gammaValue = "1" + gammaValue;
					epsilonValue = "0" + epsilonValue;
				}
			}

			int gammaRate = Convert.ToInt32(gammaValue, 2);
			int epsilonRate = Convert.ToInt32(epsilonValue, 2);
			int powerConsuption = gammaRate * epsilonRate;

			return powerConsuption.ToString();
		}

		private static string ResolvePartTwo(string[] reports) {
			var currentSet = reports.ToList();

			int oxigenRating = 0;
			int co2Rating = 0;
			for (int i = 0; i < reports[0].Length; i++) {
				var zeroes = 0;
				var ones = 0;
				var teamZero = new List<string>();
				var teamOne = new List<string>();

				foreach (var report in currentSet) {
					if (report[i] == '0') {
						zeroes++;
						teamZero.Add(report);
					} else {
						ones++;
						teamOne.Add(report);
					}
				}

				if (zeroes > ones) {
					currentSet = teamZero;
				} else if (zeroes < ones) {
					currentSet = teamOne;
				} else {
					currentSet = teamOne;
				}

				if (currentSet.Count == 1) {
					oxigenRating = Convert.ToInt32(currentSet[0], 2);
					break;
				}
			}

			currentSet = reports.ToList();

			for (int i = 0; i < reports[0].Length; i++) {
				var zeroes = 0;
				var ones = 0;
				var teamZero = new List<string>();
				var teamOne = new List<string>();

				foreach (var value in currentSet) {
					if (value[i] == '0') {
						zeroes++;
						teamZero.Add(value);
					} else {
						ones++;
						teamOne.Add(value);
					}
				}

				if (zeroes < ones) {
					currentSet = teamZero;
				} else if (zeroes > ones) {
					currentSet = teamOne;
				} else {
					currentSet = teamZero;
				}

				if (currentSet.Count == 1) {
					co2Rating = Convert.ToInt32(currentSet[0], 2);
					break;
				}
			}

			return (oxigenRating * co2Rating).ToString();
		}
	}
}