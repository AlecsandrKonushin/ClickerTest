using System;
using Business;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public int MoneyPlayer;
        public SaveBusinessData[] BusinessData;

        public SaveData(int playerMoney, BusinessEntity[] businesses)
        {
            MoneyPlayer = playerMoney;

            BusinessData = new SaveBusinessData[businesses.Length];

            for (int i = 0; i < businesses.Length; i++)
            {
                BusinessData[i] = new SaveBusinessData(businesses[i]);
            }
        }
    }
}