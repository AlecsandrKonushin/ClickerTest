using Business;
using TMPro;
using UnityEngine;

namespace UI.Buttons
{
    public class UpgradeButton : MyButton
    {
        [SerializeField] private TextMeshProUGUI nameText, factorRevenueText, priceText;

        private BusinessEntity business;
        public int IdUpgrade { get; private set; }

        public void SetData(BusinessEntity business, int id)
        {
            this.business = business;
            IdUpgrade = id;
        }

        public void SetViewData(string name, string factorRevenue, string price)
        {
            nameText.text = name;
            factorRevenueText.text = factorRevenue;
            priceText.text = price;
        }

        protected override void OnClickButton()
        {
            business.ClickUpgradeButton(IdUpgrade);
        }
    }
}