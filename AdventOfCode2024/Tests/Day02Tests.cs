using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private readonly string[] _sample = {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day02.txt");

        private Day02 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day02();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(2, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(510, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(4, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(553, _day.Part2(_input));
        }
    }
}