﻿#pragma warning disable 649
namespace Executor.IO.Commands
{
    using Exceptions;
    using Executor.Attributes;
    using Executor.Contracts;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public ChangeRelativePathCommand(string input, string[] data, IContentComparer tester,
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

            string relPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}
