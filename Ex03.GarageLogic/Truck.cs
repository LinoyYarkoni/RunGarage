namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_IsCoolingCargo;
        private readonly float r_CargoVolume;

        public Truck(
            bool i_IsCoolingCargo,
            float i_CargoVolume,
            string i_ModelName,
            string i_LicenseNumber,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            this.r_IsCoolingCargo = i_IsCoolingCargo;
            this.r_CargoVolume = i_CargoVolume;
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            VehicleStatus = eVehicleStatus.InFix;
            float maxFuelTankSize = 130f;
            EngineType = new FuelEngine();
            EngineType.MaxCapacityOfEnergy = maxFuelTankSize;
            EngineType.CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            ((FuelEngine)EngineType).FuelType = eFuelTypes.Soler;

            int numberOfWheels = 16;
            for (int i = 0; i < numberOfWheels; i++)
            {
                Wheel item = new Wheel(i_WheelManufacturerName, 25, i_CurrentAirPressure);
                WheelsCollection.Add(item);
            }
        }

        public bool IsCoolingCargo
        {
            get
            {
                return this.r_IsCoolingCargo;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.r_CargoVolume;
            }
        }
    }
}
