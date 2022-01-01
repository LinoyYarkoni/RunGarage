using System;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private const int k_FirstTypeOfEngine = 1;
        private const int k_SecondTypeOfEngine = 2;

        private const int k_CarMaxAirPressure = 29;
        private const int k_MotorcycleMaxAirPressure = 30;
        private const int k_TruckMaxAirPressure = 25;

        private const float k_CarMaxFuelTank = 48;
        private const float k_MotorcycleMaxFuelTank = 5.8f;
        private const float k_TruckMaxFuelTank = 130;

        private const float k_CarMaxBattery = 2.6f;
        private const float k_MotorcycleMaxBattery = 2.3f;

        public static int DisplayMenu()
        {
            string message = string.Format(
@"Please choose an action:
For adding new vehicle to the garage, press 1
For display list of license numbers in the garage, press 2
For change the status of vehicle in the garage, press 3
For inflate the wheels of the vehicle to maximum, press 4
For refueling vehicle, press 5
For recharging vehicle, press 6
For display full information, press 7
For leaving, press 0");
            Console.WriteLine(message);
            int userChoice = GetValidAndInRangeNumber(0, 7);
            return userChoice;
        }

        public static int GetTypeOfVehicleToCreate()
        {
            string welcomeMessage = string.Format(
@"Please enter the type of vehicle you want to insert: 
For Car press 1
For Motorcycle press 2
For Truck press 3");
            Console.WriteLine(welcomeMessage);
            int userChoice = GetValidAndInRangeNumber(1, 3);
            return userChoice;
        }

        public static void GetOwnerDetails(out string o_OwnerName, out string o_PhoneNumber)
        {
            o_OwnerName = getValidOnlyCharsInput(
                "Please enter the owner's first name",
                "The input must have only chars and no number or symbols");

            o_PhoneNumber = GetValidOnlyNumbersInput(
                "Please enter owner's phone number:",
                string.Format("The input must have only digits and no other characters"));
        }

        public static void GetGeneralVehicleDetails(
            out string o_LicenseNumber,         
            out string o_ModelName,
            out string o_WheelManufacturerName)
        {
            // Get License Number
            o_LicenseNumber = GetValidOnlyNumbersInput(
                "Please enter your license number:",
                "The input must have only digits and no other characters");

            // Get Model Name 
            o_ModelName = getValidNumbersAndChars(
                "Please enter the model name:",
                "The input must have only digits and characters, no spaces");

            // Get Wheel Manufacturer Name
            o_WheelManufacturerName = getValidOnlyCharsInput(
                "Please enter the wheel's manufacturer name:",
                "The input must have only chars and no number or symbols or spaces");
        }

        public static void GetSpecificDetailsForEngineType(
            int i_UserVehicleChoice,
            out float o_CurrentAirPressure,
            out float o_CurrentAmountOfEnergy,
            out eEngineType o_EngineType)
        {
            if(i_UserVehicleChoice == 3)
            {
                o_EngineType = eEngineType.Fuel;
            }
            else
            {
                string message = string.Format(
@"Please enter the type of engine: 
For Fuel Engine press 1
For Electric Engine press 2");
                Console.WriteLine(message);
                int engineType = GetValidAndInRangeNumber(k_FirstTypeOfEngine, k_SecondTypeOfEngine);
                o_EngineType = engineType == 1 ? eEngineType.Fuel : eEngineType.Electric;
            }

            if(i_UserVehicleChoice == 1)
            {
                if(o_EngineType == eEngineType.Fuel)
                {
                    Console.WriteLine("Please enter the car current amount of fuel:");
                    o_CurrentAmountOfEnergy = GetValidAndInRangeFloatNumber(0, k_CarMaxFuelTank);
                }
                else
                {
                    Console.WriteLine("Please enter the car current battery status:");
                    o_CurrentAmountOfEnergy = GetValidAndInRangeFloatNumber(0, k_CarMaxBattery);
                }
                Console.WriteLine("Please enter the car current air pressure:");
                o_CurrentAirPressure = GetValidAndInRangeFloatNumber(0, k_CarMaxAirPressure);
            }
            else if(i_UserVehicleChoice == 2)
            {
                if(o_EngineType == eEngineType.Fuel)
                {
                    Console.WriteLine("Please enter the motorcycle current amount of fuel:");
                    o_CurrentAmountOfEnergy = GetValidAndInRangeFloatNumber(0, k_MotorcycleMaxFuelTank);
                }
                else
                {
                    Console.WriteLine("Please enter the motorcycle current current battery status:");
                    o_CurrentAmountOfEnergy = GetValidAndInRangeFloatNumber(0, k_MotorcycleMaxBattery);
                }
                Console.WriteLine("Please enter the motorcycle current air pressure:");
                o_CurrentAirPressure = GetValidAndInRangeFloatNumber(0, k_MotorcycleMaxAirPressure);
            }
            else
            {
                Console.WriteLine("Please enter the truck current air pressure:");
                o_CurrentAirPressure = GetValidAndInRangeFloatNumber(0, k_TruckMaxAirPressure);
                Console.WriteLine("Please enter the truck current amount of fuel:");
                o_CurrentAmountOfEnergy = GetValidAndInRangeFloatNumber(0, k_TruckMaxFuelTank);
            }
        }

        public static void GetCarDetails(out eCarColor i_CarColor, out eNumberOfDoors i_NumberOfDoors)
        {
            string message = string.Format(
@"Please enter the color of the car: 
For Red Car press 1
For White Car press 2
For Black Car press 3
For Blue Car press 4");
            Console.WriteLine(message);
            int colorNumber = GetValidAndInRangeNumber(1, 4);
            if(colorNumber == 1)
            {
                i_CarColor = eCarColor.Red;
            }
            else if(colorNumber == 2)
            {
                i_CarColor = eCarColor.White;
            }
            else if(colorNumber == 3)
            {
                i_CarColor = eCarColor.Black;
            }
            else
            {
                i_CarColor = eCarColor.Blue;
            }

            message = string.Format(
@"Please enter the number of doors in the car: 
For 2 doors press 1
For 3 doors press 2
For 4 doors press 3
For 5 doors press 4");
            Console.WriteLine(message);
            int numberOfDoors = GetValidAndInRangeNumber(1, 4);
            if(numberOfDoors == 1)
            {
                i_NumberOfDoors = eNumberOfDoors.TwoDoors;
            }
            else if(numberOfDoors == 2)
            {
                i_NumberOfDoors = eNumberOfDoors.ThreeDoors;
            }
            else if(numberOfDoors == 3)
            {
                i_NumberOfDoors = eNumberOfDoors.FourDoors;
            }
            else
            {
                i_NumberOfDoors = eNumberOfDoors.FiveDoors;
            }
        }

        public static void GetMotorcycleDetails(out eLicenseType i_LicenseType, out int i_EngineVolume)
        {
            string message = string.Format(
@"Please enter your license type: 
For 'A' press 1
For 'A2' press 2
For 'AA' press 3
For 'B' press 4");
            Console.WriteLine(message);
            int licenseType = GetValidAndInRangeNumber(1, 4);
            if(licenseType == 1)
            {
                i_LicenseType = eLicenseType.A;
            }
            else if(licenseType == 2)
            {
                i_LicenseType = eLicenseType.A2;
            }
            else if(licenseType == 3)
            {
                i_LicenseType = eLicenseType.AA;
            }
            else
            {
                i_LicenseType = eLicenseType.B;
            }

            string engineVolumeResult = GetValidOnlyNumbersInput(
                "Please enter the engine volume:",
                "The input must have only digits and characters, no spaces");
            i_EngineVolume = int.Parse(engineVolumeResult);
        }

        public static void GetTruckDetails(out bool i_IsCooling, out int i_CargoVolume)
        {
            string message = string.Format(
@"Is the truck delivers in cooling ?
If the truck delivers in cooling, press 1
if not, please press 2");
            Console.WriteLine(message);
            int isCooling = GetValidAndInRangeNumber(1, 2);
            i_IsCooling = isCooling == 1 ? true : false;
            string engineVolumeResult = GetValidOnlyNumbersInput(
                "Please enter the cargo volume:",
                "The input must have only digits and characters, no spaces");
            i_CargoVolume = int.Parse(engineVolumeResult);
        }

        public static int GetParameter(string i_Message, int i_StartRange, int i_EndRange)
        {
            Console.WriteLine(i_Message);
            int userInput = GetValidAndInRangeNumber(i_StartRange, i_EndRange);
            return userInput;
        }

        public static int GetValidAndInRangeNumber(int i_StartRangeOfChoice, int i_EndRangeOfChoice)
        {
            bool isValidResult = false;
            bool isInRangeResult = false;
            bool isEmptyInput = false;
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                isValidResult = userInput.All(char.IsDigit);
                isEmptyInput = checkIfNotEmptyInput(userInput);
                if (!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else if (!isValidResult)
                {
                    Console.WriteLine("The input must have only digits and no other characters");
                }
                else if (int.TryParse(userInput, out int userInputInt))
                {
                    isInRangeResult = isNumberInRange(userInputInt, i_StartRangeOfChoice, i_EndRangeOfChoice);
                    if (!isInRangeResult)
                    {
                        Console.WriteLine(
                            "The number is not valid. Please enter a number between {0} to {1}",
                            i_StartRangeOfChoice,
                            i_EndRangeOfChoice);
                    }
                }
            }
            while (!(isValidResult && isInRangeResult && isEmptyInput));

            return int.Parse(userInput);
        }

        public static float GetValidAndInRangeFloatNumber(float i_StartRangeOfChoice, float i_EndRangeOfChoice)
        {
            bool isValidResult;
            bool isInRangeResult;
            bool isEmptyInput;

            string userInput;
            do
            {
                isValidResult = true;
                isInRangeResult = false;
                isEmptyInput = false;

                userInput = Console.ReadLine();
                isEmptyInput = checkIfNotEmptyInput(userInput);
                if(!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else if(float.TryParse(userInput, out float userInputFloat))
                {
                    isInRangeResult = isFloatNumberInRange(userInputFloat, i_StartRangeOfChoice, i_EndRangeOfChoice);
                    if(!isInRangeResult)
                    {
                        Console.WriteLine(
                            "The number is not valid. Please enter a number between {0} to {1}",
                            i_StartRangeOfChoice,
                            i_EndRangeOfChoice);
                    }
                }
                else
                {
                    Console.WriteLine("The input must have only digits and one 'decimal point'");
                    isValidResult = false;
                }
            }
            while (!(isValidResult && isInRangeResult && isEmptyInput));

            return float.Parse(userInput);
        }

        public static string GetValidOnlyNumbersInput(
            string i_InstructionMessage,
            string i_ErrorMessage)
        {
            bool isValidInput = false;
            bool isEmptyInput = false;
            string stringToCheck;
            Console.WriteLine(i_InstructionMessage);
            do
            {
                stringToCheck = Console.ReadLine();

                isValidInput = stringToCheck.All(char.IsDigit);
                isEmptyInput = checkIfNotEmptyInput(stringToCheck);
                if(!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else if(!isValidInput)
                {
                    Console.WriteLine(i_ErrorMessage);
                }
            }
            while(!(isValidInput && isEmptyInput));

            return stringToCheck;
        }

        public static void DisplayList(StringBuilder i_StringToPrint)
        {
            Console.WriteLine(i_StringToPrint);
        }

        public static string GetLicenseNumber()
        {
            string userLicenseNumber = GetValidOnlyNumbersInput(
                "Please enter the required license number:",
                "The input must have only digits and no other characters");
            return userLicenseNumber;
        }

        public static void DisplayErrorMessage(string i_ErrorMessage)
        {
            Console.WriteLine(i_ErrorMessage);
        }

        public static float GetAmountOfEnergy()
        {
            Console.WriteLine("Please enter the amount of energy: ");
            float amountOfEnergy = getValidFloatNumber();
            return amountOfEnergy;
        }

        private static float getValidFloatNumber()
        {
            bool isValidResult;
            bool isEmptyInput;
            string userInput;

            do
            {
                isValidResult = true;
                isEmptyInput = false;

                userInput = Console.ReadLine();
                isEmptyInput = checkIfNotEmptyInput(userInput);
                if(!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else if(!float.TryParse(userInput, out float userInputFloat))
                {
                    Console.WriteLine("The input must have only digits and one 'decimal point'");
                    isValidResult = false;
                }
            }
            while (!(isValidResult && isEmptyInput));

            return float.Parse(userInput);
        }

        private static string getValidOnlyCharsInput(string i_InstructionMessage, string i_ErrorMessage)
        {
            bool isValidInput = false;
            bool isEmptyInput = false;
            string stringToCheck;
            Console.WriteLine(i_InstructionMessage);
            do
            {
                stringToCheck = Console.ReadLine();
                isValidInput = stringToCheck.All(char.IsLetter);
                isEmptyInput = checkIfNotEmptyInput(stringToCheck);
                if (!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else if (!isValidInput)
                {
                    Console.WriteLine(i_ErrorMessage);
                }
            }
            while (!(isValidInput && isEmptyInput));

            return stringToCheck;
        }

        private static string getValidNumbersAndChars(string i_InstructionMessage, string i_ErrorMessage)
        {
            bool isValidInput = false;
            bool isEmptyInput = false;
            string stringToCheck;
            Console.WriteLine(i_InstructionMessage);
            do
            {
                stringToCheck = Console.ReadLine();
                isEmptyInput = checkIfNotEmptyInput(stringToCheck);
                if (!isEmptyInput)
                {
                    Console.WriteLine("The input can not be empty");
                }
                else
                {
                    foreach(char charToCheck in stringToCheck)
                    {
                        isValidInput = char.IsLetterOrDigit(charToCheck);
                        if(!isValidInput)
                        {
                            Console.WriteLine(i_ErrorMessage);
                            break;
                        }
                    }
                }
            }
            while (!(isValidInput && isEmptyInput));

            return stringToCheck;
        }

        private static bool isNumberInRange(int i_Number, int i_Min, int i_Max)
        {
            bool isNumberInRangeResult = i_Number >= i_Min && i_Number <= i_Max;

            return isNumberInRangeResult;
        }

        private static bool isFloatNumberInRange(float i_Number, float i_Min, float i_Max)
        {
            bool isNumberInRangeResult = i_Number >= i_Min && i_Number <= i_Max;

            return isNumberInRangeResult;
        }

        private static bool checkIfNotEmptyInput(string i_UserInput)
        {
            return i_UserInput != string.Empty;
        }
    }
}