using Microsoft.VisualBasic;

namespace AdventOfCode2024.Day17;

public class DaySeventeenSolver : ISolver
{
    public int RegisterA { get; set; }
    public int RegisterB { get; set; }
    public int RegisterC { get; set; }

    private enum Opcode
    {
        Adv,
        Bxl,
        Bst,
        Jnz,
        Bxc,
        Out,
        Bdv,
        Cdc
    }

    public string PartOne(string[] input)
    {
        RegisterA = int.Parse(input[0].Split(": ")[1]);
        RegisterB = int.Parse(input[1].Split(": ")[1]);
        RegisterC = int.Parse(input[2].Split(": ")[1]);
        var program = input[4].Split(": ")[1].Split(",").Select(int.Parse).ToList();
        var output = new System.Collections.Generic.List<int>();

        for (var pointer = 0; pointer < program.Count; pointer += 2)
        {
            var opcode = (Opcode)program[pointer];
            var operandLiteral = program[pointer + 1];
            var comboOperand = GetOperandValue(operandLiteral);

            if (opcode == Opcode.Adv)
            {
                RegisterA /= (int)Math.Pow(2, comboOperand); // truncated to an integer?
            }
            else if (opcode == Opcode.Bxl)
            {
                RegisterB = RegisterB ^ operandLiteral;
            }
            else if (opcode == Opcode.Bst)
            {
                RegisterB = comboOperand % 8;
            }
            else if (opcode == Opcode.Jnz)
            {
                if (RegisterA != 0)
                {
                    pointer = operandLiteral - 2; // -2 here just to deduct the upcoming increment
                }
            }
            else if (opcode == Opcode.Bxc)
            {
                RegisterB ^= RegisterC;
            }
            else if (opcode == Opcode.Out)
            {
                output.Add(comboOperand % 8);
            }
            else if (opcode == Opcode.Bdv)
            {
                RegisterB = RegisterA / (int)Math.Pow(2, comboOperand);
            }
            else if (opcode == Opcode.Cdc)
            {
                RegisterC = RegisterA / (int)Math.Pow(2, comboOperand);
            }
        }

        return string.Join(",", output);
    }

    private int GetOperandValue(int operand)
    {
        return operand switch
        {
            0 or 1 or 2 => operand,
            4 => RegisterA,
            5 => RegisterB,
            6 => RegisterC,
            7 => 7,
            _ => operand
        };
    }


    public string PartTwo(string[] input)
    {
        RegisterA = int.Parse(input[0].Split(": ")[1]);
        RegisterB = int.Parse(input[1].Split(": ")[1]);
        RegisterC = int.Parse(input[2].Split(": ")[1]);
        var program = input[4].Split(": ")[1].Split(",").Select(int.Parse).ToList();


        var registerIndex = 0;
        while (true)
        {
            registerIndex++;
            var output = new List<int>();
            int instructionExecutionCount = 0;
            while (output.Count < program.Count() && instructionExecutionCount < 1000)
            {
                RegisterA = registerIndex;
                RegisterC = 0;
                RegisterB = 0;
                output = new System.Collections.Generic.List<int>();

                for (var pointer = 0; pointer < program.Count; pointer += 2)
                {
                    instructionExecutionCount++;
                    var opcode = (Opcode)program[pointer];
                    var operandLiteral = program[pointer + 1];
                    var comboOperand = GetOperandValue(operandLiteral);

                    if (opcode == Opcode.Adv)
                    {
                        RegisterA /= (int)Math.Pow(2, comboOperand); // truncated to an integer?
                    }
                    else if (opcode == Opcode.Bxl)
                    {
                        RegisterB = RegisterB ^ operandLiteral;
                    }
                    else if (opcode == Opcode.Bst)
                    {
                        RegisterB = comboOperand % 8;
                    }
                    else if (opcode == Opcode.Jnz)
                    {
                        if (RegisterA != 0)
                        {
                            pointer = operandLiteral - 2; // -2 here just to deduct the upcoming increment
                            
                        }
                    }
                    else if (opcode == Opcode.Bxc)
                    {
                        RegisterB ^= RegisterC;
                    }
                    else if (opcode == Opcode.Out)
                    {
                        output.Add(comboOperand % 8);
                    }
                    else if (opcode == Opcode.Bdv)
                    {
                        RegisterB = RegisterA / (int)Math.Pow(2, comboOperand);
                    }
                    else if (opcode == Opcode.Cdc)
                    {
                        RegisterC = RegisterA / (int)Math.Pow(2, comboOperand);
                    }
                }
            }

            if (registerIndex % 100000 == 0)
            {
                Console.WriteLine(registerIndex);
            }

            if (output.SequenceEqual(program))
            {
                return registerIndex.ToString();
            }
        }
    }
}