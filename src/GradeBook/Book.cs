using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        #region constructors
        /** Single argument Constructor to get name of the book*/
        public Book(string name) : base(name)
        {
        }
        #endregion constructors
        
        #region public abstract delegates
        /** Event to monitor addition of a grade to book*/
        public abstract event GradeBookDelegate GradeAdded;
        #endregion public virtual delegates

        #region public abstract methods
        ///
        ///<Summary>
        ///Method to add a grade to grade book
        ///</Summary>
        ///<Parameter>
        ///Takes double value as parameter
        ///</Parameter>
        public abstract void AddGrade(double grade);
        ///
        ///<Summary>
        ///Method to add a letter grade to grade book
        ///</Summary>
        ///<Parameter>
        ///Takes char value as parameter
        ///</Parameter>
        public abstract void AddGrade(char grade);
        /** Method to get statistics and return as an Object*/
        public abstract Statistics GetStatistics();
        /** Method to show statistic details of a book*/
        public abstract void ShowStatistics();
        #endregion public abstract methods
    }
}