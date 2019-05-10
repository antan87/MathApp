using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathApp.Interface;

namespace MathApp
{
    public sealed class MathTask2 : MathTaskBase
    {
        protected override (bool isCompleted, IMathTaskAnswer result) Execute()
        {
            var numbers = new List<int> { RandomNumberGenerator.GenerateNumber(0, 50), RandomNumberGenerator.GenerateNumber(0, 50), RandomNumberGenerator.GenerateNumber(0, 50) };
            string operationTxt = string.Join(" ", numbers);
            Func<List<int>, int> operation = (list) =>
            {
                list.Sort();
                var dif1 = list[1] - list[0];
                var dif2 = list[2] - list[1];
                return dif1 > dif2 ? list[0] : list[2];
            };

            Console.Clear();
            Console.WriteLine(operationTxt);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (Int32.TryParse(Console.ReadLine(), out int answer))
                return (true, new MathTaskAnswer2(operationTxt, answer, operation, numbers, watch.ElapsedMilliseconds / 1000));

            return (false, new MathTaskAnswer2(operationTxt, operation, numbers, watch.ElapsedMilliseconds / 1000));
        }
    }
}
