using System;

namespace Ex03.GarageLogic
{
    public enum eFuelTypes
    {
        Octan95,
        Octan96,
        Octan98,
        Soler,
    }

    public class FuelEngine : Engine
    {
        private eFuelTypes m_FuelType;

        public eFuelTypes FuelType
        {
            get
            {
                return this.m_FuelType;
            }

            set
            {
                this.m_FuelType = value;
            }
        }

        public void FuelingVehicle(float i_AmountOfFuelToAdd, eFuelTypes i_FuelType)
        {
            bool isDifferentFuelType = this.FuelType != i_FuelType;
            bool isFuelingToMax = i_AmountOfFuelToAdd == MaxCapacityOfEnergy;

            if(isDifferentFuelType)
            {
                ArgumentException argumentException = new ArgumentException();
                throw argumentException;
            }
            else if(isFuelingToMax)
            {
                this.CurrentAmountOfEnergy = MaxCapacityOfEnergy;
            }
            else if(i_AmountOfFuelToAdd + this.CurrentAmountOfEnergy <= MaxCapacityOfEnergy)
            {
                this.CurrentAmountOfEnergy = CurrentAmountOfEnergy + i_AmountOfFuelToAdd;
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException =
                    new ValueOutOfRangeException(0, this.MaxCapacityOfEnergy);
                throw valueOutOfRangeException;
            }
        }

    }
}