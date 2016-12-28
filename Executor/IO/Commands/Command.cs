namespace Executor.IO.Commands
{
    using Exceptions;
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        ////private IContentComparer tester;
        ////private IDatabase repository;
        ////private IDownloadManager downloadManager;
        ////private IDirectoryManager inputOutputManager;

        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        ////protected Command(string input, string[] data, IContentComparer tester, IDatabase repository,
        ////    IDownloadManager downloadManager, IDirectoryManager ioManager)
        ////{
        ////    this.Input = input;
        ////    this.Data = data;
        ////    this.Tester = tester;
        ////    this.Repository = repository;
        ////    this.DownloadManager = downloadManager;
        ////    this.InputOutputManager = ioManager;
        ////}

        public string Input
        {
            get { return this.input; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException(value);
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new InvalidCommandException(this.Input);
                }

                this.data = value;
            }
        }

        ////protected IDatabase Repository
        ////{
        ////    get { return this.repository; }
        ////    private set
        ////    {
        ////        if (value == null)
        ////        {
        ////            throw new ArgumentNullException();
        ////        }

        ////        this.repository = value;
        ////    }
        ////}

        ////protected IContentComparer Tester
        ////{
        ////    get { return this.tester; }
        ////    private set
        ////    {
        ////        if (value == null)
        ////        {
        ////            throw new ArgumentNullException();
        ////        }

        ////        this.tester = value;
        ////    }
        ////}

        ////protected IDirectoryManager InputOutputManager
        ////{
        ////    get { return this.inputOutputManager; }
        ////    private set
        ////    {
        ////        if (value == null)
        ////        {
        ////            throw new ArgumentNullException();
        ////        }

        ////        this.inputOutputManager = value;
        ////    }
        ////}

        ////protected IDownloadManager DownloadManager
        ////{
        ////    get { return this.downloadManager; }
        ////    private set
        ////    {
        ////        if (value == null)
        ////        {
        ////            throw new ArgumentNullException();
        ////        }

        ////        this.downloadManager = value;
        ////    }
        ////}

        public abstract void Execute();
    }
}
