namespace AdventOfCode2024.Solutions
{
    internal class Day02
    {
        public int Part1(string[] input)
        {
            var reports = ParseInput(input);
            return reports.Count(IsSafe);
        }

        public int Part2(string[] input)
        {
            var reports = ParseInput(input);
            return reports.Count(IsSafe) + reports.Count(x => !IsSafe(x) && ProblemDampenerCanMakeSafe(x));
        }

        private List<List<int>> ParseInput(string[] input)
        {
            return input.Select(line => line.Split(' ').Select(int.Parse).ToList()).ToList();
        }

        private bool IsSafe(List<int> report)
        {
            return (IsAscending(report) || IsDescending(report))
               && GapIsValid(report);
        }
        private bool IsAscending(List<int> list)
        {
            return list.SequenceEqual(list.OrderBy(x => x));
        }

        private bool IsDescending(List<int> list)
        {
            return list.SequenceEqual(list.OrderByDescending(x => x));
        }

        private bool GapIsValid(List<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                if (Math.Abs(list[i] - list[i + 1]) < 1 || Math.Abs(list[i] - list[i + 1]) > 3)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ProblemDampenerCanMakeSafe(List<int> report)
        {
            return report.Select((x, i) => report.Where((_, j) => j != i).ToList()).Any(IsSafe);
        }
    }
}