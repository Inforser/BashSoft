﻿namespace Executor.Static_Data
{
    public static class ExceptionMessages
    {
        public const string UnauthorizedAccessExceptionMessage =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string InvalidPath =
            "The folder/file you are trying to access at the current address, does not exist.";

        public const string DataNotInitializedExceptionMessage =
            "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingStudentInDataBase =
            "The user name for the student you are trying to get does not exist!";

        public const string InexistingCourseInDataBase =
            "The course you are trying to get does not exist in the data base!";

        public const string InvalidComparisonQuery =
            "The comparison query you want, does not exist in the context of the current program!";

        public const string InvalidTakeQuantityParameter =
            "The quantity you are trying to take is an invalid parameter!";

        public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";

        public const string InvalidStudentsFilter =
            "The given filter is not one of the following: excellent/average/poor";

        public const string DataAlreadyInitializedException = "Data is already initialised!";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files or folders.";

        public const string InvalidDestination =
            "You are unable to go higher in the hierarchy of the current partition.";

        public const string StudentAlreadyEnrolledInGivenCourse =
            "The student {0} has already been enrolled in the course {1}.";

        public const string StudentNotEnrolledInCourse =
            "Student must be enrolled in a course before you set his mark.";

        public const string InvalidNumberOfScores =
            "The number of scores for the given course is greater than the possible.";

        public static string InvalidScore = "Entered score is not in predefined boundaries.";
        public static string NullOrEmptyValue = "The value of the variable cannot be null or empty!";
    }
}