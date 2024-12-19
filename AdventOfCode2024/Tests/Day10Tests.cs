using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day10Tests
    {
        private readonly string[] _sample = {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732",
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day10.txt");

        private Day10 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day10();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(36, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(629, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(81, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1242, _day.Part2(_input));
        }
    }
}