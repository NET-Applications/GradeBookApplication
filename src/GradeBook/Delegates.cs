using System;

namespace GradeBook
{
    #region public delegates
    ///
    ///<Summary>
    ///Monitors when grades are added to the grade book.
    ///</Summary>
    public delegate void GradeBookDelegate(object sender, EventArgs args);
    #endregion public delegates
}