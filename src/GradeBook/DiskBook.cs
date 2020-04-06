using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public class DiskBook : Book
    {
        #region constructors
        /** Single argument Constructor to get name*/
        public DiskBook(string name) : base(name)
        {
        }
        #endregion constructors

        #region public overriden delegates
        ///
        ///<Summary>
        /// Event to notify when a grade is added to the grade book.
        ///</Summary>
        public override event GradeBookDelegate GradeAdded;
        #endregion public overriden delegates

        #region public overriden methods
        /// Method to add a grade to grade book */
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (StreamWriter writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        /** Method to add a letter grade to grade book*/
        public override void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }

        }
        /** Method to show statistic details of a grade book*/
        public override Statistics GetStatistics()
        {
            string path = $"{Name}.txt";
            int size = GetSize(path);
            /** Computes statistics if grades exists*/
            if (size > 0)
            {
                return new Statistics
                {
                    Total = ComputeTotalGrades(),
                    Average = ComputeAverageGrade(),
                    HighestGrade = MaxGrade(),
                    LowestGrade = MinGrade(),
                    Size = size,
                    Letter = ComputeLetterGrade()
                };
            }
            /** If grades are not added returns default statistics*/
            else
            {
                return new Statistics() { Letter = ComputeLetterGrade()};
            }

        }
        /** Method to show statistic details of a grade book**/
        public override void ShowStatistics()
        {
            var statistic = GetStatistics();
            // Display the sum, average, highest grade and lowest grade among the grades in the grade book.    
            Console.WriteLine($"{Name} grade book details:\nSum:{statistic.Total:N2} Average: {statistic.Average:N2} Letter grade: {statistic.Letter} Highest grade: {statistic.HighestGrade:N2} Lowest grade: {statistic.LowestGrade:N2}");
        }
        #endregion public overriden methods

        #region publlic static methods
        ///<Summary>
        ///Deletes the file if it exists.
        ///</Summary>
        ///<Parameter>
        ///The string path at which, if the file exists, gets deleted.
        ///</Parameter>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        #endregion public static methods

        #region private methods
        /** Method to Compute total grades.
            Returns a double value.*/
        private double ComputeTotalGrades()
        {
            var total = 0.0;
            double grade;
            var grades = GetGrades($"{Name}.txt");
            for (var index = 0; index < grades.Length; index++)
            {
                if (double.TryParse(grades[index], out grade))
                {
                    total += grade;
                }
                else
                {
                    throw new FormatException($"Please enter a {nameof(grade)} of type double");
                }
            }
            return total;
        }
        /** Method to compute the average of grades.
            Returns a double value */
        private double ComputeAverageGrade()
        {
            int size = GetSize($"{Name}.txt");
            if (size > 0)
            {
                return ComputeTotalGrades() / size;
            }
            else
            {
                return 0;
            }
        }
        /** Method to compute a letter grade for the grade book average
            Returns a char value*/
        private char ComputeLetterGrade()
        {
            switch (ComputeAverageGrade())
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }
        /** Method to provide the highest grade */
        private double MaxGrade()
        {
            var grades = File.ReadAllLines($"{Name}.txt");
            double _grade;
            // conditional ternary operator to check for empty grades.
            var maxValue = grades.Length > 0 ? double.MinValue : 0;
            foreach (var grade in grades)
            {
                if (double.TryParse(grade, out _grade))
                {
                    maxValue = Math.Max(_grade, maxValue);
                }
                else
                {
                    throw new FormatException($"Please enter a {nameof(grade)} of type double");
                }
            }
            return maxValue;
        }
        /** Method to provide the lowest grade*/
        private double MinGrade()
        {
            var grades = GetGrades($"{Name}.txt");
            double grade;
            // conditional ternary operator to check for empty grades.
            var minValue = grades.Length > 0 ? double.MaxValue : 0;
            var index = 0;
            while (index < grades.Length)
            {
                if (double.TryParse(grades[index], out grade))
                {
                    minValue = Math.Min(grade, minValue);
                }
                else
                {
                    throw new FormatException($"Please enter a {nameof(grade)} of type double");
                }
                index += 1;
            }
            return minValue;
        }
        ///<Summary>
        ///Method to fetch the grades from the file.
        ///</Summary>
        ///<Parameter>
        ///Takes the path of the file as a string parameter.
        ///</Parameter>
        ///<Returns>
        ///Returns the text in the file as an array of string.
        ///</Returns>
        private string[] GetGrades(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path);
            }
            else
            {
                return new string[] { };
            }
        }
        ///<Summary>
        ///Gets the no. of grades stored in the file.
        ///</Summary>
        ///<Parameter>
        ///Takes the path of the file as a string parameter.
        ///</Parameter>
        ///<Returns>
        ///Returns the no.null of grades in the file as an integer.
        ///</Returns>
        private int GetSize(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path).Length;
            }
            else
            {
                return 0;
            }
        }
        #endregion private methods
    }
}