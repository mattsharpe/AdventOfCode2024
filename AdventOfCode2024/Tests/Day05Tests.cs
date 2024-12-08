using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day05Tests
    {
        private readonly string[] _sample = [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47",
        ];

        private readonly string[] _input = File.ReadAllLines("Input/Day05.txt");

        private Day05 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day05();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(143, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(5588, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(123, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(5331, _day.Part2(_input));
        }
    }
}