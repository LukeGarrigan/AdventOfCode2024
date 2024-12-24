using AdventOfCode2024.Day24;

var lines = File.ReadAllLines("Day24/input.txt");

var solver = new DayTwentyFourSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));