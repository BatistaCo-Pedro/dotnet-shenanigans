namespace ExpressionTrees;

public class BuildingExpressionTrees
{
    public LambdaExpression BuildConstant()
    {
        return Expression.Lambda(Expression.Constant(1, typeof(int)));
    }

    public LambdaExpression BuildBinaryConstant()
    {
        var left = Expression.Constant(1, typeof(int));
        var right = Expression.Constant(2, typeof(int));

        return Expression.Lambda(Expression.Add(left, right));
    }

    private LambdaExpression BuildBinaryConstantOneStatement()
    {
        return Expression.Lambda(
            Expression.Add(Expression.Constant(1, typeof(int)), Expression.Constant(2, typeof(int)))
        );
    }
    
    public LambdaExpression BuildParameter()
    {
        var parameter = Expression.Parameter(typeof(int), "num");

        return Expression.Lambda(parameter);
    }

    // Distance calc
    public LambdaExpression BuildMultipleParameters()
    {
        var xParameter = Expression.Parameter(typeof(double), "x");
        var yParameter = Expression.Parameter(typeof(double), "y");
        
        var xSquared = Expression.Multiply(xParameter, xParameter);
        var ySquared = Expression.Multiply(yParameter, yParameter);
        
        var sum = Expression.Add(xSquared, ySquared);
        var sqrtMethod = typeof(Math).GetMethod(nameof(Math.Sqrt), [typeof(double)]) ?? throw new InvalidOperationException("Couldn't get sqrt method");

        var distance = Expression.Call(sqrtMethod, sum);
        
        return Expression.Lambda(distance, xParameter, yParameter);
    }

    public BlockExpression CodeBlock()
    {
        /*
            Func<int, int> factorialFunc = (n) =>
            {
                var res = 1;
                while (n > 1)
                {
                    res = res * n;
                    n--;
                }
                return res;
            };
         */

        var label = Expression.Label(typeof(int));
        
        var n = Expression.Parameter(typeof(int), "n");

        var result = Expression.Variable(typeof(int), "result");
        var initResult = Expression.Assign(result, Expression.Constant(1, typeof(int)));

        var multiplication = Expression.Multiply(result, n);

        // Inner block of the while loop
        var block = Expression.Block(Expression.Assign(result, multiplication), Expression.Decrement(result));

        var loop = Expression.Loop(Expression.IfThenElse(Expression.GreaterThan(result, Expression.Constant(1, typeof(int))), block, Expression.Break(label, result)), label);

        var expressionBody = Expression.Block(result, initResult, loop);

        return expressionBody;
    }

    public Expression<Func<int, bool>> MapCode()
    {
        // Manually build the expression tree for
        // the lambda expression num => num < 5.

        var numParam = Expression.Parameter(typeof(int), "num");
        var constantFive = Expression.Constant(5, typeof(int));

        return Expression.Lambda<Func<int, bool>>(Expression.LessThan(numParam, constantFive), numParam);
    }
}

public class TranslateExpression
{
    public static Expression ReplaceNode(Expression original)
    {
        if (original.NodeType == ExpressionType.Constant)
        {
            return Expression.Multiply(original, Expression.Constant(10, typeof(int)));
        }

        if (original.NodeType == ExpressionType.Add)
        {
            var binaryExpression = (BinaryExpression)original;
            return Expression.Add(ReplaceNode(binaryExpression.Left), ReplaceNode(binaryExpression.Right));
        }

        return original;
    }

    public static void RunExpression()
    {
        var one = Expression.Constant(1, typeof(int));
        var two = Expression.Constant(2, typeof(int));
        var addition = Expression.Add(one, two);
        var sum = ReplaceNode(addition);
        var executableFunc = Expression.Lambda(sum);

        var func = (Func<int>)executableFunc.Compile();
        var answer = func();
        Console.WriteLine(answer);
    }
}