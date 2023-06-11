namespace AOC.Helpers {
	public static class ListHelper {

		public static List<List<T>> Split<T>(this List<T> source, int chunksize) {
			return source.Select((x, i) => new { Index = i, Value = x })
						 .GroupBy(x => x.Index / chunksize)
						 .Select(x => x.Select(v => v.Value).ToList())
						 .ToList();
		}

		public static List<List<T>> Split<T>(this T[] source, int chunksize) => Split(source.ToList(), chunksize).ToList();
	}
}
