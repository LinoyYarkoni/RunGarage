using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InFix,
        Fixed,
        Paid,
    }

    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private Engine m_EngineType;
        private List<Wheel> m_WheelsCollection = new List<Wheel>(); 
        private eVehicleStatus m_VehicleStatus;

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public Engine EngineType
        {
            get
            {
                return this.m_EngineType;
            }

            set
            {
                this.m_EngineType = value;
            }
        }

        public List<Wheel> WheelsCollection
        {
            get
            {
                return this.m_WheelsCollection;
            }

            set
            {
                this.m_WheelsCollection = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return this.m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}