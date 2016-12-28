namespace Executor.IO.Commands
{
    using System.Text;
    using Exceptions;
    using Executor.Attributes;

    [Alias("help")]
    public class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data)
            : base(input, data)
        {
        }

        ////public GetHelpCommand(string input, string[] data, IContentComparer tester,
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

            GetHelpCommand.DisplayHelp();
        }
        
        private static void DisplayHelp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{new string('_', 125)}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("open file - open {fileName}");
            stringBuilder.AppendLine("make directory - mkdir {nameOfFolder}");
            stringBuilder.AppendLine("traverse directory - ls ({depth})");
            stringBuilder.AppendLine("comparing files - cmp absolutePath1 absolutePath2");
            stringBuilder.AppendLine("change directory - cdRel relativePath or \"..\" for level up");
            stringBuilder.AppendLine("change directory - cdAbs absolutePath");
            stringBuilder.AppendLine("read students data base - readDb fileName");
            stringBuilder.AppendLine("drop students data base - dropDb");
            stringBuilder.AppendLine("filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)");
            stringBuilder.AppendLine("show course/student information - show {courseName} ({studenName})");
            stringBuilder.AppendLine("order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)");
            stringBuilder.AppendLine("display sorted courses/students - display {courses/students} {ascending/descending}");
            stringBuilder.AppendLine("download file - download URL (saved in current directory)");
            stringBuilder.AppendLine("download file asinchronously - downloadAsynch URL (saved in the current directory)");
            stringBuilder.AppendLine("get help – help");
            stringBuilder.AppendLine("{}->parameter | ({})->optional parameter");
            stringBuilder.AppendLine($"{new string('_', 125)}");
            stringBuilder.AppendLine();
            OutputWriter.WriteMessageOnNewLine(stringBuilder.ToString());
        }
    }
}
