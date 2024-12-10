using System.Numerics;

namespace AdventOfCode2024.Solutions
{
    internal class Day06
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            return ExploreMaze(map, new Complex(0,-1)).Visited.Count();
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            int result = 0;
            var guardPath = ExploreMaze(map, new Complex(0, -1)).Visited;

            foreach (var location in guardPath.Select(x=>((int)x.Real, (int)x.Imaginary)).Where(x=> map[x] == "."))
            {
                map[location] = "#";
                var (Visited, Loop) = ExploreMaze(map, new Complex(0, -1));
                if (Loop)
                {
                    result++;
                }
                map[location] = ".";
            }
            return result;
        }

        public Dictionary<(int, int), string> ParseInput(string[] input)
        {

            return (from y in Enumerable.Range(0, input.Length)
                    from x in Enumerable.Range(0, input[0].Length)
                    select (x, y))
                    .ToDictionary(x => x, x => input[x.y][x.x].ToString());
        }

        private (IEnumerable<Complex> Visited,bool Loop) ExploreMaze(Dictionary<(int x, int y), string> map, Complex direction)
        {
            var start = map.Single(x => x.Value == "^").Key;
            var visited = new HashSet<(Complex position, Complex direction)>();
            var position = new Complex(start.x, start.y);

            while (true)
            {
                var nextPosition = position + direction;
                var nextTuple = ((int)nextPosition.Real, (int)nextPosition.Imaginary);

                string? nextValue = map.GetValueOrDefault(nextTuple, null);
                if (visited.Contains((nextPosition, direction)))
                {
                    return (visited.Select(x => x.position).Distinct(), true);
                }
                switch (nextValue)
                {
                    case null:
                        return (visited.Select(x=>x.position).Distinct(),false);
                    case "#":
                        direction = RotateRight(direction);
                        break;
                    default:
                        if (visited.Contains((nextPosition, direction)))
                        {
                            return (visited.Select(x => x.position).Distinct(), true);
                        }
                        position = nextPosition;
                        visited.Add((nextPosition, direction));
                        break;
                }
            }
        }

        private Complex RotateRight(Complex direction)
        {
            return direction * new Complex(0,1);
        }
    }
}