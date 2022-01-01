namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public void ChargingVehicle(float i_HoursToCharge)
        {
            if(CurrentAmountOfEnergy + i_HoursToCharge <= MaxCapacityOfEnergy)
            {
                this.CurrentAmountOfEnergy = this.CurrentAmountOfEnergy + i_HoursToCharge;
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