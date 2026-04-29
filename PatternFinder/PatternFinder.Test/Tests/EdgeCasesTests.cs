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
            var result = lisFinder.Find("-5 -3 -1 -2");
            Assert.Equal("-5 -3 -1", result.Value);
        }
        [Fact]
        public void Solve_MixedNegativeAndPositive_HandledCorrectly()
        {
            var result = lisFinder.Find("5 -2 -1 0 1");
            Assert.Equal("-2 -1 0 1",result.Value);
        }
        [Fact]
        public void Solve_MinAndMaxIntAscending_ReturnsBoth()
        {
            var result = lisFinder.Find($"{int.MinValue} {int.MaxValue}");
            Assert.Equal($"{int.MinValue} {int.MaxValue}", result.Value);
        }

        [Fact]
        public void Solve_NullInput_ThrowsArgumentNullException()
        {
            var result = lisFinder.Find(null!);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void Solve_EmptyString_ThrowsArgumentException()
        {
            var result = lisFinder.Find("");
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void Solve_WhitespaceOnlyString_ThrowsArgumentException()
        {
            var result = lisFinder.Find("   ");
            Assert.False(result.IsSuccess);
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
            var result = lisFinder.Find("12px 3");
            Assert.False(result.IsSuccess);
            Assert.Contains("12px", result.Error);
        }
        [Fact]
        public void ParseInput_FloatingPointToken_ThrowsArgumentException()
        {
            var result = lisFinder.Find("1 3.14 5");
            Assert.False(result.IsSuccess);
            Assert.Contains("3.14", result.Error);
        }
        [Fact]
        public void ParseInput_HexToken_ThrowsArgumentException()
        {
            var result = lisFinder.Find("0xFF 3");
            Assert.False(result.IsSuccess);
            Assert.Contains("0xFF", result.Error);
        }
        [Fact]
        public void ParseInput_ErrorMessageContainsPosition()
        {
            var result = lisFinder.Find("1 2 BAD 4");
            Assert.False(result.IsSuccess);
            Assert.Contains("2", result.Error);
            Assert.Contains("BAD", result.Error);
        }
        [Fact]
        public void Solve_OverflowToken_ThrowsArgumentException()
        {
            var result = lisFinder.Find("1 9999999999 3");
            Assert.False(result.IsSuccess);
            Assert.Contains("9999999999", result.Error);
        }
    }
}
