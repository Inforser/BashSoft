#pragma warning disable 649
namespace Executor.IO.Commands
{
    using Exceptions;
    using Contracts;
    using Executor.Attributes;

    [Alias("downloadasynch")]
    public class DownloadAsynchCommand : Command
    {
        [Inject]
        private IDownloadManager downloadManager;

        public DownloadAsynchCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public DownloadAsynchCommand(string input, string[] data, IContentComparer tester,
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
            this.downloadManager.DownloadAsync(url);
        }
    }
}
