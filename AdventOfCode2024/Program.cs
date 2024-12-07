using AdventOfCode2024.Day06;
using AdventOfCode2024.Day07;

var lines = File.ReadAllLines("Day07/input.txt");

var solver = new DaySevenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
