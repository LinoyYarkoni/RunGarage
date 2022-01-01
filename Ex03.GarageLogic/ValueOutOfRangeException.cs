using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(
                string.Format(
                    @"Value is out of range.
The value you try to assign must be in range {0} to {1}",
                    i_MinValue,
                    i_MaxValue))
        {
        }
    }
}