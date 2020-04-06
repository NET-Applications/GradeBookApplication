namespace GradeBook.Tests
{
    class ReadOnlyClass
    {
        #region public readonly fields
        public readonly string Category = "Science";
        #endregion public readonly fields

        #region constructors
        /** Single argument Constructor to set readonly property CATEGORY*/
        public ReadOnlyClass(string category)
        {
            Category = category;
        }
        #endregion constructors
    }
    class ConstantFieldClass
    {
        #region public constant fields
        public const string CATEGORY = "Science";
        #endregion public constant fields
    }
}