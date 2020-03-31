using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Frozen2 : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen2(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        
        public IAccountState Freeeze() => this;
        
        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();
            return new Active2(OnUnfreeze);
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
            OnUnfreeze();
            substractFromBalance();
            return new Active2(OnUnfreeze);
        }
    }
}
