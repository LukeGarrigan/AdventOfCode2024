using AdventOfCode2024.Day17;

var lines = File.ReadAllLines("Day17/input.txt");

var solver = new DaySeventeenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));