namespace Executor.Models
{
    using System;
    using System.Collections.Generic;
    using Static_Data;
    using Contracts;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const  int MaxScoreOnExam = 100;
        private string name;
        private readonly Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.name),
                        ExceptionMessages.NullOrEmptyValue);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName => studentsByName;

        public void EnrollStudent(IStudent student) 
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                    student.UserName, this.name));
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public int CompareTo(ICourse other) => string.CompareOrdinal(this.Name, other.Name);

        public override string ToString() => this.Name;
    }
}
