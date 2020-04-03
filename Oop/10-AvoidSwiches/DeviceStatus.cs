using System;

namespace Oop
{
    //Step 1
    //[Flags]
    //enum DeviceStatus
    //{
    //    AllFine = 0,
    //    NotOperational = 1,
    //    VisiblyDamaged = 2,
    //    CircuitryFailed = 4
    //}

    //Step 2
    //class DeviceStatus
    //{
    //    private enum StatusRepresentation
    //    {
    //        AllFine = 0,
    //        NotOperational = 1,
    //        VisiblyDamaged = 2,
    //        CircuitryFailed = 4
    //    }

    //    private StatusRepresentation Representation { get;  }

    //    private DeviceStatus(StatusRepresentation representation)
    //    {
    //        Representation = representation;
    //    }

    //    public static DeviceStatus AllFine() =>
    //        new DeviceStatus(StatusRepresentation.AllFine);

    //    public DeviceStatus WithVisibleDamage() =>
    //        new DeviceStatus(Representation | StatusRepresentation.VisiblyDamaged);

    //    public DeviceStatus NotOperational() =>
    //        new DeviceStatus(Representation | StatusRepresentation.NotOperational);

    //    public DeviceStatus Repaired() =>
    //        new DeviceStatus(Representation | ~StatusRepresentation.NotOperational);

    //    public DeviceStatus CircuitryFailed() =>
    //        new DeviceStatus(Representation | StatusRepresentation.CircuitryFailed);

    //    public DeviceStatus CircuitryReplaced() =>
    //        new DeviceStatus(Representation & ~StatusRepresentation.CircuitryFailed);

    //}

    //Step 3
    sealed class DeviceStatus : IEquatable<DeviceStatus>
    {
        private enum StatusRepresentation
        {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitryFailed = 4
        }

        private StatusRepresentation Representation { get; }

        private DeviceStatus(StatusRepresentation representation)
        {
            Representation = representation;
        }

        public static DeviceStatus AllFine() =>
            new DeviceStatus(StatusRepresentation.AllFine);

        public DeviceStatus WithVisibleDamage() =>
            new DeviceStatus(Representation | StatusRepresentation.VisiblyDamaged);

        public DeviceStatus NotOperational() =>
            new DeviceStatus(Representation | StatusRepresentation.NotOperational);

        public DeviceStatus Repaired() =>
            new DeviceStatus(Representation | ~StatusRepresentation.NotOperational);

        public DeviceStatus CircuitryFailed() =>
            new DeviceStatus(Representation | StatusRepresentation.CircuitryFailed);

        public DeviceStatus CircuitryReplaced() =>
            new DeviceStatus(Representation & ~StatusRepresentation.CircuitryFailed);

        public override int GetHashCode() => (int)Representation;

        public override bool Equals(object obj) => Equals(obj as DeviceStatus);

        public bool Equals(DeviceStatus other) =>
            other != null && Representation == other.Representation;

        public static bool operator ==(DeviceStatus a, DeviceStatus b) =>
            (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
            (!ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(DeviceStatus a, DeviceStatus b) => !(a == b);
    }
}