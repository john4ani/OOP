using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action substractFromBalance);
        IAccountState Freeeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
