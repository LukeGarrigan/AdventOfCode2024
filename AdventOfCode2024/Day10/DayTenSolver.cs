namespace AdventOfCode2024.Day10;

public class DayTenSolver : ISolver
{
    private bool _isPartOne;

    public DayTenSolver()
    {
        _isPartOne = true;
    }

    public string PartOne(string[] lines)
    {
        var map = lines.ToIntGrid();

        var trailHeadCount = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[0].Length; col++)
            {
                if (map[row][col] == 0)
                {
                    var countedRoutes = new HashSet<(int, int)>();
                    FindRoutes(row, col, -1);
                    trailHeadCount += countedRoutes.Count;

                    void FindRoutes(int currentRow, int currentCol, int previous)
                    {
                        var current = map[currentRow][currentCol];

                        if (current != previous + 1)
                        {
                            return;
                        }

                        if (current == 9)
                        {
                            countedRoutes.Add((currentRow, currentCol));
                            return;
                        }

                        var neighbours = GetNeighbours((currentRow, currentCol), map);
                        foreach (var n in neighbours)
                        {
                            FindRoutes(n.row, n.col, current);
                        }
                    }
                }
            }
        }

        return trailHeadCount.ToString();
    }

    private List<(int row, int col)> GetNeighbours((int row, int col) current, int[][] map)
    {
        var list = new List<(int row, int col)>();
        if (current.row - 1 >= 0)
        {
            list.Add((current.row - 1, current.col));
        }

        if (current.row + 1 < map.Length)
        {
            list.Add((current.row + 1, current.col));
        }

        if (current.col + 1 < map[current.row].Length)
        {
            list.Add((current.row, current.col + 1));
        }

        if (current.col - 1 >= 0)
        {
            list.Add((current.row, current.col - 1));
        }

        return list;
    }


    public string PartTwo(string[] lines)
    {
        var map = lines.ToIntGrid();

        var trailHeadCount = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[0].Length; col++)
            {
                if (map[row][col] == 0)
                {
                    var distinctRoutes = new HashSet<string>();
                    FindRoutes(row, col, -1, $"({row}, {col})");
                    trailHeadCount += distinctRoutes.Count;

                    void FindRoutes(int currentRow, int currentCol, int previous, string currentRoute)
                    {

                        var current = map[currentRow][currentCol];

                        if (current != previous + 1)
                        {
                            return;
                        }

                        if (current == 9)
                        {
                            distinctRoutes.Add(currentRoute);
                            return;
                        }

                        var neighbours = GetNeighbours((currentRow, currentCol), map);
                        foreach (var n in neighbours)
                        {
                            currentRoute += $"({n.row}, {n.col})";
                            FindRoutes(n.row, n.col, current, currentRoute);
                        }
                    }
                }
            }
        }

        return trailHeadCount.ToString();
    }
}