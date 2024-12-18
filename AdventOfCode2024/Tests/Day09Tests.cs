using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day09Tests
    {
        private readonly string[] _sample = { "2333133121414131402" };

        private readonly string[] _input = File.ReadAllLines("Input/Day09.txt");

        private Day09 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day09();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(1928, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(6258319840548, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(2858, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(6286182965311, _day.Part2(_input));
        }
    }
}