using AOC.Classes;
using AOC.Helpers;
using AOC.Interfaces;
using AOC.Year._2022.Problems.Problem05;
using System.Runtime.CompilerServices;

namespace AOC.Year._2022.Problems.Problem08 {
	public class ProblemEight : PuzzleBase, IReadTest<int[,]> {

		public override string SolvePartOne() {
			var data = ReadTests();

			var rowQnt = data.GetLength(0);
			var columnQnt = data.GetLength(1);

			var treesVisibles = ((rowQnt - 2) * 2) + ((columnQnt - 2) * 2) + 4;

			for (int rowIndex = 1; rowIndex < rowQnt - 1; rowIndex++) {
				for (int columnIndex = 1; columnIndex < columnQnt - 1; columnIndex++) {
					if (TreeIsVisible(rowIndex, columnIndex, data)) {
						treesVisibles++;
					}
				}
			}

			return treesVisibles.ToString();
		}

		public override string SolvePartTwo() {
			var data = ReadTests();

			var viewDistance = 0;

			var rowQnt = data.GetLength(0);
			var columnQnt = data.GetLength(1);

			for (int rowIndex = 0; rowIndex < rowQnt ; rowIndex++) {
				for (int columnIndex = 0; columnIndex < columnQnt; columnIndex++) {
					var visibility = TreeVisibility(rowIndex, columnIndex, data);
					if (viewDistance < visibility) {
						viewDistance = visibility;
					}
				}
			}

			return viewDistance.ToString();
		}

		public int[,] ReadTests() {
			var lines = FileHelper.GetFileAllLines(Year, Puzzle);

			var columnsQnt = lines[0].Length;
			var rowsQnt = lines.Length;

			int[,] result = new int[rowsQnt, columnsQnt];

			for (int i = 0; i < rowsQnt; i++) {
				var trees = lines[i].GetChunks(1);
				for (int j = 0; j < trees.Count; j++) {
					result[i,j] = int.Parse(trees[j]);

				}
			}
			return result;
		}

		#region Tree Visible

		private static bool TreeIsVisible(int rowIndex, int columnIndex, int[,] data) {
			bool isVisible = CheckIfIsVisibleFromTop(rowIndex, columnIndex, data);

			if (!isVisible) {
				isVisible = CheckIfIsVisibleFromRight(rowIndex, columnIndex, data);
			}

			if (!isVisible) {
				isVisible = CheckIfIsVisibleFromBottom(rowIndex, columnIndex, data);
			}

			if (!isVisible) {
				isVisible = CheckIfIsVisibleFromLeft(rowIndex, columnIndex, data);
			}

			return isVisible;
		}

		private static bool CheckIfIsVisibleFromTop(int rowIndex, int columnIndex, int[,] data) {
			bool isVisible = true;

			var value = data[rowIndex, columnIndex];

			var i = rowIndex - 1;

			do {
				isVisible = data[i, columnIndex] < value;
				i--;
			} while (isVisible && i >= 0);

			return isVisible;
		}

		private static bool CheckIfIsVisibleFromRight(int rowIndex, int columnIndex, int[,] data) {
			bool isVisible = true;

			var value = data[rowIndex, columnIndex];
			var i = columnIndex + 1;

			do {
				isVisible = data[rowIndex, i] < value;
				i++;
			} while (isVisible && i < data.GetLength(1));

			return isVisible;
		}

		private static bool CheckIfIsVisibleFromBottom(int rowIndex, int columnIndex, int[,] data) {
			bool isVisible = true;

			var value = data[rowIndex, columnIndex];

			var i = rowIndex + 1;

			do {
				isVisible = data[i, columnIndex] < value;
				i++;
			} while (isVisible && i < data.GetLength(0));

			return isVisible;
		}

		private static bool CheckIfIsVisibleFromLeft(int rowIndex, int columnIndex, int[,] data) {
			bool isVisible = true;

			var value = data[rowIndex, columnIndex];

			var i = columnIndex - 1;

			do {
				isVisible = data[rowIndex, i] < value;
				i--;
			} while (isVisible && i >= 0);

			return isVisible;
		}

		#endregion

		#region Tree Visibility
		
		private static int TreeVisibility(int rowIndex, int columnIndex, int[,] data) {
			var visibilityTop = TreesVisiblesToTop(rowIndex, columnIndex, data);

			var visibilityRight = TreesVisiblesToRight(rowIndex, columnIndex, data);

			var visibilityBottom = TreesVisiblesToBottom(rowIndex, columnIndex, data);

			var visibilityLeft = TreesVisiblesToLeft(rowIndex, columnIndex, data);

			var visibility = visibilityTop * visibilityRight * visibilityBottom * visibilityLeft;

			return visibility;
		}
		
		private static int TreesVisiblesToTop(int rowIndex, int columnIndex, int[,] data) {
			if (rowIndex == 0) {
				return 0;
			}

			var cant = 0;

			var finish = false;

			var value = data[rowIndex, columnIndex];

			var i = rowIndex - 1;

			do {

				var nextTree = data[i, columnIndex];

				if (nextTree >= value) {
					finish = true;
				}
				cant++;

				i--;
			} while (!finish && i >= 0);


			return cant;
		}

		private static int TreesVisiblesToRight(int rowIndex, int columnIndex, int[,] data) {
			if (columnIndex == data.GetLength(1) - 1) {
				return 0;
			}

			var cant = 0;

			var finish = false;

			var value = data[rowIndex, columnIndex];

			var i = columnIndex + 1;

			do {

				var nextTree = data[rowIndex, i];

				if (nextTree >= value) {
					finish = true;
				}
				cant++;
				i++;
			} while (!finish && i < data.GetLength(1));


			return cant;
		}

		private static int TreesVisiblesToBottom(int rowIndex, int columnIndex, int[,] data) {
			if (rowIndex == data.GetLength(0) - 1) {
				return 0;
			}

			var cant = 0;

			var finish = false;

			var value = data[rowIndex, columnIndex];

			var i = rowIndex + 1;

			do {

				var nextTree = data[i, columnIndex];

				if (nextTree >= value) {
					finish = true;
				}
				cant++;

				i++;
			} while (!finish && i < data.GetLength(0));


			return cant;
		}

		private static int TreesVisiblesToLeft(int rowIndex, int columnIndex, int[,] data) {
			if (columnIndex == 0) {
				return 0;
			}

			var cant = 0;

			var finish = false;

			var value = data[rowIndex, columnIndex];

			var i = columnIndex - 1;

			do {

				var nextTree = data[rowIndex, i];

				if (nextTree >= value) {
					finish = true;
				}
				cant++;
				i--;
			} while (!finish && i >= 0);


			return cant;
		}

		#endregion

	}
}
