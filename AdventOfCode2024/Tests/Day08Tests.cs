using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day08Tests
    {
        private readonly string[] _sample = [
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............",
        ];

        private readonly string[] _input = File.ReadAllLines("Input/Day08.txt");

        private Day08 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day08();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(14, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(423, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(34, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1287, _day.Part2(_input));
        }
    }
}