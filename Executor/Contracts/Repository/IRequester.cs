namespace Executor.Contracts
{
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetAllStudentsFromCourse(string courseName);

        void GetStudentScoresFromCourse(string courseName, string username);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
