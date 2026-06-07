using Task_1.Service;

namespace Fizz.Test
{
    public class FizzBuzzTest
    {
        private readonly FizzBuzz _fizzBuzz = new();
        [Fact]
        public void GetOverlapping_ReplacesEveryThirdWord_WithFizz()
        {
            var result = _fizzBuzz.GetOverlapping("one two three four five");
            Assert.Contains("Fizz", result.Result);
        }

        [Fact]
        public void GetOverlapping_ReplacesEveryFifthWord_WithBuzz()
        {
            var result = _fizzBuzz.GetOverlapping("one two three four five");
            Assert.Contains("Buzz", result.Result);
        }

        [Fact]
        public void GetOverlapping_ReplacesFifteenthWord_WithFizzBuzz()
        {
            string input = "a b c d e f g h i j k l m n o";
            var result = _fizzBuzz.GetOverlapping(input);
            Assert.Contains("FizzBuzz", result.Result);
        }

        [Fact]
        public void GetOverlapping_CountsCoincidences_Correctly()
        {
            string input =
                "Mary had a little lamb\n" +
                "Little lamb, little lamb\n" +
                "Mary had a little lamb\n" +
                "It's fleece was white as snow";
            var result = _fizzBuzz.GetOverlapping(input);
            Assert.Equal(9, result.Count);
        }

        [Fact]
        public void GetOverlapping_KeepsNonAlphanumericChars_Unchanged()
        {
            string input = "lamb, it's fleece was white";
            var result = _fizzBuzz.GetOverlapping(input);
            Assert.Contains(",", result.Result);
            Assert.Contains("'", result.Result);
        }

        [Fact]
        public void GetOverlapping_ReturnsOriginalWord_WhenNoRuleFires()
        {
            var result = _fizzBuzz.GetOverlapping("Mary had a little");
            Assert.StartsWith("Mary had", result.Result);
        }

        [Fact]
        public void GetOverlapping_ReturnsError_WhenInputIsNull()
        {
            var result = _fizzBuzz.GetOverlapping(null);
            Assert.Equal(0, result.Count);
            Assert.False(string.IsNullOrWhiteSpace(result.Result));
        }

        [Fact]
        public void GetOverlapping_ReturnsError_WhenInputTooShort()
        {
            var result = _fizzBuzz.GetOverlapping("Hi");
            Assert.Equal(0, result.Count);
        }


        [Fact]
        public void TabCharacter_ShouldBe_Preserved()
        {
            var result = _fizzBuzz.GetOverlapping("one\ttwo\tthree\tfour\tfive");
            Assert.Contains("\t", result.Result);
        }


        [Fact]
        public void MultipleSpaces_ShouldBe_Preserved()
        {
            var result = _fizzBuzz.GetOverlapping("one  two  three  four  five");
            Assert.Contains("  ", result.Result);

        }

        [Fact]
        public void UppercaseWords_ShouldBe_Accepted()
        {
            var result = _fizzBuzz.GetOverlapping("ONE TWO THREE FOUR FIVE");
            Assert.Contains("Fizz", result.Result);
            Assert.Contains("Buzz", result.Result);
        }

        [Fact]
        public void MixedAlphanumeric_ShouldBe_OneWord()
        {
            var result = _fizzBuzz.GetOverlapping("ab1 cd2 ef3 gh4 ij5");
            Assert.Contains("Fizz", result.Result);
        }

        [Fact]
        public void NumericTokens_ShouldBe_CountedAsWords()
        {
            var result = _fizzBuzz.GetOverlapping("111 222 333 444 555");
            Assert.Contains("Fizz", result.Result);
            Assert.Contains("Buzz", result.Result);
        }
    }
}
