using System;

namespace Oop._11_ChainOfRules.Rules
{
    abstract class ChainedRule : IWarrantyRules
    {
        private IWarrantyRules Next { get; }

        protected ChainedRule(IWarrantyRules next)
        {
            Next = next;
        }

        protected void Forward(Action onValidClaim) => Next.Claim(onValidClaim);

        public void CircuitryOperational()
        {
            HandleCircuitryOperational();
            Next.CircuitryOperational();
        }        

        public void CircuitryFailed()
        {
            HandleCircuitryFailed();
            Next.CircuitryFailed();
        }
        public void VisibilyDamaged()
        {
            HandleVisiblyDamaged();
            Next.VisibilyDamaged();
        }

        public void NotOperational()
        {
            HandleNotOperational();
            Next.CircuitryOperational();
        }
        //{
        //    //IsOperational = false;
        //    //ClaimStrategy = (onValidcClaim) => ClaimAction(onValidcClaim);
        //    Claim = ClaimAction;
        //}

        public void Operational()
        {
            HandleOperational();
            Next.CircuitryOperational();
        }
        //{
        //    //IsOperational = true;
        //    //ClaimStrategy = (onValidcClaim) => Next.Claim(onValidcClaim);
        //    Claim = Forward;
        //}

        protected virtual void HandleCircuitryOperational() { }
        protected virtual void HandleCircuitryFailed() { }
        protected virtual void HandleVisiblyDamaged() { }
        protected virtual void HandleNotOperational() { }
        protected virtual void HandleOperational() { }

        public Action<Action> Claim { get; protected set; }
    }
}
