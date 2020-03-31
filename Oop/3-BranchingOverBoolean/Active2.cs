using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Active2 : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active2(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Freeeze() => new Frozen2(OnUnfreeze);

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }

        public IAccountState Withdraw(Action substractFromBalance)
        {
            substractFromBalance();
            return this;
        }
    }
}
