namespace AOC.Interfaces {
	public interface IPuzzle {

		int Year { get; set; }
		int Puzzle { get; set; }

		void Solve();

		string SolvePartOne();

		string SolvePartTwo();
	}
}
