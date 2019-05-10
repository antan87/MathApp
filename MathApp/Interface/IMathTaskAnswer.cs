using System;
using System.Collections.Generic;
using System.Text;

namespace MathApp.Interface
{
    public interface IMathTaskAnswer
    {
        int? Answer { get; }
        bool IsCorrectAnswer { get; }
        long Duration { get; }
    }
}
