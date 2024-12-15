namespace AdventOfCode2024.Day15;

public class DayFifteenSolver : ISolver
{
    public string PartOne(string[] input)
    {
        var (grid, instructions, r) = GetInput(input);

        foreach (var instruction in instructions)
        {
            int colS = 0;
            int rowS = 0;
            if (instruction == '>')
            {
                colS = 1;
            }
            else if (instruction == '<')
            {
                colS = -1;
            }
            else if (instruction == '^')
            {
                rowS = -1;
            } else if (instruction == 'v')
            {
                rowS = 1;
            }

            var row = r.row;
            var col = r.col;
            if (grid[row + rowS][col + colS] == '.')
            {
                grid[row + rowS][col + colS] = '@';
                grid[row][col] = '.';
                r.row = row + rowS;
                r.col = col + colS;
            }
            else
            {
                var nextCol = col + colS;
                var nextRow = row + rowS;
                while (grid[nextRow][nextCol] == 'O')
                {
                    nextCol += colS;
                    nextRow += rowS;
                }

                if (grid[nextRow][nextCol] == '.')
                {
                    while (nextCol != col || nextRow != row)
                    {
                        grid[nextRow][nextCol] = grid[nextRow + rowS * -1][nextCol + colS * -1];
                        grid[nextRow + rowS * -1][nextCol + colS * -1] = '.';

                        nextCol += colS * -1;
                        nextRow += rowS * -1;
                    }

                    r.row = row + rowS;
                    r.col = col + colS;
                }
            }

            // grid.Print();
        }

        var total = 0;


        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 'O')
                {
                    total += 100 * i + j;
                }
                
            }
        }

        return total.ToString();
    }

    private static (char[][] grid, List<char> instructions, (int row, int col) robotPosition) GetInput(string[] input)
    {
        var warehouse = new List<string>();
        var i = 0;
        for (i = 0; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                break;
            }

            warehouse.Add(input[i]);
        }

        char[][] grid = warehouse.Select(line => line.ToArray()).ToArray();

        (int, int) robotPosition = (0, 0);
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == '@')
                {
                    robotPosition = (row, col);
                }
            }
        }

        i++;

        var instructions = new List<char>();
        for (; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                instructions.Add(input[i][j]);
            }
        }

        return (grid, instructions, robotPosition);
    }

    public string PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}