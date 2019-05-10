using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathApp.Interface;
namespace MathApp
{
    public sealed class MathTask : MathTaskBase
    {
        private List<(Func<int, int, string> caption, Func<int, int, int> operation)> Operations { get; } = new List<(Func<int, int, string> caption, Func<int, int, int> operation)> {
            ((number1, number2) => $"{number1} + {number2}", (number1, number2) => number1 + number2),
            ((number1, number2) => $"{number1} - {number2}", (number1, number2) => number1 - number2)
        };

        private (Func<int, int, string> caption, Func<int, int, int> operation) GetOperation() => this.Operations[RandomNumberGenerator.GenerateNumber(0, this.Operations.Count)];
        protected override (bool isCompleted, IMathTaskAnswer result) Execute()
        {
            int number1 = RandomNumberGenerator.GenerateNumber();
            int number2 = RandomNumberGenerator.GenerateNumber();
            var operation = this.GetOperation();

            string operationTxt = operation.caption(number1, number2);
            Console.Clear();

            Console.WriteLine(operationTxt);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (Int32.TryParse(Console.ReadLine(), out int answer))
                return (true, new MathTaskAnswer(operationTxt, answer, operation.operation, number1, watch.ElapsedMilliseconds / 1000, number2));

            return (false, new MathTaskAnswer(operationTxt, operation.operation, number1, watch.ElapsedMilliseconds / 1000, number2));
        }
    }
}