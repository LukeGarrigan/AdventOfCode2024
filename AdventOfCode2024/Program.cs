using AdventOfCode2024.Day05;

var lines = File.ReadAllLines("Day05/input.txt");

var solver = new DayFiveSolver();
Console.WriteLine(solver.PartOne(lines));
Console.WriteLine(solver.PartTwo(lines)); // too low
