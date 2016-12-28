#pragma warning disable 649
namespace Executor.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;
    using Executor.Attributes;

    [Alias("display")]
    public class DisplayCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data)
            : base(input, data)
        {
        }
        
        ////public DisplayCommand(string input, string[] data, IContentComparer tester, 
        ////    IDatabase repository, IDownloadManager downloadManager, IDirectoryManager ioManager) 
        ////    : base(input, data, tester, repository, downloadManager, ioManager)
        ////{
        ////}

        public override void Execute()
        {
            var data = this.Data;
            if (data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            var entityToDisplay = data[1].ToLower();
            var sortType = data[2];
            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                var studentComparator = this.CreateStudentComparator(sortType);
                var list = this.repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                var courseComparator = this.CreateCourseComparator(sortType);
                var list = this.repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }

        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((s1, s2) => s1.CompareTo(s2));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((s1, s2) => s2.CompareTo(s1));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((c1, c2) => c1.CompareTo(c2));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((c1, c2) => c2.CompareTo(c1));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
