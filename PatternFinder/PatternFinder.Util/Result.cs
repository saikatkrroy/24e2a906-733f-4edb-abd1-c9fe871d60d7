using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFinder.Util
{
    public sealed class Result
    {
        public string Value { get; }

        public string Error { get; }

        public bool IsSuccess => Error.Length == 0;
        public bool IsFailure => !IsSuccess;

        private Result(string value, string error)
        {
            Value = value;
            Error = error;
        }

        internal static Result Ok(string value) => new(value, string.Empty);
        internal static Result Fail(string error) => new(string.Empty, error);

        public override string ToString() =>
            IsSuccess ? $"Ok({Value})" : $"Fail({Error})";
    }
}
