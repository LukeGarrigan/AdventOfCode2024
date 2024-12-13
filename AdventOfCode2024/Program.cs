using AdventOfCode2024.Day12;

var lines = File.ReadAllLines("Day12/input.txt");

var solver = new DayTwelveSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines));
