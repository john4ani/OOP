using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Account2
    {
        public Decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        
        private IFreezable Freezable { get; set; }

        public Account2(Action onUnfreeze)
        {
            Freezable = new Active(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            Freezable = Freezable.Deposit();
            Balance += amount;
        }
        

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            Freezable = Freezable.Withdraw();
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
            Freezable = Freezable.Freeeze();
        }
    }
}
