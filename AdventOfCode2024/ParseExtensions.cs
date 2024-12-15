namespace AdventOfCode2024;

public static class ParseExtensions
{
    public static List<int> SplitToInt(this string input) => input.Split(" ").Select(int.Parse).ToList();
    public static char[][] ToCharGrid(this string[] lines) => lines.Select(line => line.ToArray()).ToArray();
    public static int[][] ToIntGrid(this string[] charGrid) =>  charGrid.ToCharGrid().Select(row => row.Select(c => c - '0').ToArray()).ToArray();
    public static string[] ToLines(this string input) => input.Split("\r\n");

    public static void Print(this char[][] grid)
    {
        Console.WriteLine();
        for (var i = 0; i < grid.Length; i++)
        {
            Console.WriteLine();
            for (var j = 0; j < grid[i].Length; j++)
            {
                Console.Write(grid[i][j]);
            }
        }
        
    }
}   