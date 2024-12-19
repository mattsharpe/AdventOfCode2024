namespace AdventOfCode2024.Solutions
{
    internal class Day11
    {
        public long Part1(string[] input)
        {
            var stones = ParseInput(input);
            return Simulate(stones);
        }

        public long Part2(string[] input)
        {
            var stones = ParseInput(input);
            return SimulateWithDictionary(stones);
        }

        List<long> ParseInput(string[] input)
        {
            return input[0].Split(' ').Select(long.Parse).ToList();
        }

        private int Simulate(List<long> stones)
        {
            for (int blink = 0; blink < 25; blink++)
            {
                List<long> newStones = [];
                foreach (var stone in stones)
                {
                    if (stone == 0)
                    {
                        newStones.Add(1);
                    }
                    else if (stone.ToString().Length % 2 == 0)
                    {
                        string s = stone.ToString();
                        int mid = s.Length / 2;
                        string left = s[..mid];
                        string right = s[mid..];
                        newStones.Add(long.Parse(left));
                        newStones.Add(long.Parse(right));
                    }
                    else
                    {
                        newStones.Add(stone * 2024);
                    }
                }
                stones = newStones;
            }

            return stones.Count;
        }

        private long SimulateWithDictionary(List<long> list)
        {
            var stones = list.ToDictionary(x => x, x => 1L);

            for (int blink = 0; blink < 75; blink++)
            {
                Dictionary<long, long> newStones = [];

                void AddOrIncrement(long value, long count)
                {
                    if (newStones.ContainsKey(value))
                    {
                        newStones[value] += count;
                    }
                    else
                    {
                        newStones[value] = count;
                    }
                }

                foreach (var kvp in stones)
                {
                    var stone = kvp.Key;
                    var count = kvp.Value;

                    if (stone == 0)
                    {
                        AddOrIncrement(1, count);
                    }
                    else if (stone.ToString().Length % 2 == 0)
                    {
                        string s = stone.ToString();
                        int mid = s.Length / 2;
                        string left = s[..mid];
                        string right = s[mid..];
                        long leftVal = string.IsNullOrEmpty(left) ? 0 : long.Parse(left);
                        long rightVal = string.IsNullOrEmpty(right) ? 0 : long.Parse(right);
                        AddOrIncrement(leftVal, count);
                        AddOrIncrement(rightVal, count);
                    }
                    else
                    {
                        long newVal = stone * 2024;
                        AddOrIncrement(newVal, count);
                    }
                }
                stones = newStones;
            }

            return stones.Values.Sum();
        }
    }
}