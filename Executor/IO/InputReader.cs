namespace Executor.IO
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Static_Data;

    public class InputReader : IReader
    {
        private const string EndCommand1 = "quit";
        private const string EndCommand2 = "exit";
        private readonly IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }
        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}>");
            string input = Console.ReadLine();
            input = input?.Trim();

            while (input != EndCommand1 && input != EndCommand2)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    this.interpreter.InterpredCommand(input);
                }
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
            }

            if (SessionData.taskPool.Count != 0)
            {
                Task.WaitAll(SessionData.taskPool.ToArray());
            }
        }
    }
}
