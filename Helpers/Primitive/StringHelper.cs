namespace AOC.Helpers {
	public static class StringHelper {

		public static Dictionary<int, List<T>> SplitInColumns<T>(this string text, int columnSize, int quantityColumns, bool removeLastLine = false) {
			var lines = text.Split(Environment.NewLine).ToList();

			if (removeLastLine) {
				lines.RemoveAt(lines.Count - 1);
			}

			var columns = new Dictionary<int, List<T>>();

			foreach (var line in lines) {

				var column = line.GetChunks(columnSize);

				for (int i = 0; i < column.Count; i++) {
					var itemColumn = column[i];
					var value = itemColumn.Trim().Replace("[", "").Replace("]", "");
					if (value != string.Empty) {
						var columnIndex = i + 1;
						if (!columns.ContainsKey(columnIndex)) {
							columns.Add(columnIndex, new List<T>());
						}
						columns[columnIndex].Add((T)Convert.ChangeType(value, typeof(T)));
					}
				}
			}
			return columns;
		}

		public static List<string> GetChunks(this string value, int chunkSize) {
			List<string> triplets = new();
			for (int i = 0; i < value.Length; i += chunkSize)
				if (i + chunkSize > value.Length)
					triplets.Add(value[i..]);
				else
					triplets.Add(value.Substring(i, chunkSize));

			return triplets;
		}
	}
}
