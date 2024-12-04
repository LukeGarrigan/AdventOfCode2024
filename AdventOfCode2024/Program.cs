using AdventOfCode2024.Day01;
using AdventOfCode2024.Day04;

var lines = File.ReadAllLines("Day04/input.txt");

var solver = new DayFourSolver();
Console.WriteLine(solver.PartTwo(lines));