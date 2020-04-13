using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public interface ILoggable
    {
        #region public methods
        string Log();
        #endregion public methods
    }
}
