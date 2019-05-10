using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathApp
{
    public sealed class MathControl
    {
        private string GetQuestionText()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Select one of the following options.");
            builder.AppendLine(string.Join(Environment.NewLine, this.Tasks.Select(task => $"{task.Key}. {task.Value.caption}")));

            return builder.ToString();
        }
        public void Run()
        {
            bool predicate = true;
            while (predicate)
            {
                Console.WriteLine(this.GetQuestionText());
                if (Int32.TryParse(Console.ReadLine(), out int nmbr) && this.Tasks.TryGetValue(nmbr, out var item))
                    item.action.Invoke();
                else
                    Console.WriteLine("Felaktigt värde!");
            }
        }

        public Dictionary<int, (string caption, Action action)> Tasks { get; }
            = new Dictionary<int, (string caption, Action action)>()
            {
                [1] = ("Addition/Subtraktion", () => new MathTask().Run()),
                [2] = ("Find number biggest difference", () => new MathTask2().Run()),
                [3] = ("Exit", () => Environment.Exit(0))
            };
    }
}