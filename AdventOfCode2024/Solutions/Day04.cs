using System.Text;

namespace AdventOfCode2024.Solutions
{
    internal class Day04
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            return CountXmasOccurences(map);
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            return CountCrossMasOccurences(map);
        }

        private int CountCrossMasOccurences(Dictionary<(int, int), string> map)
        {
            return map.Where(x => x.Value == "A")
                      .Select(point => new[]
                      {
                          (point.Key.Item1 - 1, point.Key.Item2 - 1),
                          (point.Key.Item1 + 1, point.Key.Item2 - 1),
                          (point.Key.Item1 - 1, point.Key.Item2 + 1),
                          (point.Key.Item1 + 1, point.Key.Item2 + 1)
                      }
                      .Select(corner => map.GetValueOrDefault(corner)).ToList())
                      .Count(corners => corners.All(x => x == "M" || x == "S")
                                        && corners[0] != corners[3]
                                        && corners[1] != corners[2]);
        }

        public Dictionary<(int, int), string> ParseInput(string[] input) {

            return (from y in Enumerable.Range(0, input.Length)
                    from x in Enumerable.Range(0, input[0].Length)
                    select (x, y))
                    .ToDictionary(x => x, x => input[x.y][x.x].ToString());
        }

        public int CountXmasOccurences(Dictionary<(int, int), string> map)
        {
            return map.Where(x => x.Value == "X")
                        .SelectMany(point => Directions.Select(direction =>
                        {
                            var sb = new StringBuilder("X");
                            for (int i = 1; i <= 3; i++)
                            {
                                var nextLetter = map.GetValueOrDefault((point.Key.Item1 + (direction.Item1 * i), point.Key.Item2 + (direction.Item2 * i)), "");
                                sb.Append(nextLetter);
                            }
                            return sb.ToString();
                        }))
                        .Count(word => word == "XMAS");
        }

        IEnumerable<(int, int)> Directions =>
            [
                (-1, -1), (0, -1), (1, -1),
                (-1, 0),(0, 1),
                (-1, 1), (1, 0), (1, 1)
            ];
        
    }
}