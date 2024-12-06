using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day04Tests
    {
        private readonly string[] _sample = [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        ];

        private readonly string[] _input = File.ReadAllLines("Input/Day04.txt");

        private Day04 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day04();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(18, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2434, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(9, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1835, _day.Part2(_input));
        }
    }
}