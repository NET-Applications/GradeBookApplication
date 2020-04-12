using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public abstract class EntityBase
    {
        #region public enums
        public enum EntityStateOption
        {
            Active,
            Deleted
        }
        #endregion public enums

        #region public properties
        //Property to get or set if the entity has changed.
        public bool HasChanges { get; set; }
        //Property to get or set the indicator denoting a new entity.
        //It can be set only within the class.
        public bool IsNew { get; private set; }
        //Property to get the validity of the entity.
        public bool IsValid => Validate();
        //Property to get or set the state of the entity.
        public EntityStateOption EntityState { get; set; }
        #endregion public properties

        #region public abstract methods
        public abstract bool Validate();
        #endregion public abstract methods
    }
}