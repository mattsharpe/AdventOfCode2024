namespace AdventOfCode2024.Solutions
{
    internal class Day09
    {

        private readonly Dictionary<int, int> _searchStartBySpaceSize = new();

        public long Part1(string[] input)
        {
            var (disk,files) = ParseInput(input.Single());
            MoveFilesSimple(disk);
            return Checksum(disk);
        }

        public long Part2(string[] input)
        {
            var (disk, files) = ParseInput(input.Single());
            MoveFiles(disk, files);
            return Checksum(disk);
        }


        private (List<int> disk, List<Block> files) ParseInput(string input)
        {
            var disk = new List<int>();
            var files = new List<Block>();

            int index = 0;
            int fileId = 0;

            while (index < input.Length)
            {
                var fileSize = input[index++] - '0';
                int fileStart = disk.Count;

                // Append the file if size > 0
                if (fileSize > 0)
                {
                    disk.AddRange(Enumerable.Repeat(fileId, fileSize));
                    files.Add(new Block { Id = fileId, Start = fileStart, Size = fileSize });
                }

                fileId++;

                if (index >= input.Length) break;

                var space = input[index++] - '0';
                if (space > 0)
                {
                    disk.AddRange(Enumerable.Repeat(-1, space));
                }
            }

            return (disk, files);

        }

        void MoveFilesSimple(List<int> disk)
        {
            int leftIndex = 0;
            int rightIndex = disk.Count - 1;

            while (leftIndex < rightIndex)
            {
                while (leftIndex < rightIndex && disk[leftIndex] != -1)
                {
                    leftIndex++;
                }

                while (leftIndex < rightIndex && disk[rightIndex] == -1)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    disk[leftIndex] = disk[rightIndex];
                    disk[rightIndex] = -1;
                }
            }
        }

        long Checksum(List<int> disk)
        {
            return disk
                .Select((file, index) => file != -1 ? (long)index * file : 0)
                .Sum();
        }

        private void MoveFiles(List<int> disk, List<Block> allFiles)
        {
            while (allFiles.Count > 0)
            {
                var file = allFiles[allFiles.Count - 1];
                allFiles.RemoveAt(allFiles.Count - 1);

                MoveFile(disk, file);
            }
        }

        private void MoveFile(List<int> disk, Block file)
        {
            int spaceStart = FindSpaceFor(disk, file.Size);
            if (spaceStart == -1) return;
            if (spaceStart > file.Start) return;

            _searchStartBySpaceSize[file.Size] = spaceStart;

            for (int n = 0; n < file.Size; n++)
            {
                disk[file.Start + n] = -1;
                disk[spaceStart + n] = file.Id;
            }
        }

        private int FindSpaceFor(List<int> disk, int fileSize)
        {
            if (!_searchStartBySpaceSize.TryGetValue(fileSize, out int startPoint))
            {
                startPoint = -1;
            }

            int afterThis = startPoint - 1;

            if (afterThis < -1)
            {
                afterThis = -1;
            }

            while (true)
            {
                var space = FindNextSpace(disk, afterThis);
                if (space == null) return -1;

                int spaceSize = space.End - space.Start + 1;
                if (spaceSize >= fileSize) return space.Start;

                afterThis = space.End;
            }
        }

        private DiskRange? FindNextSpace(List<int> disk, int afterThis)
        {
            int start = afterThis;

            while (true)
            {
                start += 1;
                if (start >= disk.Count) return null;
                if (disk[start] == -1) break;
            }

            int end = start;
            while (true)
            {
                if (end + 1 >= disk.Count || disk[end + 1] != -1)
                {
                    return new DiskRange { Start = start, End = end };
                }
                end += 1;
            }
        }
    }
    
    class Block
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int Size { get; set; }
    }

    class DiskRange
    {
        public int Start;
        public int End;
    }
}