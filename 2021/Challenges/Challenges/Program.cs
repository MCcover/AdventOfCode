using Challenges.Solutions;

bool exit = false;
do {
	string? result = string.Empty;

	Console.WriteLine("Number of challenge (1 - 25): ");
	string? inputChallenge = Console.ReadLine();

	exit = !int.TryParse(inputChallenge, out int challenge);
	if (!exit) {
		result = challenge switch {
			1 => ChallengeOne.Resolve(),
			2 => ChallengeTwo.Resolve(),
			3 => ChallengeThree.Resolve(),
			4 => ChallengeFour.Resolve(),
			5 => ChallengeFive.Resolve(),
			6 => ChallengeSix.Resolve(),
			7 => ChallengeSeven.Resolve(),
			8 => ChallengeEight.Resolve(),
			9 => ChallengeNine.Resolve(),
			10 => ChallengeTen.Resolve(),
			11 => ChallengeEleven.Resolve(),
			12 => ChallengeTwelve.Resolve(),
			13 => ChallengeTheirteen.Resolve(),
			14 => ChallegeFourteen.Resolve(),
			15 => ChallengeFifteen.Resolve(),
			16 => ChallengeSixteen.Resolve(),
			17 => ChallengeSeventeen.Resolve(),
			18 => ChallengeEightteen.Resolve(),
			19 => ChallengeNineteen.Resolve(),
			20 => ChallengeTwenty.Resolve(),
			21 => ChallengeTwentyOne.Resolve(),
			22 => ChallengeTwentyTwo.Resolve(),
			23 => ChallengeTwentyThree.Resolve(),
			24 => ChallengeTwentyFour.Resolve(),
			25 => ChallengeTwentyFive.Resolve(),
			_ => "Invalid Input",
		};
		Console.WriteLine($"Result Challenge {challenge}: " + result);
	}
} while (!exit);