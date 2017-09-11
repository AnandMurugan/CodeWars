using Xunit;

namespace KataPrograms.Tests
{
    public class KataTests
    {
        [Fact()]
        public void ValidPhoneNumberTest()
        {
            Assert.True(Kata.ValidPhoneNumber("(123) 456-7890"));
            Assert.False(Kata.ValidPhoneNumber("ABC(123) 456-7890test"));
            Assert.False(Kata.ValidPhoneNumber("(111) 5X5-2345"));
            Assert.True(Kata.ValidPhoneNumber("(010) 515-2345"));

            Assert.False(Kata.ValidPhoneNumber("(123)456-7890"));
            Assert.False(Kata.ValidPhoneNumber("(12) 456-7890"));
            Assert.False(Kata.ValidPhoneNumber("(123) 45-7890"));
            Assert.False(Kata.ValidPhoneNumber("(123) 456-789"));
            Assert.False(Kata.ValidPhoneNumber("(123)  456-7890"));
            Assert.False(Kata.ValidPhoneNumber("(123) 456--7890"));

            Assert.False(Kata.ValidPhoneNumber("123) 456-7890"));
            Assert.False(Kata.ValidPhoneNumber("(123 456-7890"));
            Assert.False(Kata.ValidPhoneNumber("(123) 4567890"));

            Assert.False(Kata.ValidPhoneNumber("(123)   456-7890"));
        }
    }
}