using AdventOfCode2024.Day23;

var lines = File.ReadAllLines("Day23/input.txt");

var solver = new DayTwentyThreeSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));