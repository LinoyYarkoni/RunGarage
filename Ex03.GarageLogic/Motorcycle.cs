namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A,
        A2,
        AA,
        B
    }

    public class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        public Motorcycle(
            eLicenseType i_LicenseType,
            int i_EngineVolume,
            string i_ModelName,
            string i_LicenseNumber,
            eEngineType i_EngineType,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            this.r_LicenseType = i_LicenseType;
            this.r_EngineVolume = i_EngineVolume;
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            VehicleStatus = eVehicleStatus.InFix;

            if(i_EngineType == eEngineType.Electric)
            {
                float maxBatteryTime = 2.3f;
                EngineType = new ElectricEngine();
                EngineType.MaxCapacityOfEnergy = maxBatteryTime;
                EngineType.CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            }
            else if(i_EngineType == eEngineType.Fuel)
            {
                float maxFuelTankSize = 5.8f;
                EngineType = new FuelEngine();
                EngineType.MaxCapacityOfEnergy = maxFuelTankSize;
                EngineType.CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
                ((FuelEngine)EngineType).FuelType = eFuelTypes.Octan98;
            }

            int numberOfWheels = 2;
            for(int i = 0; i < numberOfWheels; i++)
            {
                Wheel item = new Wheel(i_WheelManufacturerName, 30, i_CurrentAirPressure);
                WheelsCollection.Add(item);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return this.r_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return this.r_EngineVolume;
            }
        }
    }
}
