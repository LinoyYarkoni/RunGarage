using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            runGarage();
        }

        private static void runGarage()
        {
            Garage myGarage = new Garage();
            Vehicle newVehicle;
            int userChoice;
            do
            {
                userChoice = UI.DisplayMenu();
                int askedParam;
                string licenseNumberToAction;
                switch (userChoice)
                {
                    case 1:
                        int userVehicleChoice = UI.GetTypeOfVehicleToCreate();
                        newVehicle = creatingVehicle(userVehicleChoice);
                        UI.GetOwnerDetails(out string ownerName, out string phoneNumber);
                        myGarage.AddVehicleToGarage(newVehicle, ownerName, phoneNumber);
                        break;
                    case 2:
                        askedParam = UI.GetParameter(
                            string.Format(
@"Please enter the status of the vehicle to filter: 
For In Fix vehicles, press 1
For Fixed vehicles, press 2
For Paid vehicles, press 3
For all statuses, press 4"),
1,
4);
                        UI.DisplayList(myGarage.CreateLicenseNumbersList(askedParam));
                        break;
                    case 3:
                        licenseNumberToAction = UI.GetLicenseNumber();
                        askedParam = UI.GetParameter(
                            string.Format(
@"Please enter the status of the vehicle to change: 
Change to In Fix vehicles, press 1
Change to Fixed vehicles, press 2
Change to Paid vehicles, press 3"), 
1,
3);
                        eVehicleStatus statusToChange = getTypeOfVehicleStatus(askedParam);
                        try
                        {
                            myGarage.ChangeVehicleStatus(licenseNumberToAction, statusToChange);
                        }
                        catch(ArgumentNullException)
                        {
                            UI.DisplayErrorMessage("ERROR: The license number you entered is not exists");
                        }

                        break;
                    case 4:
                        licenseNumberToAction = UI.GetLicenseNumber();
                        try
                        {
                            myGarage.AirInflationWheelToMaximum(licenseNumberToAction);
                        }
                        catch(ArgumentNullException)
                        {
                            UI.DisplayErrorMessage("ERROR: The license number you entered is not exists");
                        }

                        break;
                    case 5:
                        licenseNumberToAction = UI.GetLicenseNumber();
                        float amountOfFuelToAdd = UI.GetAmountOfEnergy();
                        askedParam = UI.GetParameter(
                            string.Format(
@"Please enter the status of the vehicle to filter: 
For Octan95, press 1
For Octan96, press 2
For Octan98, press 3
For Soler, press 4"),
1,
4);
                        eFuelTypes fuelType = getTypeOfFuelType(askedParam);
                        try
                        {
                            myGarage.RefuelVehicleToMaximum(licenseNumberToAction, amountOfFuelToAdd, fuelType);
                        }
                        catch (ArgumentException)
                        {
                            UI.DisplayErrorMessage(string.Format(
@"ERROR: You can not put different fuel type.
or
You can not refuel electric vehicle."));
                        }
                        catch (ValueOutOfRangeException error)
                        {
                            UI.DisplayErrorMessage(error.Message);
                        }

                        break;
                    case 6:
                        licenseNumberToAction = UI.GetLicenseNumber();
                        float minutesToCharge = UI.GetAmountOfEnergy();
                        try
                        {
                            myGarage.RechargingVehicle(licenseNumberToAction, minutesToCharge);
                        }
                        catch (ArgumentException)
                        {
                            UI.DisplayErrorMessage("ERROR: You can not recharge a fuel type vehicle");
                        }
                        catch (ValueOutOfRangeException error)
                        {
                            UI.DisplayErrorMessage(error.Message);
                        }

                        break;
                    case 7:
                        licenseNumberToAction = UI.GetLicenseNumber();
                        try 
                        {
                            UI.DisplayList(myGarage.CreateListOfVehiclesDetails(licenseNumberToAction));
                        }
                        catch (ArgumentNullException)
                        {
                            UI.DisplayErrorMessage("ERROR: The license number you entered is not exists");
                        }

                        break;
                }
            }
            while(userChoice != 0);
        }

        private static Vehicle creatingVehicle(int i_UserVehicleChoice)
        {
            Vehicle newVehicle;

            UI.GetGeneralVehicleDetails(
               out string licenseNumber,
               out string modelName,
               out string wheelManufacturerName);

            UI.GetSpecificDetailsForEngineType(
                i_UserVehicleChoice,
                out float currentAirPressure,
                out float currentAmountOfEnergy,
                out eEngineType engineType);

            if(i_UserVehicleChoice == 1)
            {
                UI.GetCarDetails(out eCarColor carColor, out eNumberOfDoors numberOfDoors);
                newVehicle = GenerateVehicle.GenerateCar(
                    carColor,
                    numberOfDoors,
                    modelName,
                    licenseNumber,
                    engineType,
                    currentAmountOfEnergy,
                    wheelManufacturerName,
                    currentAirPressure);
            }
            else if(i_UserVehicleChoice == 2)
            {
                UI.GetMotorcycleDetails(out eLicenseType licenseType, out int engineVolume);
                newVehicle = GenerateVehicle.GenerateMotorcycle(
                    licenseType,
                    engineVolume,
                    modelName,
                    licenseNumber,
                    engineType,
                    currentAmountOfEnergy,
                    wheelManufacturerName,
                    currentAirPressure);
            }
            else
            {
                UI.GetTruckDetails(out bool isCooling, out int cargoVolume);
                newVehicle = GenerateVehicle.GenerateTruck(
                    isCooling,
                    cargoVolume,
                    modelName,
                    licenseNumber,
                    engineType,
                    currentAmountOfEnergy,
                    wheelManufacturerName,
                    currentAirPressure);
            }

            return newVehicle;
        }

        private static eVehicleStatus getTypeOfVehicleStatus(int i_UserChoice)
        {
            eVehicleStatus vehicleStatus;

            if(i_UserChoice == 1)
            {
                vehicleStatus = eVehicleStatus.InFix;
            }
            else if(i_UserChoice == 2)
            {
                vehicleStatus = eVehicleStatus.Fixed;
            }
            else
            {
                vehicleStatus = eVehicleStatus.Paid;
            }

            return vehicleStatus;
        }

        private static eFuelTypes getTypeOfFuelType(int i_UserChoice)
        {
            eFuelTypes vehicleFuel;

            if(i_UserChoice == 1)
            {
                vehicleFuel = eFuelTypes.Octan95;
            }
            else if(i_UserChoice == 2)
            {
                vehicleFuel = eFuelTypes.Octan96;
            }
            else if(i_UserChoice == 3)
            {
                vehicleFuel = eFuelTypes.Octan98;
            }
            else
            {
                vehicleFuel = eFuelTypes.Soler;
            }

            return vehicleFuel;
        }
    }
}