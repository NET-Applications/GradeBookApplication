using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class InMemoryBook: Book
    {
        #region private fields
        List<double> grades;
        #endregion private fields

        #region public properties
        /** Public property for grades*/
        public List<double> Grades
        {
            get => grades;
            private set
            {
                if (!value.Exists(grade => grade > 100 || grade < 0))
                {
                    grades = new List<double>();
                    value.ForEach((grade) => AddGrade(grade));
                }
                else
                {
                    grades = new List<double>();
                }
            }
        }
        #endregion public properties
        
        #region constructors
        /** Single argument Constructor to get name*/
        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
        }
        /** Double argument Constructor to get the grades and name*/
        public InMemoryBook(List<double> grades, string name) : base(name)
        {
            Grades = grades;
        }
        #endregion constructors

        #region public overriden methods
        /// Method to add a grade to grade book */
        public override void AddGrade(double grade)
        {
            if( grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
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
            switch(letter)
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
        public override void ShowStatistics()
        {
            var statistic = GetStatistics();
            // Display the sum, average, highest grade and lowest grade among the grades in the grade book.    
            Console.WriteLine($"{Name} grade book details:\nSum:{statistic.Total:N2} Average: {statistic.Average:N2} Letter grade: {statistic.Letter} Highest grade: {statistic.HighestGrade:N2} Lowest grade: {statistic.LowestGrade:N2}");

        }
        /** Method to get statistics and return as an Object*/
        public override Statistics GetStatistics()
        {
            return new Statistics
            {
                Total = ComputeTotalGrades(),
                Average = ComputeAverageGrade(),
                HighestGrade = MaxGrade(),
                LowestGrade = MinGrade(),
                Size = Grades.Count,
                Letter = ComputeLetterGrade()
            };
        }
        #endregion public overriden methods

        #region public overriden delegates
        ///
        ///<Summary>
        /// Event to notify when a grade is added to the grade book.
        ///</Summary>
        public override event GradeBookDelegate GradeAdded;
        #endregion public overriden delegates

        #region private methods
        /** Method to Compute total grades.
            Returns a double value.*/
        private double ComputeTotalGrades()
        {
            var total = 0.0;
            for (var index = 0; index < Grades.Count; index++)
            {
                total += Grades[index];
            }
            return total;
        }
        /** Method to compute the average of grades.
            Returns a double value */
        private double ComputeAverageGrade()
        {
            if(Grades.Count > 0)
            {
                return ComputeTotalGrades() / Grades.Count;
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
            switch(ComputeAverageGrade())
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
            // conditional ternary operator to check for empty grades.
            var maxValue = Grades.Count > 0 ? double.MinValue : 0;
            foreach (var grade in Grades)
            {
                maxValue = Math.Max(grade, maxValue);
            }
            return maxValue;
        }
        /** Method to provide the lowest grade*/
        private double MinGrade()
        {
            // conditional ternary operator to check for empty grades.
            var minValue = Grades.Count > 0 ? double.MaxValue : 0;
            var index = 0;
            while(index < Grades.Count)
            {
                minValue = Math.Min(Grades[index], minValue);
                index += 1;
            }
            return minValue;
        }  
        #endregion private methods
    }
}