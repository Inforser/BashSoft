namespace Executor.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Contracts;
    using Static_Data;

    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            //test
            if (depth == 0)
            {
                depth = 101;
            }
            else
            {
                depth--;
            }

            //endTest
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");
                try
                {
                    foreach (var dir in Directory.GetDirectories(currentPath))
                    {
                        int indexOfLastSlash = dir.LastIndexOf("\\");
                        for (int i = 0; i < indexOfLastSlash; i++)
                        {
                            OutputWriter.WriteMessage("+");
                        }
                        var newDir = dir.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(newDir);
                    }
                    
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        for (int i = 0; i < indexOfLastSlash; i++)
                        {
                            OutputWriter.WriteMessage("-");
                        }
                        var newFile = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(newFile);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        if (depth != 101)
                        {
                            subFolders.Enqueue(directoryPath);
                        }
                    }

                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                int indexOfLastSlash;
                try
                {
                    string currentPath = SessionData.currentPath;
                    indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(nameof(indexOfLastSlash), 
                        ExceptionMessages.InvalidDestination);
                }

            }
            else
            {
                if (relativePath.Contains(".."))
                {
                    throw new ArgumentException("Use '..' only once!");
                }
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.currentPath = absolutePath;
        }
    }
}
