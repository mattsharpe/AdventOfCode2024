using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solutions
{
    internal class Day03
    {
        public int Part1(string[] input)
        {
            return ParseInput(input).Sum(x => x.a * x.b);
        }

        public int Part2(string[] input)
        {
            var sanitised = Regex.Replace(string.Join("", input), @"don\'t\(\).*?(?:do\(\)|$)", "");

            return ParseInput([sanitised]).Sum(x => x.a * x.b);
        }

        public List<(int a, int b)> ParseInput(string[] input)
        {
            var result = new List<(int a, int b)>();

            foreach (var line in input)
            {
                var matches = Regex.Matches(line, @"mul\((\d+),(\d+)\)");
                foreach(Match match in matches)
                {
                    var a = int.Parse(match.Groups[1].Value);
                    var b = int.Parse(match.Groups[2].Value);
                    result.Add((a, b));
                }
            }
            return result;
        }
    }
}