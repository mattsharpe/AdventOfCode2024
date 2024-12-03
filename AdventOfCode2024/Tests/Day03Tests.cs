using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Tests
{
    [TestClass]
    public class Day03Tests
    {
        private readonly string[] _sample  = [ "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" ];
        private readonly string[] _sample2 = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"];

        private readonly string[] _input = File.ReadAllLines("Input/Day03.txt");

        private Day03 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day03();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(161, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(191_183_308, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(48, _day.Part2(_sample2));
        }

        [TestMethod]
        public void Part2()
        {
            //95_786_593 too high
            //95786593
            //107_752_201
            Assert.AreEqual(92082041, _day.Part2(_input));
        }
    }
}