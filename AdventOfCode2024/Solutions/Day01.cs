namespace AdventOfCode2024.Solutions
{
    internal class Day01
    {
        public int Part1(string[] input)
        {
            var numbers  = ParseInput(input);
            return numbers.a.Zip(numbers.b, (x, y) => Math.Abs(x - y)).Sum();
        }

        public int Part2(string[] input)
        {
            var numbers  = ParseInput(input);
            
            var counts = numbers.b.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            
            return numbers.a.Select(x => x * counts.GetValueOrDefault(x,0)).Sum();
        }

        public (List<int> a, List<int> b) ParseInput(string[] input)
        {
            var a = new List<int>();
            var b = new List<int>();

            foreach (var line in input)
            {
                var split = line.Split("   ");
                a.Add(int.Parse(split[0]));
                b.Add(int.Parse(split[1]));
            }
            a.Sort();
            b.Sort();

            return (a, b);
        }
    }
}