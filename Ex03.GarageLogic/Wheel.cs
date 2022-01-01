namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private float m_CurrentAirPressure;
        private string m_WheelManufacturerName;
        private readonly float r_MaxAirPressure;
        
        public Wheel(string i_WheelManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            this.m_WheelManufacturerName = i_WheelManufacturerName;
            this.r_MaxAirPressure = i_MaxAirPressure;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string WheelManufacturerName
        {
            get
            {
                return this.m_WheelManufacturerName;
            }

            set
            {
                m_WheelManufacturerName = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void WheelInflation(float i_AirToAdd)
        {
            this.m_CurrentAirPressure = r_MaxAirPressure;
        }
    }
}