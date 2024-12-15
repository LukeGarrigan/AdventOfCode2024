using AdventOfCode2024.Day15;

var lines = File.ReadAllLines("Day15/input.txt");

var solver = new DayFifteenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));