﻿namespace Executor.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using Static_Data;
    using Contracts;

    public class RepositorySorter : IDataSorter
    {
        public void PrintSortedStudents(Dictionary<string, double> studentsMarks,
            string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {    
                PrintStudents(studentsMarks.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value)); 
            }
            else if (comparison == "descending")
            {  
                PrintStudents(studentsMarks.OrderByDescending(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {               
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}
