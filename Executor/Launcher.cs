namespace Executor
{
    using System;
    using IO;
    using Judge;
    using Network;
    using Contracts;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            Console.WindowWidth = 150;

            IContentComparer tester = new Tester();
            IDownloadManager downloadManager = new DownloadManager();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repository = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repository, downloadManager, ioManager);
            IReader inputReader = new InputReader(currentInterpreter);

            inputReader.StartReadingCommands();
        }
    }
}