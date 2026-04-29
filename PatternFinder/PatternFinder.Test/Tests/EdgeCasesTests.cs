using Xunit;

namespace PatternFinder.Test.Tests
{
    public class EdgeCasesTests: BaseTest
    {
        // -----------------------------------------------------------------------
        // FindEarliestLongestIncreasingSubarray - Test for Edge Case
        // -----------------------------------------------------------------------
        [Fact]
        public void Solve_NegativeIntegers_HandledCorrectly()
        {
            Assert.Equal("-5 -3 -1", lisFinder.Find("-5 -3 -1 -2"));
        }
        [Fact]
        public void Solve_MixedNegativeAndPositive_HandledCorrectly()
        {
            Assert.Equal("-2 -1 0 1", lisFinder.Find("5 -2 -1 0 1"));
        }
        [Fact]
        public void Solve_MinAndMaxIntAscending_ReturnsBoth()
        {
            Assert.Equal($"{int.MinValue} {int.MaxValue}",
                lisFinder.Find($"{int.MinValue} {int.MaxValue}"));
        }

        [Fact]
        public void Solve_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => lisFinder.Find(null!));
        }

        [Fact]
        public void Solve_EmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => lisFinder.Find(""));
        }

        [Fact]
        public void Solve_WhitespaceOnlyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => lisFinder.Find("   "));
        }
        [Fact]
        public void FindLIS_EmptySequence_ReturnsZeroLength()
        {
            var (_, length) = lisFinder.FindEarliestLongestIncreasingSubarray(Array.Empty<int>());
            Assert.Equal(0, length);
        }

        [Fact]
        public void FindLIS_SingleElement_LengthOne()
        {
            var (start, length) = lisFinder.FindEarliestLongestIncreasingSubarray(new[] { 42 });
            Assert.Equal(0, start);
            Assert.Equal(1, length);
        }

        [Fact]
        public void FindLIS_AllDescending_ReturnsFirstElementOnly()
        {
            // Every element starts a new run of length 1; earliest index wins.
            var (start, length) = lisFinder.FindEarliestLongestIncreasingSubarray(new[] { 9, 5, 3, 1 });
            Assert.Equal(0, start);
            Assert.Equal(1, length);
        }

        [Fact]
        public void FindLIS_AllAscending_ReturnsWholeArray()
        {
            var (start, length) = lisFinder.FindEarliestLongestIncreasingSubarray(new[] { 1, 3, 5, 7 });
            Assert.Equal(0, start);
            Assert.Equal(4, length);
        }

        [Fact]
        public void FindLIS_TiedLength_ReturnsEarliestStart()
        {
            var (start, length) = lisFinder.FindEarliestLongestIncreasingSubarray(new[] { 5, 6, 1, 2 });
            Assert.Equal(0, start);
            Assert.Equal(2, length);
        }

        [Fact]
        public void FindLIS_EqualAdjacentValues_BreaksRun()
        {
            var (start, length) = lisFinder.FindEarliestLongestIncreasingSubarray(new[] { 1, 2, 2, 3 });
            Assert.Equal(0, start);
            Assert.Equal(2, length);
        }
        [Fact]
        public void ParseInput_TokenWithLetterSuffix_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => lisFinder.Find("12px 3"));
            Assert.Contains("12px", ex.Message);
        }
        [Fact]
        public void ParseInput_FloatingPointToken_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => lisFinder.Find("1 3.14 5"));
            Assert.Contains("3.14", ex.Message);
        }
        [Fact]
        public void ParseInput_HexToken_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => lisFinder.Find("0xFF 3"));
            Assert.Contains("0xFF", ex.Message);
        }
        [Fact]
        public void ParseInput_ErrorMessageContainsOffendingToken()
        {
            var ex = Assert.Throws<ArgumentException>(() => lisFinder.Find("1 2 BAD 4"));
            Assert.Contains("BAD", ex.Message);
        }

        [Fact]
        public void ParseInput_ErrorMessageContainsPosition()
        {
            var ex = Assert.Throws<ArgumentException>(() => lisFinder.Find("1 2 BAD 4"));
            Assert.Contains("2", ex.Message);
        }
        [Fact]
        public void Solve_OverflowToken_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => lisFinder.Find("1 9999999999 3"));
        }
    }
}
