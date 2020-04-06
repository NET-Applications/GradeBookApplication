using System;

namespace GradeBook
{
    public class NamedObject
    {
        #region private fields
        string name;
        #endregion private fields
        
        #region constructors
        /** Single argument Constructor to get name*/
        public NamedObject(string name)
        {
            Name = name;
        }
        #endregion constructors

        #region public properties
        /** Public property for name*/
        public string Name
        {
            get => name;
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"Grade book {nameof(name)} is required");
                }
            }
        }
        #endregion public properties

    }
}