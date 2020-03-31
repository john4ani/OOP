using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }
        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Close() => new Closed();
        
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeeze() => this;

        public IAccountState HolderVerified() => new Active2(OnUnfreeze);

        public IAccountState Withdraw(Action substractFromBalance) => this;
    }
}
