
namespace AdventOfCode2024.Solutions
{
    internal class Day10
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            return map.Where(x => x.Value == 0)
                .Sum(x=> ExplorePaths(map, x.Key, true).Count());
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            return map.Where(x => x.Value == 0)
                .Sum(x => ExplorePaths(map, x.Key).Count());
        }

        public Dictionary<(int x, int y), int> ParseInput(string[] input)
        {
            return (from y in Enumerable.Range(0, input.Length)
                    from x in Enumerable.Range(0, input[0].Length)
                    select (x, y))
                    .ToDictionary(x => x, x => input[x.y][x.x] -'0');
        }

        private static readonly (int x, int y)[] Directions = [
            (0, -1),
            (0, 1),
            (-1, 0),
            (1, 0)
        ];

        private IEnumerable<(int, int)> ExplorePaths(Dictionary<(int, int), int> map, (int, int) start, bool unique = false)
        {
            var queue = new Queue<((int x, int y) pos, int currentValue)>();
            List<(int,int)> results = [];

            queue.Enqueue((start, 0));

            while (queue.Count != 0)
            {
                var (currentPos, currentValue) = queue.Dequeue();

                if (currentValue == 9)
                {
                    results.Add(currentPos);
                } 
                else
                {
                    foreach (var (dx, dy) in Directions)
                    {
                        var neighbor = (x: currentPos.x + dx, y: currentPos.y + dy);
                        var neighborValue = map.GetValueOrDefault(neighbor);
                        
                        if (neighborValue == currentValue + 1)
                        {
                            queue.Enqueue((neighbor, neighborValue));
                        }
                    }
                }
            }

            return unique ? results.ToHashSet() : results;
        }
    }
}