
namespace AdventOfCode2024.Solutions
{
    internal class Day07
    {
        public long Part1(string[] input)
        {
            var numbers = ParseInput(input);

            return numbers.Where(x => CanSolve(x.Key, 0, x.Value))
                    .Sum(x => x.Key);
        }

        public long Part2(string[] input)
        {
            var numbers = ParseInput(input);

            return numbers.Where(x => CanSolve(x.Key, 0, x.Value, true))
                    .Sum(x => x.Key);
        }

        public Dictionary<long, List<long>> ParseInput(string[] input)
        {
            return input.Select(x => x.Split(": "))
                .ToDictionary(x => Convert.ToInt64(x[0]), x => x[1].Split(" ").Select(x => Convert.ToInt64(x)).ToList());
        }

        private bool CanSolve(long answer, long current, IEnumerable<long> numbers, bool part2 = false)
        {
            if (!numbers.Any())
                return answer == current;

            if(current > answer)
                return false;

            var first = numbers.First();
            var list = numbers.Skip(1);

            var addResult = CanSolve(answer, current + first, list, part2);
            var multiplyResult = CanSolve(answer, current * first, list, part2);
            bool concatenateResult = false;
            
            if (part2) {
                concatenateResult = CanSolve(answer, long.Parse($"{current}{first}"), list, part2);
            }

            return addResult || multiplyResult || concatenateResult;
        }

    }
}