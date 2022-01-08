using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.Interfaces;
using Challenges.Utils;

namespace Challenges.Solutions {

	internal class ChallengeFive : IResolveChallenge {
		private const int NUMBER = 5;

		public static string? Resolve() {
			var points = InputFile.GetTextFile(NUMBER)
								  .Split(Environment.NewLine)
								  .Select(point => {
									  var points = point.Split("->");

									  var p1 = points[0].Split(",").Select(int.Parse).ToArray();
									  var p2 = points[1].Split(",").Select(int.Parse).ToArray();

									  Point start = new(p1[0], p1[1]);
									  Point end = new(p2[0], p2[1]);

									  return (start, end);
								  }).ToList();

			foreach (var point in points) {
			}

			throw new NotImplementedException("Challenge no solved");
		}
	}
}