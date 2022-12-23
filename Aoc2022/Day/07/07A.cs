using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._07
{
    public class _07A
    {
        public static FileModel BaseDirectory = new FileModel()
        {
            Name = String.Empty,
            Size = 0,
            Content = new List<FileModel>(),
            IsDir = true,
            Depth = 0,
        };
        public static List<FileModel> AllDirs = new();
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/07/input.txt").ToList();
            var currentDir = "";
            var currentPathFileModel = BaseDirectory;
            currentPathFileModel.Parent = BaseDirectory;
            AllDirs.Add(BaseDirectory);

            for (var indexLine = 0; indexLine < lines.Count; indexLine++)
            {
                var line = lines[indexLine];
                var firstChar = line.Substring(0, 1);

                if (firstChar == "$")
                {
                    var cmd = line.Substring(2, 2);

                    switch (cmd)
                    {
                        case "ls":
                            var whileLoopContinue = true;
                            for (int i = 1; whileLoopContinue; i++)
                            {
                                var readerLine = String.Empty;
                                try
                                {
                                    readerLine = lines[indexLine + i];
                                }
                                catch (Exception ex)
                                {
                                    whileLoopContinue = false;
                                }
                                if (!whileLoopContinue) continue;

                                var readerFirstChar = readerLine.Substring(0, 1);
                                if (readerFirstChar == "$")
                                {
                                    whileLoopContinue = false;
                                    continue;
                                }

                                if (readerFirstChar == "d")
                                {
                                    var fileModelDir = new FileModel()
                                    {
                                        Name = readerLine.Split("dir ")[1],
                                        Content = new List<FileModel>(),
                                        Parent = currentPathFileModel,
                                        IsDir = true,
                                        Depth = currentPathFileModel.Depth + 1,
                                    };
                                    currentPathFileModel.Content.Add(fileModelDir);
                                    AllDirs.Add(fileModelDir);
                                    continue;
                                }

                                var fileModel = new FileModel()
                                {
                                    Name = readerLine.Split(" ")[1],
                                    Size = int.Parse(readerLine.Split(" ")[0]),
                                    Content = new List<FileModel>(),
                                    Parent = currentPathFileModel,
                                };
                                currentPathFileModel.Content.Add(fileModel);
                            }
                            break;
                        case "cd":
                            var changeDirPath = line.Split("$ cd ")[1];
                            if (changeDirPath == "..")
                            {
                                currentPathFileModel = currentPathFileModel.Parent;
                                continue;
                            }

                            if (changeDirPath == "/")
                            {
                                currentPathFileModel = BaseDirectory;
                                continue;
                            }

                            var changeFileDir = currentPathFileModel.Content.Where(x => x.Name == changeDirPath).FirstOrDefault();
                            currentPathFileModel = changeFileDir;
                            break;
                    }
                }
            }

            var dirsWithNoDirs = AllDirs.Where(x => x.Content.All(y => y.Size != 0)).ToList();
            foreach(var directory in dirsWithNoDirs)
            {
                foreach(var file in directory.Content)
                {
                    directory.Size += file.Size;
                }
            }

            foreach (var directory in AllDirs.OrderByDescending(x => x.Depth))
            {
                var dirSize = 0;
                foreach (var file in directory.Content)
                {
                    dirSize += file.Size;
                }
                directory.Size = dirSize;
            }

            var test = BaseDirectory;
            var allDirsunder100k = AllDirs.Where(x => x.Size <= 100000).ToList();
            var totalSize = 0;
            foreach (var dir in allDirsunder100k)
            {
                totalSize += dir.Size;
            }
            Console.WriteLine($"{nameof(_07)} A:{totalSize}");
        }
    }

    public class FileModel
    {
        public bool IsDir { get; set; }
        public FileModel Parent { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public List<FileModel> Content { get; set; }
        public int Depth { get; set; }
    }
}
