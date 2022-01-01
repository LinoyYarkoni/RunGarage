namespace Ex03.GarageLogic
{
    public enum eEngineType
    {
        Electric,
        Fuel,
    }

    public abstract class Engine
    {
        private float m_MaxCapacityOfEnergy;
        private float m_CurrentAmountOfEnergy;

        public float MaxCapacityOfEnergy
        {
            get
            {
                return this.m_MaxCapacityOfEnergy;
            }

            set
            {
                m_MaxCapacityOfEnergy = value;
            }
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return this.m_CurrentAmountOfEnergy;
            }

            set
            {
                m_CurrentAmountOfEnergy = value;
            }
        }
    }
}