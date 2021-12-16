using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application
{
    public static class ExceptionHelper
    {
        public static ArgumentException CreateArgumentShouldBeGreaterException(string argumentName)
            => new ArgumentException($"Argument {argumentName} should be greater then 0", argumentName);
    }
}
