
namespace AdventOfCode2024.Solutions
{
    internal class Day08
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            return CalculateAntinodes(map).Count();
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            return CalculateAntinodes(map, true).Count();
        }

        public Dictionary<(int, int), string> ParseInput(string[] input)
        {
            return (from y in Enumerable.Range(0, input.Length)
                    from x in Enumerable.Range(0, input[0].Length)
                    select (x, y))
                    .ToDictionary(x => x, x => input[x.y][x.x].ToString());
        }

        private HashSet<(int, int)> CalculateAntinodes(Dictionary<(int x, int y), string> map, bool part2 = false)
        {
            var antinodes = new HashSet<(int, int)>();
            var frequencies = map.GroupBy(x => x.Value)
                                 .Where(x=>x.Key != ".")
                                 .ToDictionary(g => g.Key, g => g.Select(x => x.Key).ToList());

            bool IsValid((int x, int y) position)
            {
                var maxX = map.Keys.Max(p => p.x);
                var maxY = map.Keys.Max(p => p.y);

                return position.x >= 0 && position.x <= maxX &&
                       position.y >= 0 && position.y <= maxY;
            }

            foreach (var frequency in frequencies)
            {
                var positions = frequency.Value;
                for (int i = 0; i < positions.Count; i++)
                {
                    for (int j = i + 1; j < positions.Count; j++)
                    {
                        var first = positions[i];
                        var second = positions[j];
                        var dx = second.x - first.x;
                        var dy = second.y - first.y;

                        var antinode1 = (first.x - dx, first.y - dy);
                        var antinode2 = (second.x + dx, second.y + dy);

                        if (IsValid(antinode1))
                        {
                            antinodes.Add(antinode1);
                        }
                        if (IsValid(antinode2))
                        {
                            antinodes.Add(antinode2);
                        }

                        if (part2)
                        {
                            antinodes.Add(first);
                            antinodes.Add(second);
                            while (IsValid(antinode1) || IsValid(antinode2))
                            {
                                if (IsValid(antinode1))
                                {
                                    antinodes.Add(antinode1);
                                    antinode1 = (antinode1.Item1 - dx, antinode1.Item2 - dy);
                                }
                                if (IsValid(antinode2))
                                {
                                    antinodes.Add(antinode2);
                                    antinode2 = (antinode2.Item1 + dx, antinode2.Item2 + dy);
                                }
                            }
                        }
                    }                    
                }
            }

            return antinodes;
        }
    }
}