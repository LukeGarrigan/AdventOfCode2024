using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day13;

public class DayThirteenSolver : ISolver
{
    record Game(Button A, Button B, BigInteger PrizeX, BigInteger PrizeY);
    record Button(BigInteger XCost, BigInteger YCost);
    private Dictionary<(BigInteger, BigInteger), BigInteger> _memo = new();

    public string PartOne(string[] lines)
    {
        var games = GetGames(lines);

        BigInteger totalCost = 0;
        foreach (var game in games)
        {
            _memo = new Dictionary<(BigInteger,  BigInteger), BigInteger>();
            var cost = Solve(game, 0, 0, 0);
            if (cost != int.MaxValue)
            {
                totalCost += cost;
            }
        }

        return totalCost.ToString();
    }

    private static List<Game> GetGames(string[] lines)
    {
        var games = new List<Game>();
        for (var i = 0; i < lines.Length; i += 4)
        {
            var reg = new Regex(@"\d+");
            var aMatches = reg.Matches(lines[i]);
            var aX = int.Parse(aMatches[0].Value);
            var aY = int.Parse(aMatches[1].Value);


            var bMatches = reg.Matches(lines[i + 1]);
            var bX = int.Parse(bMatches[0].Value);
            var bY = int.Parse(bMatches[1].Value);

            var prizeMatches = reg.Matches(lines[i + 2]);

            var prizeX = int.Parse(prizeMatches[0].Value);
            var prizeY = int.Parse(prizeMatches[1].Value);

            games.Add(new Game(new Button(aX, aY), new Button(bX, bY), prizeX, prizeY));
        }

        return games;
    }


    private BigInteger Solve(Game game, BigInteger x, BigInteger y, int tokens)
    {
        if (x > game.PrizeX || y > game.PrizeY)
        {
            return int.MaxValue;
        }

        if (x == game.PrizeX && y == game.PrizeY)
        {
            return tokens;
        }

        if (_memo.ContainsKey((x, y)))
        {
            return _memo[(x, y)];
        }

        BigInteger result = BigInteger.Min(Solve(game, x + game.A.XCost, y + game.A.YCost, tokens + 3),
            Solve(game, x + game.B.XCost, y + game.B.YCost, tokens + 1));

        _memo[(x, y)] = result;

        return result;
    }

    public string PartTwo(string[] lines)
    {
        var games = new List<Game>();
        for (var i = 0; i < lines.Length; i += 4)
        {
            var reg = new Regex(@"\d+");
            var aMatches = reg.Matches(lines[i]);
            var aX = int.Parse(aMatches[0].Value);
            var aY = int.Parse(aMatches[1].Value);


            var bMatches = reg.Matches(lines[i + 1]);
            var bX = int.Parse(bMatches[0].Value);
            var bY = int.Parse(bMatches[1].Value);

            var prizeMatches = reg.Matches(lines[i + 2]);

            var prizeX = BigInteger.Parse(prizeMatches[0].Value) + 10000000000000;
            var prizeY = BigInteger.Parse(prizeMatches[1].Value) + 10000000000000;

            games.Add(new Game(new Button(aX, aY), new Button(bX, bY), prizeX, prizeY));
        }
 
        BigInteger totalCost = 0;
        foreach (var game in games)
        {
            _memo = new Dictionary<(BigInteger, BigInteger), BigInteger>();
            var cost = Solve(game, 0, 0, 0);
            if (cost != int.MaxValue)
            {
                totalCost += cost;
            }
        }

        return totalCost.ToString();
    }
}