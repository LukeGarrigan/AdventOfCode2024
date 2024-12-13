using AdventOfCode2024.Day12;
using AdventOfCode2024.Day13;

var lines = File.ReadAllLines("Day13/input.txt");

var solver = new DayThirteenSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
