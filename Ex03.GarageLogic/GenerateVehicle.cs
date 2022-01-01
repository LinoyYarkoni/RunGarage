namespace Ex03.GarageLogic
{
    public class GenerateVehicle
    {
        public static Vehicle GenerateCar(
            eCarColor i_CarColor,
            eNumberOfDoors i_NumberOfDoors,
            string i_ModelName,
            string i_LicenseNumber,
            eEngineType i_EngineType,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            Vehicle newCar = new Car(
                i_CarColor,
                i_NumberOfDoors,
                i_ModelName,
                i_LicenseNumber,
                i_EngineType,
                i_CurrentAmountOfEnergy,
                i_WheelManufacturerName,
                i_CurrentAirPressure);
            return newCar;
        }

        public static Vehicle GenerateTruck(
            bool i_IsCoolingCargo,
            float i_CargoVolume,
            string i_ModelName,
            string i_LicenseNumber,
            eEngineType i_EngineType,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            Vehicle newTruck = new Truck(
                i_IsCoolingCargo,
                i_CargoVolume,
                i_ModelName,
                i_LicenseNumber,
                i_CurrentAmountOfEnergy,
                i_WheelManufacturerName,
                i_CurrentAirPressure);

            return newTruck;
        }

        public static Vehicle GenerateMotorcycle(
            eLicenseType i_LicenseType,
            int i_EngineVolume,
            string i_ModelName,
            string i_LicenseNumber,
            eEngineType i_EngineType,
            float i_CurrentAmountOfEnergy,
            string i_WheelManufacturerName,
            float i_CurrentAirPressure)
        {
            Vehicle newMotorcycle = new Motorcycle(
                i_LicenseType,
                i_EngineVolume,
                i_ModelName,
                i_LicenseNumber,
                i_EngineType,
                i_CurrentAmountOfEnergy,
                i_WheelManufacturerName,
                i_CurrentAirPressure);

            return newMotorcycle;
        }
    }
}