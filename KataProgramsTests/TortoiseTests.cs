using System;
using Xunit;

namespace KataPrograms.Tests
{
    public class TortoiseTests
    {
        [Fact()]
        public void RaceTest()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.Equal(new int[] { 0, 32, 18 }, Tortoise.Race(720, 850, 70));
            Assert.Equal(new int[] { 3, 21, 49 }, Tortoise.Race(80, 91, 37));
            Assert.Equal(new int[] { 2, 0, 0 }, Tortoise.Race(80, 100, 40));
        }
    }
}