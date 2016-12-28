#pragma warning disable 649
namespace Executor.IO.Commands
{
    using Exceptions;
    using Contracts;
    using Executor.Attributes;

    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer tester;

        public CompareFilesCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public CompareFilesCommand(string input, string[] data, IContentComparer tester,
        ////    IDatabase repository, IDownloadManager downloadManager, IDirectoryManager ioManager)
        ////    : base(input, data, tester, repository, downloadManager, ioManager)
        ////{
        ////}

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.tester.CompareContent(firstPath, secondPath);
        }
    }
}
