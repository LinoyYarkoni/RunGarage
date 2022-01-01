using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Owner> r_VehiclesInGarage = new Dictionary<string, Owner>();

        public void AddVehicleToGarage(Vehicle i_VehicleToAdd, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            if(r_VehiclesInGarage.ContainsKey(i_VehicleToAdd.LicenseNumber))
            {
                i_VehicleToAdd.VehicleStatus = eVehicleStatus.InFix;
            }
            else
            {
                Owner item = new Owner(i_OwnerName, i_OwnerPhoneNumber, i_VehicleToAdd);
                r_VehiclesInGarage.Add(i_VehicleToAdd.LicenseNumber, item);
            }
        }

        public StringBuilder CreateLicenseNumbersList(int i_AskedStatus)
        {
            StringBuilder listOfLicenseNumbers = new StringBuilder();
            bool isEmptyList = true;

            switch(i_AskedStatus)
            {
                case 1:
                    listOfLicenseNumbers.AppendLine("List of all vehicles in Fix status:");
                    foreach(string licenseNumber in r_VehiclesInGarage.Keys)
                    {
                        if(r_VehiclesInGarage[licenseNumber].VehicleOwner.VehicleStatus == eVehicleStatus.InFix)
                        {
                            listOfLicenseNumbers.AppendFormat("{0}{1}", licenseNumber, Environment.NewLine);
                            isEmptyList = false;
                        }
                    }

                    break;
                case 2:
                    listOfLicenseNumbers.AppendLine("List of all vehicles in Fixed status:");
                    foreach(string licenseNumber in r_VehiclesInGarage.Keys)
                    {
                        if(r_VehiclesInGarage[licenseNumber].VehicleOwner.VehicleStatus == eVehicleStatus.Fixed)
                        {
                            listOfLicenseNumbers.AppendFormat("{0}{1}", licenseNumber, Environment.NewLine);
                            isEmptyList = false;
                        }
                    }

                    break;
                case 3:
                    listOfLicenseNumbers.AppendLine("List of all vehicles in Paid status:");
                    foreach(string licenseNumber in r_VehiclesInGarage.Keys)
                    {
                        if(r_VehiclesInGarage[licenseNumber].VehicleOwner.VehicleStatus == eVehicleStatus.Paid)
                        {
                            listOfLicenseNumbers.AppendFormat("{0}{1}", licenseNumber, Environment.NewLine);
                            isEmptyList = false;
                        }
                    }

                    break;
                case 4:
                    listOfLicenseNumbers.AppendLine("List of all vehicles:");
                    foreach (string licenseNumber in r_VehiclesInGarage.Keys)
                    {
                        listOfLicenseNumbers.AppendFormat("{0}{1}", licenseNumber, Environment.NewLine);
                        isEmptyList = false;
                    }

                    break;
            }

            if(isEmptyList)
            {
                listOfLicenseNumbers.AppendLine("Is Empty !");
            }

            return listOfLicenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            if(r_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.VehicleStatus = i_NewVehicleStatus;
            }
            else
            {
                ArgumentNullException argumentNullException = new ArgumentNullException();
                throw argumentNullException;
            }
        }

        public void AirInflationWheelToMaximum(string i_LicenseNumber)
        {
            if(r_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                List<Wheel> wheelToInflation = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.WheelsCollection;

                foreach(Wheel wheelToInflate in wheelToInflation)
                {
                    wheelToInflate.WheelInflation(wheelToInflate.MaxAirPressure);
                }
            }
            else
            {
                ArgumentNullException argumentNullException = new ArgumentNullException();
                throw argumentNullException;
            }
        }

        public void RefuelVehicleToMaximum(string i_LicenseNumber, float i_AmountOfFuelToAdd, eFuelTypes i_FuelType)
        {
            if(r_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                if(r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType is FuelEngine)
                {
                    ((FuelEngine)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType).FuelingVehicle(
                            i_AmountOfFuelToAdd,
                            i_FuelType);
                }
                else
                {
                    ArgumentException argumentException = new ArgumentException();
                    throw argumentException;
                }
            }
            else
            {
                ArgumentNullException argumentNullException = new ArgumentNullException();
                throw argumentNullException;
            }
        }

        public void RechargingVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            float hoursToCharge = i_MinutesToCharge / 60;
            if(r_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                if(r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType is ElectricEngine)
                {
                    ((ElectricEngine)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType).ChargingVehicle(
                        hoursToCharge);
                }
                else
                {
                    ArgumentException argumentException = new ArgumentException();
                    throw argumentException;
                }
            }
            else
            {
                ArgumentNullException argumentNullException = new ArgumentNullException();
                throw argumentNullException;
            }
        }

        public StringBuilder CreateListOfVehiclesDetails(string i_LicenseNumber)
        {
            StringBuilder listOfVehiclesDetails = new StringBuilder();

            if(r_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                listOfVehiclesDetails.Append(createVehicleGeneralList(i_LicenseNumber));
                if(r_VehiclesInGarage[i_LicenseNumber].VehicleOwner is Car)
                {
                    eCarColor carColor = ((Car)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).CarColor;
                    eNumberOfDoors numberOfDoors = ((Car)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).NumberOfDoors;
                    listOfVehiclesDetails.AppendFormat("The car color is: {0}.{1}", carColor.ToString(), Environment.NewLine);
                    listOfVehiclesDetails.AppendFormat(
                        "The number of doors in the car is: {0}.{1}",
                        numberOfDoors.GetHashCode(),
                        Environment.NewLine);
                }
                else if(r_VehiclesInGarage[i_LicenseNumber].VehicleOwner is Motorcycle)
                {
                    eLicenseType licenseType = ((Motorcycle)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).LicenseType;
                    int engineVolume = ((Motorcycle)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).EngineVolume;
                    listOfVehiclesDetails.AppendFormat(
                        "The motorcycle's license type is: {0}.{1}",
                        licenseType.ToString(),
                        Environment.NewLine);
                    listOfVehiclesDetails.AppendFormat(
                        "Engine volume is: {0}.{1}",
                        engineVolume,
                        Environment.NewLine);
                }
                else
                {
                    bool isCoolingCargo = ((Truck)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).IsCoolingCargo;
                    string isOrNot = isCoolingCargo == true ? string.Empty : "not ";
                    float cargoVolume = ((Truck)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner).CargoVolume;
                    listOfVehiclesDetails.AppendFormat(
                        "The truck's cargo is {0}in cooling.{1}",
                        isOrNot,
                        Environment.NewLine);
                    listOfVehiclesDetails.AppendFormat(
                        "Cargo volume is: {0}.{1}",
                        cargoVolume,
                        Environment.NewLine);
                }
            }
            else
            {
                ArgumentNullException argumentNullException = new ArgumentNullException();
                throw argumentNullException;
            }

            return listOfVehiclesDetails;
        }
        
        private StringBuilder createVehicleGeneralList(string i_LicenseNumber)
        {
            StringBuilder vehiclesGeneralDetails = new StringBuilder();

            /*General*/
            string licenseNumber = i_LicenseNumber;
            string modelName = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.ModelName;
            string ownerName = r_VehiclesInGarage[i_LicenseNumber].OwnerName;
            eVehicleStatus vehicleStatus = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.VehicleStatus;
            string wheelManufacturerName = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.WheelsCollection[0].WheelManufacturerName;
            float currentAirPressure = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.WheelsCollection[0].CurrentAirPressure;
            float currentAmountOfEnergy = r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType.CurrentAmountOfEnergy;

            string details = string.Format(
@"The license number is: {0}.
The model name is: '{1}'.
Owner name: {2}
The status of the vehicle in the garage is: {3}
The wheel's manufacturer is '{4}' and the current air pressure of each wheel is {5}. {6}",
                licenseNumber,
                modelName,
                ownerName,
                vehicleStatus,
                wheelManufacturerName,
                currentAirPressure,
                Environment.NewLine);

            vehiclesGeneralDetails.Append(details);

            if(r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType is FuelEngine)
            {
                eFuelTypes fuelType = ((FuelEngine)r_VehiclesInGarage[i_LicenseNumber].VehicleOwner.EngineType).FuelType;
                vehiclesGeneralDetails.AppendFormat("Vehicle's energy amount is {0} litters.{1}", currentAmountOfEnergy, Environment.NewLine);
                vehiclesGeneralDetails.AppendFormat("Vehicle's fuel type is {0}.{1}", fuelType.ToString(), Environment.NewLine);
            }
            else
            {
                vehiclesGeneralDetails.AppendFormat("Vehicle's energy is {0} hours.", currentAmountOfEnergy);
            }

            return vehiclesGeneralDetails;
        }
    }
}