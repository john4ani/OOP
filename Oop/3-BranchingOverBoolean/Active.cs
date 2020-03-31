using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.BranchingOverBoolean
{
    class Active : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Freeeze() => new Frozen(OnUnfreeze);

        public IFreezable Withdraw() => this;
    }
}
