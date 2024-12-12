using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day07Tests
    {
        private readonly string[] _sample = [
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20",
         ];

        private readonly string[] _input = File.ReadAllLines("Input/Day07.txt");

        private Day07 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day07();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(3749, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(10741443549536, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(11387, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(500335179214836, _day.Part2(_input));
        }
    }
}