using Business;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "FormulasController", menuName = "Controllers/FormulasController")]
    public class FormulasController : BaseController
    {
        public int GetRevenue(BusinessEntity business)
        {
            int valueUpgrades = 0;

            foreach (var upgrade in business.Upgrades)
            {
                if (upgrade.IsBuy)
                {
                    valueUpgrades += (int)(business.BaseRevenue / 100f * upgrade.FactorRevenue);
                }
            }

            int revenue = business.Level * business.BasePrice * (1 + valueUpgrades);
            return revenue;
        }

        public int GetPriceUpLevel(BusinessEntity business)
        {
            return (business.Level + 1) * business.BasePrice;
        }
    }
}