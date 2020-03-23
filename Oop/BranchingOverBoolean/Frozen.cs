using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IFreezable Deposit()
        {
            OnUnfreeze();
            return new Active();
        }

        public IFreezable Freeeze() => this;

        public IFreezable Withdraw()
        {
            OnUnfreeze();
            return new Active();
        }
    }
}
