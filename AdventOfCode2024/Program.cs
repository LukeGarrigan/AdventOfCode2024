using AdventOfCode2024.Day04;
using AdventOfCode2024.Day14;

var lines = File.ReadAllLines("Day14/input.txt");

var solver = new DayFourteenSolver(101, 103);
// Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));