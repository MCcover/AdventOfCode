using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Helpers {
	public static class FileHelper {

		public static string[] GetFileText(int year, int puzzle) {
			return File.ReadAllLines($"../../../Year/{year}/Problems/Problem{(puzzle <= 9 ? "0" : "") + puzzle}/Test.txt");
		}

	}
}
