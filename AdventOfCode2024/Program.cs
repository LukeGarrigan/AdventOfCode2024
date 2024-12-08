using AdventOfCode2024.Day08;

var lines = File.ReadAllLines("Day08/input.txt");

var solver = new DayEightSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
