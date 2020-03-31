using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Account3
    {
        public Decimal Balance { get; private set; }
        private IAccountState State { get; set; }


        public Account3(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            State = State.Deposit(()=> { Balance += amount; });            
        }        

        public void Withdraw(decimal amount)
        {
            State = State.Withdraw(()=> { Balance -= amount; });            
        }

        public void HoldVerified()
        {
            State.HolderVerified();
        }

        public void Close()
        {
            State.Close();
        }

        public void Freeze()
        {
            State.Freeeze();
        }
    }
}
