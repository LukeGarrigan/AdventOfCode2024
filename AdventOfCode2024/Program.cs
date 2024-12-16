using AdventOfCode2024.Day15;

var lines = File.ReadAllLines("Day16/input.txt");

var solver = new DaySixteenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));