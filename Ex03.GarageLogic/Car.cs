namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        Red,
        White,
        Black,
        Blue,
    }

    public enum eNumberOfDoors
    {
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5,
    }

    public class Car : Vehicle
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;

        public Car(
            eCarColor i_CarColor,
            eNumberOfDoors i_NumberOfDoors,
            string i_ModelName,
            string i_LicenseNumber,
            eEngineType i_EngineType,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            this.r_CarColor = i_CarColor;
            this.r_NumberOfDoors = i_NumberOfDoors;
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            VehicleStatus = eVehicleStatus.InFix;

            if(i_EngineType == eEngineType.Electric)
            {
                float maxBatteryTime = 2.6f;
                EngineType = new ElectricEngine();
                EngineType.MaxCapacityOfEnergy = maxBatteryTime;
                EngineType.CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            }
            else if(i_EngineType == eEngineType.Fuel)
            {
                float maxFuelTankSize = 48f;
                EngineType = new FuelEngine();
                EngineType.MaxCapacityOfEnergy = maxFuelTankSize;
                EngineType.CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
                ((FuelEngine)EngineType).FuelType = eFuelTypes.Octan95;
            }

            int numberOfWheels = 4;
            for(int i = 0; i < numberOfWheels; i++)
            {
                Wheel item = new Wheel(i_WheelManufacturerName, 29, i_CurrentAirPressure);
                WheelsCollection.Add(item);
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return this.r_CarColor;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return this.r_NumberOfDoors;
            }
        }
    }
}