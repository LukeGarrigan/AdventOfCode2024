using AdventOfCode2024.Day25;

var lines = File.ReadAllLines("Day25/input.txt");

var solver = new DayTwentyFiveSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));