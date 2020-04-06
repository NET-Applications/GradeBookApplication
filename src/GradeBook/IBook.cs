using System.Collections.Generic;

namespace GradeBook
{
    public interface IBook
    {
        #region public properties
        /** Get book name*/
        string Name { get;}
        #endregion public properties

        #region public delegates
        /** Event to monitor addition of a grade to book*/
        event GradeBookDelegate GradeAdded;
        #endregion public delegates

        #region public methods
        /** Method to get statistics and return as an Object*/
        Statistics GetStatistics();
        /** Method to show statistic details of a book*/
        void ShowStatistics();
        /// Method to add a grade to a book */
        void AddGrade(double grade);
        /** Method to add a letter grade to a book*/
        void AddGrade(char grade);
        #endregion public methods
    }
}