using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Utils {

	internal static class InputFile {
		private const string PATH_INPUTS = @"C:\FUENTES\AdventOfCode\2021\Inputs\{0}.txt";

		internal static string GetTextFile(int challenge) {
			string text = string.Empty;
			try {
				text = File.ReadAllText(string.Format(PATH_INPUTS, challenge));
			} catch {
			}

			return text;
		}
	}
}