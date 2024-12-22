using AdventOfCode2024.Day22;

var lines = File.ReadAllLines("Day22/input.txt");

var solver = new DayTwentyTwoSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));