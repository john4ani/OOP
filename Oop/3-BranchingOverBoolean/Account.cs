using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Account
    {
        public Decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get;}

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            if(IsFrozen)
            {
                OnUnfreeze();
                IsFrozen = false;
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            if (IsFrozen)
            {
                OnUnfreeze();
                IsFrozen = false;
            }
            //Withdraw money
            Balance -= amount;
        }

        public void HoldVerified()
        {
            IsVerified = true;
        }

        public void Close()
        {
            IsClosed = true;
        }

        public void Freeze()
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            IsFrozen = true;
        }
    }
}
