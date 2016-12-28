namespace Executor.IO
{
    using System;
    using Exceptions;
    using Commands;
    using Contracts;

    public class CommandInterpreter : IInterpreter
    {
        private readonly IContentComparer judge;
        private readonly IDatabase repository;
        private readonly IDownloadManager downloadManager;
        private readonly IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository,
            IDownloadManager downloadManager, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.downloadManager, this.inputOutputManager);
                case "download":
                    return new DownloadFileCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "downloadasynch":
                    return new DownloadAsynchCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                case "display":
                    return new DisplayCommand(input, data, this.judge, this.repository,
                        this.downloadManager, this.inputOutputManager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
