using System;

namespace VehicleRental.Interfaces
{
    public interface IOverlappable<T>
    {
        bool Overlaps(T other);
    }
}