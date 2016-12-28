namespace Executor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Static_Data;
    using Contracts;

    public class SoftUniStudent : IStudent
    {
        private string userName;
        private readonly Dictionary<string, ICourse> enrolledCourses;
        private readonly Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return userName; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.userName),
                        ExceptionMessages.NullOrEmptyValue);
                }
                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses => enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => marksByCourseName;

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                    this.userName, course.Name));
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new ArgumentException(ExceptionMessages.StudentNotEnrolledInCourse);
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }
            
            //if (this.marksByCourseName.ContainsKey(courseName))
            //{
            //    this.marksByCourseName[courseName] = CalculateMark(scores);
            //    return;
            //}

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam =
                scores.Sum()/(double) (SoftUniCourse.NumberOfTasksOnExam*SoftUniCourse.MaxScoreOnExam);
            double mark = percentageOfSolvedExam*4 + 2;
            return mark;
        }

        public int CompareTo(IStudent other) => 
            string.CompareOrdinal(this.UserName, other.UserName);

        public override string ToString() => this.UserName;
    }
}