using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Helpers {
	public static class ConsoleHelper {

		public static void WriteLineWithColor(string text, ConsoleColor color, ConsoleColor baseColor) {
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = baseColor;
		}

		public static void WriteTime(TimeSpan time, ConsoleColor baseColor, string baseText = "") {
			var t = time.Ticks / 100;
			ConsoleColor cc;
			if (t >= 200000) {
				cc = ConsoleColor.Red;
			} else if (t >= 50000) {
				cc = ConsoleColor.Yellow;
			} else {
				cc = ConsoleColor.Green;
			}

			var text = baseText.Trim() + (baseText.Trim().Length > 0 ? " " : "") + $"({(time.Minutes != 0 ? time.Minutes + " Minutes " : "")}{(time.Seconds != 0 ? time.Seconds + " Seconds " : "")}{time.Milliseconds} Miliseconds)";

			WriteLineWithColor(text, cc, baseColor);
		}

	}
}
