using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day12Tests
    {
        private readonly string[] _sample = [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC",
        ];

        private readonly string[] _sample2 = [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO",
        ];

        private readonly string[] _sample3 = [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE",
        ];

        private readonly string[] _sample4 = [
            "EEEEE",
            "EXXXX",
            "EEEEE",
            "EXXXX",
            "EEEEE",
        ];

        private readonly string[] _sample5 = [
            "AAAAAA",
            "AAABBA",
            "AAABBA",
            "ABBAAA",
            "ABBAAA",
            "AAAAAA",
        ];

        private readonly string[] _input = File.ReadAllLines("Input/Day12.txt");

        private Day12 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day12();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(140, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1Sample2()
        {
            Assert.AreEqual(772, _day.Part1(_sample2));
        }

        [TestMethod]
        public void Part1Sample3()
        {
            Assert.AreEqual(1930, _day.Part1(_sample3));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1375574, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(80, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2Sample2()
        {
            Assert.AreEqual(436, _day.Part2(_sample2));
        }


        [TestMethod]
        public void Part2Sample3()
        {
            Assert.AreEqual(1206, _day.Part2(_sample3));
        }

        [TestMethod]
        public void Part2Sample4()
        {
            Assert.AreEqual(236, _day.Part2(_sample4));
        }

        [TestMethod]
        public void Part2Sample5()
        {
            Assert.AreEqual(368, _day.Part2(_sample5));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(830566, _day.Part2(_input));
        }
    }
}