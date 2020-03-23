using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeeze();
    }
}
