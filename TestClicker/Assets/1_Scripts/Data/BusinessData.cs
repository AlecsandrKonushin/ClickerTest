using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BusinessData", menuName = "Data/BusinessData")]
    public class BusinessData : ScriptableObject
    {
        public string Name;
        public float TimeRevenue;
        public int BasePrice;
        public int BaseRevenue;
        public UpgradeData[] Upgrades;
    }
}