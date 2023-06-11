using AOC.Helpers;
using AOC.Interfaces;

namespace AOC.Year._2022.Problems.Problem05 {
	public class ProblemFive : IPuzzle, IReadTest<Data> {
		public int Year { get; set; }
		public int Puzzle { get; set; }

		public string SolvePartOne() {
			var result = "";

			var data = ReadTests();

			foreach (var instruction in data.Instructions) {
				for (int i = 1; i <= instruction.QuantityToMove; i++) {

					var value = data.Map[instruction.From][0];
					data.Map[instruction.To].Insert(0, value);

					data.Map[instruction.From].RemoveAt(0);
				}
			}

			for (int i = 1; i <= data.Map.Count; i++) {
				result += data.Map[i].First();
			}

			return result;
		}

		public string SolvePartTwo() {
			var result = "";

			var data = ReadTests();

			foreach (var instruction in data.Instructions) {
				var list = data.Map[instruction.From].Take(instruction.QuantityToMove);
				data.Map[instruction.To].InsertRange(0, list);

				data.Map[instruction.From].RemoveRange(0, instruction.QuantityToMove);
			}

			for (int i = 1; i <= data.Map.Count; i++) {
				result += data.Map[i].First();
			}

			return result;
		}

		public void Solve() {
			Console.WriteLine("Part One: " + SolvePartOne());
			Console.WriteLine("Part Two: " + SolvePartTwo());
		}

		public Data ReadTests() {
			var text = FileHelper.GetFileText(Year, Puzzle);

			var test = text.Split(new string[] { " \r\n\r\n" }, StringSplitOptions.None);

			var instructionsLines = test[1].Split(Environment.NewLine);

			var instructions = GetInstructions(instructionsLines);

			var map = GetMap(test[0]);

			return new Data(map, instructions);
		}

		private Dictionary<int, List<string>> GetMap(string text) {
			var lenght = GetLenght(text);

			var columns = text.SplitInColumns<string>(4, lenght, true);

			return columns;
		}

		private static int GetLenght(string text) {
			var lines = text.Split(Environment.NewLine);
			var t = lines[^1].Split(' ');

			return int.Parse(t[^1]);
		}

		private static List<Instruction> GetInstructions(string[] instructionsLines) {
			var instructions = new List<Instruction>();
			foreach (var instructionLine in instructionsLines) {
				var spl = instructionLine.Split(" ");

				var instruction = new Instruction {
					QuantityToMove = int.Parse(spl[1]),
					From = int.Parse(spl[3]),
					To = int.Parse(spl[5]),
				};
				instructions.Add(instruction);
			}

			return instructions;
		}
	}

	public class Data {
		public Dictionary<int, List<string>> Map { get; set; }
		public List<Instruction> Instructions { get; set; }

		public Data(Dictionary<int, List<string>> map, List<Instruction> instructions) {
			Map = map;
			Instructions = instructions;

		}

	}

	public class Instruction {
		public int QuantityToMove { get; set; }
		public int From { get; set; }
		public int To { get; set; }
	}

}
