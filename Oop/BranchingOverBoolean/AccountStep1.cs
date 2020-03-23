using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Account1
    {
        public Decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private Action OnUnfreeze { get;}

        public Account1(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            ManageUnfreeze = StayUnfrozen;
            Balance += amount;
        }

        private Action ManageUnfreeze { get; set; }
        //{
        //    if (IsFrozen)
        //    {
        //        Unfreeze();
        //    }
        //    else
        //    {
        //        StayUnfrozen();
        //    }
        //}

        private void StayUnfrozen()
        {
            
        }

        private void Unfreeze()
        {
            OnUnfreeze();
            ManageUnfreeze = StayUnfrozen;
        }

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            ManageUnfreeze();
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
            ManageUnfreeze = Unfreeze;
        }
    }
}
