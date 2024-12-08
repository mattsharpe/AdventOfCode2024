namespace AdventOfCode2024.Solutions
{
    internal class Day05
    {
        public int Part1(string[] input)
        {
            var (rules, pages)= ParseInput(input);
            var validUpdates = pages.Where(x=> IsValidUpdate(x, rules)).ToList();

            return validUpdates.Sum(x => x[x.Count/2]);
        }

        public int Part2(string[] input)
        {
            var (rules, pages) = ParseInput(input);
            var invalidUpdates = pages.Where(x => !IsValidUpdate(x, rules)).ToList();
            var correctedUpdates = invalidUpdates.Select(x => CorrectOrder(x, rules)).ToList();
            return correctedUpdates.Sum(x => x[x.Count / 2]);
        }

        public (List<(int, int)> rules, IEnumerable<List<int>> pageNumbers) ParseInput(string[] input)
        {
            var rules = input.TakeWhile(line => !string.IsNullOrEmpty(line))
                .Select(rule => {
                    var pair = rule.Split('|').Select(int.Parse).ToList();
                    return (pair[0], pair[1]);
                }).ToList();

            var pageNumbers = input.SkipWhile(line => !string.IsNullOrEmpty(line))
                    .Skip(1).Select(line => line.Split(',').Select(int.Parse).ToList());

            return (rules, pageNumbers);
        }

        private bool IsValidUpdate(List<int> update, List<(int, int)> rules)
        {
            var indexMap = update.Select((value, index) => new { value, index })
                                 .ToDictionary(x => x.value, x => x.index);

            return rules.Where(rule => indexMap.ContainsKey(rule.Item1) && indexMap.ContainsKey(rule.Item2))
                        .All(rule => indexMap[rule.Item1] < indexMap[rule.Item2]);
        }

        private List<int> CorrectOrder(List<int> update, List<(int, int)> rules)
        {
            var ruleDict = rules.GroupBy(r => r.Item1)
                                .ToDictionary(g => g.Key, g => g.Select(r => r.Item2).ToList());

            update.Sort((a, b) =>
            {
                if (a == b) return 0;
                if (ruleDict.ContainsKey(a) && ruleDict[a].Contains(b)) return -1;
                if (ruleDict.ContainsKey(b) && ruleDict[b].Contains(a)) return 1;
                return 0;
            });

            return update;
        }
    }
}
