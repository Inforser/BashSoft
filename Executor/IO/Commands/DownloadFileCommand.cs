#pragma warning disable 649
namespace Executor.IO.Commands
{
    using Exceptions;
    using Contracts;
    using Executor.Attributes;

    [Alias("download")]
    public class DownloadFileCommand : Command
    {
        [Inject]
        private IDownloadManager downloadManager;

        public DownloadFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public DownloadFileCommand(string input, string[] data, IContentComparer tester,
        ////    IDatabase repository, IDownloadManager downloadManager, IDirectoryManager ioManager)
        ////    : base(input, data, tester, repository, downloadManager, ioManager)
        ////{
        ////}

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string url = this.Data[1];
            this.downloadManager.Download(url);
        }
    }
}
