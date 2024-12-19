using AdventOfCode2024.Day19;

var lines = File.ReadAllLines("Day19/input.txt");

var solver = new DayNineteenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));