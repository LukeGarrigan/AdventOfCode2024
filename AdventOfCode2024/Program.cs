using AdventOfCode2024.Day10;

var lines = File.ReadAllLines("Day10/input.txt");

var solver = new DayTenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
