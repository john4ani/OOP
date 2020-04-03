using System;

namespace Oop._11_ChainOfRules
{
    public interface IWarrantyRules
    {
        void CircuitryOperational();
        void CircuitryFailed();
        void VisibilyDamaged();
        void NotOperational();
        void Operational();
        //void Claim(Action onValidClaim);
        Action<Action> Claim { get; }
    }
}