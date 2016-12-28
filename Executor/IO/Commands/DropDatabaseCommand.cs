#pragma warning disable 649
namespace Executor.IO.Commands
{
    using Exceptions;
    using Contracts;
    using Executor.Attributes;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public DropDatabaseCommand(string input, string[] data, IContentComparer tester,
        ////    IDatabase repository, IDownloadManager downloadManager, IDirectoryManager ioManager) 
        ////    : base(input, data, tester, repository, downloadManager, ioManager)
        ////{
        ////}

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
