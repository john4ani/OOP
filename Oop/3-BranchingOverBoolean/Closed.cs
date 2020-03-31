using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;        

        public IAccountState Freeeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action substractFromBalance) => this;
    }
}
