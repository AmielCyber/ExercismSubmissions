using System.Text;

public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        instructions = instructions.Select(s => s.ToLower()).ToArray();
        UserDefinedSyntax.ResetCustomSyntax();
        UserDefinedSyntax.AddCustomSyntax(instructions);

        Stack<string> stack = new();
        string[] forthTokens = CustomSyntaxToForth(instructions);
        foreach (var token in forthTokens)
        {
            ProcessToken(token, stack);
        }

        return string.Join(" ", stack.Select(s => s).Reverse());
    }

    private static string[] CustomSyntaxToForth(string[] instructions)
    {
        StringBuilder builder = new();
        foreach (var instruction in instructions)
        {
            if (!UserDefinedSyntax.IsCustom(instruction))
            {
                string[] tokens = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in tokens)
                {
                    builder.Append(
                        UserDefinedSyntax.Contains(token)
                            ? UserDefinedSyntax.GetOriginalDefinition(token)
                            : token
                    );
                    builder.Append(' ');
                }
            }
        }

        return builder.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private static void ProcessToken(string token, Stack<string> stack)
    {
        token = token.Trim();
        if (StackManipulation.IsStackManipulation(token))
        {
            StackManipulation.PerformOperation(stack, token);
        }
        else if (IntegerArithmetic.IsArithmetic(token))
        {
            var result = IntegerArithmetic.GetOperationResult(stack, token);
            stack.Push(result.ToString());
        }
        else if (int.TryParse(token, out var _))
        {
            stack.Push(token);
        }
        else
        {
            throw new InvalidOperationException($"Unknown operation encountered: {token}");
        }
    }
}

public static class IntegerArithmetic
{
    private static readonly Dictionary<string, ArithmeticOperation> Operations = new()
    {
        { "+", Add },
        { "-", Subtract },
        { "*", Multiply },
        { "/", Divide },
    };

    public static bool IsArithmetic(string op) => Operations.ContainsKey(op);

    public static int GetOperationResult(Stack<string> stack, string operation) =>
        Operations[operation](stack);

    private static int Add(Stack<string> stack)
    {
        var (leftOperand, rightOperand) = GetIntegerValues(stack);
        return leftOperand + rightOperand;
    }

    private static int Subtract(Stack<string> stack)
    {
        var (leftOperand, rightOperand) = GetIntegerValues(stack);
        return leftOperand - rightOperand;
    }

    private static int Multiply(Stack<string> stack)
    {
        var (leftOperand, rightOperand) = GetIntegerValues(stack);
        return leftOperand * rightOperand;
    }

    private static int Divide(Stack<string> stack)
    {
        var (leftOperand, rightOperand) = GetIntegerValues(stack);
        if (rightOperand == 0)
        {
            throw new DivideByZeroException();
        }

        return leftOperand / rightOperand;
    }

    private static (int leftInteger, int rightInteger) GetIntegerValues(Stack<string> stack)
    {
        if (stack.Count < 2)
        {
            throw new InvalidOperationException(
                "Can not perform operations without 2 operands in stack."
            );
        }

        var rightOperandIsInteger = int.TryParse(stack.Pop(), out var rightOperand);
        var leftOperandIsInteger = int.TryParse(stack.Pop(), out var leftOperand);
        if (leftOperandIsInteger && rightOperandIsInteger)
        {
            return (leftOperand, rightOperand);
        }

        throw new InvalidOperationException("Operands in stack are not integers.");
    }

    private delegate int ArithmeticOperation(Stack<string> stack);
}

public static class StackManipulation
{
    private static readonly Dictionary<string, StackOperation> Operations = new()
    {
        { "dup", DuplicateTop },
        { "drop", DropTop },
        { "swap", SwapTop },
        { "over", DuplicateSecondTop },
    };

    public static bool IsStackManipulation(string op) => Operations.ContainsKey(op);

    public static void PerformOperation(Stack<string> stack, string operation) =>
        Operations[operation](stack);

    private static void DuplicateTop(Stack<string> stack)
    {
        AssertStackCanPerformMinimumPops(stack, 1);
        stack.Push(stack.Peek());
    }

    private static void DropTop(Stack<string> stack)
    {
        AssertStackCanPerformMinimumPops(stack, 1);
        stack.Pop();
    }

    private static void SwapTop(Stack<string> stack)
    {
        AssertStackCanPerformMinimumPops(stack, 2);
        var top = stack.Pop();
        var newTop = stack.Pop();
        stack.Push(top);
        stack.Push(newTop);
    }

    private static void DuplicateSecondTop(Stack<string> stack)
    {
        AssertStackCanPerformMinimumPops(stack, 2);
        var top = stack.Pop();
        var secondTop = stack.Pop();
        stack.Push(secondTop);
        stack.Push(top);
        stack.Push(secondTop);
    }

    private static void AssertStackCanPerformMinimumPops(Stack<string> stack, int minimumPops)
    {
        if (stack.Count < minimumPops)
        {
            throw new InvalidOperationException(
                $"Can not perform stack operation. Minimum stack size needed: {minimumPops}."
            );
        }
    }

    private delegate void StackOperation(Stack<string> stack);
}

public static class UserDefinedSyntax
{
    private static readonly Dictionary<string, string> DefinedSyntax = new();
    private static readonly char[] Seperators = [' ', ':', ';'];

    public static bool Contains(string operation) => DefinedSyntax.ContainsKey(operation);

    public static void AddCustomSyntax(string[] instructions)
    {
        foreach (var instruction in instructions)
        {
            if (IsCustom(instruction))
            {
                AddSyntax(instruction);
            }
        }
    }

    public static bool IsCustom(string instruction) =>
        instruction.StartsWith(":") && instruction.EndsWith(";");

    public static string GetOriginalDefinition(string syntax) => DefinedSyntax[syntax];

    public static void ResetCustomSyntax() => DefinedSyntax.Clear();

    private static void AddSyntax(string instruction)
    {
        string[] tokens = instruction.Split(Seperators, StringSplitOptions.RemoveEmptyEntries);
        var operation = tokens[0];
        if (!DefinedSyntax.ContainsKey(operation))
        {
            AssertOperationIsValid(operation);
        }

        StringBuilder newDefinition = new();
        for (var i = 1; i < tokens.Length; i++)
        {
            if (DefinedSyntax.ContainsKey(tokens[i]))
            {
                newDefinition.Append(DefinedSyntax[tokens[i]]);
            }
            else
            {
                AssertDefinitionIsValid(tokens[i]);
                newDefinition.Append(tokens[i]);
            }

            if (i != tokens.Length - 1)
            {
                newDefinition.Append(' ');
            }
        }

        DefinedSyntax[operation] = newDefinition.ToString();
    }

    private static void AssertOperationIsValid(string operation)
    {
        if (IsNumber(operation))
        {
            throw new InvalidOperationException(
                $"Operation '{operation}' is not a known forth operation."
            );
        }
    }

    private static bool IsOperation(string operation) =>
        IntegerArithmetic.IsArithmetic(operation)
        || StackManipulation.IsStackManipulation(operation)
        || DefinedSyntax.ContainsKey(operation);

    private static bool IsNumber(string number) => int.TryParse(number, out var _);

    private static void AssertDefinitionIsValid(string definition)
    {
        if (!IsOperation(definition) && !IsNumber(definition))
        {
            throw new InvalidOperationException(
                $"Definition '{definition}' is not a known forth operation nor a number."
            );
        }
    }
}
