using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop._10_AvoidSwiches
{
    interface IWarranryMapFactory
    {
        IReadOnlyDictionary<DeviceStatus, Action<Action>> Create(
            Action<Action> claimMoineyBack,
            Action<Action> claimNotOperational,
            Action<Action> claimCircuitry
            );
    }
}
