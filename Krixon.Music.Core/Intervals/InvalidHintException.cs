using System;

namespace Krixon.Music.Core.Intervals
{
    public class InvalidHintException : ArgumentException
    {
        public InvalidHintException(string? message, string? paramName) : base(message, paramName)
        {
        }
    }
}
