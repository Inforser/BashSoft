namespace Executor.Repository
{
    using System;
    using System.Collections.Generic;
    using IO;
    using Static_Data;
    using Contracts;

    public class RepositoryFilter : IDataFilter
    {
        public void PrintFilteredStudents(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
                    break;
                case "average":
                    FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
                    break;
                case "poor":
                    FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);     
                    counterForPrinted++;
                }
            }
        }
    }
}
