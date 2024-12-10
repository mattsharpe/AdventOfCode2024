using AdventOfCode2024.Solutions;
using System.Numerics;
using Map = System.Collections.Generic.Dictionary<System.Numerics.Complex, char>;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day06Tests
    {
        private readonly string[] _sample = [
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#...",
        ];

        private readonly string[] _input = File.ReadAllLines("Input/Day06.txt");

        private Day06 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day06();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(41, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(4602, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(6, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1703, _day.Part2(_input));
        }
    }
}