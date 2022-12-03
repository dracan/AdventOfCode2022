namespace AdventOfCode2022.Day2;

public static class Day2
{
    public static int CalculateTotalScoreFromInputFile_Part1() =>
        File.ReadLines(@"Day2\puzzle-input-day2.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(' '))
            .Select(x => new { TheirMove = ToMoveType(x[0]), OurMove = ToMoveType(x[1]) })
            .Sum(x => CalculateGameScore(x.OurMove, x.TheirMove));

    public static int CalculateTotalScoreFromInputFile_Part2() =>
        File.ReadLines(@"Day2\puzzle-input-day2.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(' '))
            .Select(x => new { TheirMove = ToMoveType(x[0]), OurMove = DeriveOurMoveFromOpponentMoveAndGameResult(ToMoveType(x[0]), ToGameResult(x[1])) })
            .Sum(x => CalculateGameScore(x.OurMove, x.TheirMove));

    public enum MoveType
    {
        Rock,
        Paper,
        Scissors,
    }

    public enum GameResult
    {
        Win,
        Lose,
        Draw,
    }

    private static MoveType ToMoveType(string moveCode) =>
        moveCode switch
        {
            "A" => MoveType.Rock,
            "B" => MoveType.Paper,
            "C" => MoveType.Scissors,
            "X" => MoveType.Rock,
            "Y" => MoveType.Paper,
            "Z" => MoveType.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(moveCode), moveCode, "Unexpected move code")
        };

    private static GameResult ToGameResult(string resultCode) =>
        resultCode switch
        {
            "X" => GameResult.Lose,
            "Y" => GameResult.Draw,
            "Z" => GameResult.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(resultCode), resultCode, null)
        };

    private static int ToMoveScore(MoveType moveType) =>
        moveType switch
        {
            MoveType.Rock => 1,
            MoveType.Paper => 2,
            MoveType.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(moveType), moveType, null)
        };

    private static int ToOutcomeScore(GameResult gameResult) =>
        gameResult switch
        {
            GameResult.Win => 6,
            GameResult.Lose => 0,
            GameResult.Draw => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(gameResult), gameResult, null)
        };

    public static int CalculateGameScore(MoveType ourMove, MoveType opponentsMove) =>
        ToOutcomeScore(CalculateGameResult(ourMove, opponentsMove)) + ToMoveScore(ourMove);

    public static GameResult CalculateGameResult(MoveType ourMove, MoveType opponentsMove) =>
        opponentsMove switch
        {
            MoveType.Rock => ourMove switch
            {
                MoveType.Rock => GameResult.Draw,
                MoveType.Paper => GameResult.Win,
                MoveType.Scissors => GameResult.Lose,
                _ => throw new ArgumentOutOfRangeException(nameof(ourMove), ourMove, null)
            },
            MoveType.Paper => ourMove switch
            {
                MoveType.Rock => GameResult.Lose,
                MoveType.Paper => GameResult.Draw,
                MoveType.Scissors => GameResult.Win,
                _ => throw new ArgumentOutOfRangeException(nameof(ourMove), ourMove, null)
            },
            MoveType.Scissors => ourMove switch
            {
                MoveType.Rock => GameResult.Win,
                MoveType.Paper => GameResult.Lose,
                MoveType.Scissors => GameResult.Draw,
                _ => throw new ArgumentOutOfRangeException(nameof(ourMove), ourMove, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(opponentsMove), opponentsMove, null)
        };

    public static MoveType DeriveOurMoveFromOpponentMoveAndGameResult(MoveType opponentsMove, GameResult gameResult) =>
        opponentsMove switch
        {
            MoveType.Rock => gameResult switch
            {
                GameResult.Draw => MoveType.Rock,
                GameResult.Win => MoveType.Paper,
                GameResult.Lose => MoveType.Scissors,
                _ => throw new ArgumentOutOfRangeException(nameof(gameResult), gameResult, null)
            },
            MoveType.Paper => gameResult switch
            {
                GameResult.Lose => MoveType.Rock,
                GameResult.Draw => MoveType.Paper,
                GameResult.Win => MoveType.Scissors,
                _ => throw new ArgumentOutOfRangeException(nameof(gameResult), gameResult, null)
            },
            MoveType.Scissors => gameResult switch
            {
                GameResult.Win => MoveType.Rock,
                GameResult.Lose => MoveType.Paper,
                GameResult.Draw => MoveType.Scissors,
                _ => throw new ArgumentOutOfRangeException(nameof(gameResult), gameResult, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(opponentsMove), opponentsMove, null)
        };
}