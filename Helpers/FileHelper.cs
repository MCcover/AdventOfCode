namespace AOC.Helpers {
	public static class FileHelper {

		private static string GetFilePath(int year, int puzzle) {
			return $"../../../Year/{year}/Problems/Problem{(puzzle <= 9 ? "0" : "") + puzzle}/Test.txt";
		}

		public static string[] GetFileAllLines(int year, int puzzle) {
			return File.ReadAllLines(GetFilePath(year, puzzle));
		}

		public static string GetFileText(int year, int puzzle) {
			return File.ReadAllText(GetFilePath(year, puzzle));
		}

	}
}
