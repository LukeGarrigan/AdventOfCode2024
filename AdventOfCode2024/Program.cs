using AdventOfCode2024.Day09;

var lines = File.ReadAllLines("Day09/input.txt");

var solver = new DayNineSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
