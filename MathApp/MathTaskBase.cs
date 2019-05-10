using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathApp.Interface;

namespace MathApp
{
    public abstract class MathTaskBase : IMathTask
    {
        protected abstract (bool isCompleted, IMathTaskAnswer result) Execute();
        public void Run()
        {
            Console.WriteLine("Enter the number of questions!");
            if (Int32.TryParse(Console.ReadLine(), out int questions))
            {
                var results = new List<(bool isCompleted, IMathTaskAnswer result)>();
                while (questions > 0)
                {
                    results.Add(this.Execute());
                    questions--;
                }

                Console.WriteLine(GetResultText(results.Select(row => row.result)));
            }
        }


        private static string GetResultText(IEnumerable<IMathTaskAnswer> answers)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Join(Environment.NewLine, answers.Select(row => row.ToString())));
            builder.AppendLine($"Correct: {answers.Count(row => row.IsCorrectAnswer)} Wrong: {answers.Count(row => !row.IsCorrectAnswer)}");

            return builder.ToString();
        }

    }
}
