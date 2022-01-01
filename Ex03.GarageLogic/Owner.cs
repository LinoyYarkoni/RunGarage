namespace Ex03.GarageLogic
{
    public class Owner
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_VehicleOwner;

        public Owner(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_VehicleOwner)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.r_VehicleOwner = i_VehicleOwner;
        }

        public Vehicle VehicleOwner
        {
            get
            {
                return this.r_VehicleOwner;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.r_OwnerName;
            }
        }
    }
}