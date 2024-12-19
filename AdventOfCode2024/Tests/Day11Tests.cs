using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day11Tests
    {
        private readonly string[] _sample = { "125 17" };

        private readonly string[] _input = File.ReadAllLines("Input/Day11.txt");

        private Day11 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day11();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(55312, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(231278, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(65601038650482, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(274229228071551, _day.Part2(_input));
        }
    }
}