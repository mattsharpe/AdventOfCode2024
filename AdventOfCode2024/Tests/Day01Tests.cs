using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day01Tests
    {
        private readonly string[] _sample = {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
            };

        private readonly string[] _input = File.ReadAllLines("Input/Day01.txt");

        private Day01 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day01();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(11, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1320851, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(31, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(26859182, _day.Part2(_input));
        }
    }
}