using PatternFinder.Util;

namespace PatternFinder
{
    /// <summary>
    /// Find the longest continuous strictly increasing subarray
    /// in a given sequence of integers. If there are multiple such subarrays
    /// with the same length, the earliest one is returned.
    /// </summary>
    public class LisFinder
    {
        /// <summary>
        /// Parses the input string and return the longest continuous strictly increasing subarray as a space-separated string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result Find(string input)
        {
            if (!TryParseInput(input, out int[]? sequence, out string parseError))
                return Result.Fail(parseError);

            (int start, int length) = FindEarliestLongestIncreasingSubarray(sequence!);
            return Result.Ok(string.Join(" ", sequence![start..(start + length)]));
        }
        /// <summary>
        /// Attempts to parse whitespace-separated integers from <paramref name="input"/>.
        /// Returns <c>true</c> and populates <paramref name="sequence"/> on success.
        /// Returns <c>false</c> and populates <paramref name="error"/> on failure — never throws.
        /// </summary>
        internal static bool TryParseInput(
            string? input,
            out int[]? sequence,
            out string error)
        {
            sequence = null;

            if (input is null)
            {
                error = "Input must not be null.";
                return false;
            }

            string trimmed = input.Trim();
            if (trimmed.Length == 0)
            {
                error = "Input must contain at least one integer.";
                return false;
            }

            string[] tokens = trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] result = new int[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (!int.TryParse(tokens[i], out result[i]))
                {
                    error = $"Token at position {i} is not a valid 32-bit integer: \"{tokens[i]}\".";
                    return false;
                }
            }

            sequence = result;
            error = string.Empty;
            return true;
        }
        public (int,int) FindEarliestLongestIncreasingSubarray(int[] sequence)
        {
            if (sequence.Length == 0)
                return (0, 0);
            int bestStart = 0;
            int bestLength = 1;
            int runStart = 0;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > sequence[i - 1])
                {
                    int runLength = i - runStart + 1;
                    if (runLength > bestLength)
                    {
                        bestStart = runStart;
                        bestLength = runLength;
                    }
                }
                else
                    runStart = i;
            }
            return (bestStart, bestLength);
        }
    }
}