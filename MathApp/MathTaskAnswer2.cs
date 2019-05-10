using System;
using System.Collections.Generic;
using System.Text;
using MathApp.Interface;

namespace MathApp
{
    public sealed class MathTaskAnswer2 : IMathTaskAnswer
    {
        public int? Answer { get; }
        public long Duration { get; }

        public bool IsCorrectAnswer => this.Operation(this.Numbers) == this.Answer;
        public MathTaskAnswer2(string text, int answer, Func<List<int>, int> operation, List<int> numbers, long duration)
        {
            this.Text = text;
            this.Answer = answer;
            this.Numbers = numbers;
            this.Operation = operation;
            this.Duration = duration;
        }

        public MathTaskAnswer2(string text, Func<List<int>, int> operation, List<int> numbers, long duration)
        {
            this.Text = text;
            this.Operation = operation;
            this.Numbers = numbers;
            this.Duration = duration;
        }
        public List<int> Numbers { get; }

        public Func<List<int>, int> Operation { get; }
        public int SecondNumber { get; }
        public string Text { get; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Text);
            builder.Append($" Answer: {this.Answer} Correct answer: {this.Operation(this.Numbers)}");
            builder.Append($" {(this.IsCorrectAnswer ? "R" : "W")}");
            builder.Append($" Time: {this.Duration}");

            return builder.ToString();
        }
    }
}
