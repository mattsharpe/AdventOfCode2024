namespace AdventOfCode2024.Solutions
{
    internal class Day12
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            var regions = FindRegions(map);
            return regions.Sum(x => x.Area * x.Perimeter);
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            var regions = FindRegions(map);

            return regions.Sum(x=> x.Area * x.Sides);
        }

        public Dictionary<(int x, int y), char> ParseInput(string[] input)
        {
            return (from y in Enumerable.Range(0, input.Length)
                    from x in Enumerable.Range(0, input[0].Length)
                    select (x, y))
                    .ToDictionary(x => x, x => input[x.y][x.x]);
        }

        private static readonly (int x, int y)[] Directions = [
            (0, -1),
            (0, 1),
            (-1, 0),
            (1, 0)
        ];

        List<Region> FindRegions(Dictionary<(int x,int y),char> map)
        {
            HashSet<(int x, int y)> visited = [];
            List<Region> regions = [];

            var corners = new (int dx1, int dy1, int dx2, int dy2)[]
{
                (0,-1, 1,0),
                (1,0, 0,1),
                (0,1, -1,0),
                (-1,0, 0,-1)
};

            foreach (var key in map.Keys)
            {
                if (!visited.Contains(key))
                {
                    char currentPlant = map[key];
                    Region region = new(currentPlant);
                    FillRegion(map, visited, key, region);
                    regions.Add(region);

                    region.Sides = region.Cells.Sum(cell =>
                    corners.Count(corner =>
                    {
                        var (dx1, dy1, dx2, dy2) = corner;
                        var s1Pos = (cell.x + dx1, cell.y + dy1);
                        var s2Pos = (cell.x + dx2, cell.y + dy2);
                        var cornerPos = (cell.x + dx1 + dx2, cell.y + dy1 + dy2);

                        var s1 = map.GetValueOrDefault(s1Pos);
                        var s2 = map.GetValueOrDefault(s2Pos);
                        var c = map.GetValueOrDefault(cornerPos);

                        return region.PlantType != s1 && region.PlantType != s2 ||
                               region.PlantType == s1 && region.PlantType == s2 && region.PlantType != c;
                    }));
                }
            }

            return regions;
        }

        public static void FillRegion(Dictionary<(int, int), char> grid, HashSet<(int, int)> visited, (int,int) start, Region region)
        {
            Queue<(int x, int y)> queue = [];
            queue.Enqueue(start);
            visited.Add(start);
            region.Area++;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                region.Cells.Add(current);

                foreach (var (dx, dy) in Directions)
                {
                    var neighbour = (current.x + dx, current.y + dy);

                    grid.GetValueOrDefault(neighbour);
                    bool isOutOfBounds = !grid.ContainsKey(neighbour);
                    bool isDifferentPlant = !isOutOfBounds && grid[neighbour] != region.PlantType;

                    if (isOutOfBounds || isDifferentPlant)
                    {
                        region.Perimeter++;
                    }
                    else if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                        region.Area++;
                    }
                }
            }
        }
    }

    class Region(char plantType)
    {
        public char PlantType { get; set; } = plantType;
        public int Area { get; set; } = 0;
        public int Sides { get; set; } = 0;
        public int Perimeter { get; set; } = 0;
        public HashSet<(int x, int y)> Cells { get; set; } = [];
    }
}