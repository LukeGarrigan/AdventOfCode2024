using AdventOfCode2024.Day06;

var lines = File.ReadAllLines("Day06/input.txt");

var solver = new DaySixSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
