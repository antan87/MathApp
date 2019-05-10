using System;
using System.Text;
using MathApp.Interface;

namespace MathApp
{
    public sealed class MathTaskAnswer : IMathTaskAnswer
    {
        public int? Answer { get; }
        public long Duration { get; }

        public int FirstNumber { get; }
        public bool IsCorrectAnswer => this.Operation(this.FirstNumber, this.SecondNumber) == this.Answer;
        public MathTaskAnswer(string text, int answer, Func<int, int, int> operation, int firstNumber, long duration, int sencondNumber)
        {
            this.Text = text;
            this.Answer = answer;
            this.Operation = operation;
            this.FirstNumber = firstNumber;
            this.Duration = duration;
            this.SecondNumber = sencondNumber;
        }

        public MathTaskAnswer(string text, Func<int, int, int> operation, int firstNumber, long duration, int sencondNumber)
        {
            this.Text = text;
            this.Operation = operation;
            this.FirstNumber = firstNumber;
            this.Duration = duration;
            this.SecondNumber = sencondNumber;
        }

        public Func<int, int, int> Operation { get; }
        public int SecondNumber { get; }
        public string Text { get; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Text);
            builder.Append($" Answer: {this.Answer} Correct answer: {this.Operation(this.FirstNumber, this.SecondNumber)}");
            builder.Append($" {(this.IsCorrectAnswer ? "R" : "W")}");
            builder.Append($" Time: {this.Duration}");

            return builder.ToString();
        }
    }
}
