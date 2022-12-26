using Business;
using NaughtyAttributes;
using TMPro;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BlockBusinessUi : MonoBehaviour
    {
        private const string SIGN_PRICE = "$", LEVEL_UP_STRING = "LVL UP", ZERO_PRICE = "0",
                             PROCENT_SIGN = "%", BUY_STRING = "Buy", IS_BUY_STRING = "Is Buy", PRICE_STRING = "Price";

        [BoxGroup("Up block")]
        [SerializeField] private TextMeshProUGUI nameText;
        [BoxGroup("Up block")]
        [SerializeField] private Slider sliderRevenue;

        [BoxGroup("Center block")]
        [SerializeField] private TextMeshProUGUI levelUpLabelText, levelText, revenueText, priceLevelUpText;
        [BoxGroup("Center block")]
        [SerializeField] private Button levelUpButton;

        [BoxGroup("Down block")]
        [SerializeField] private UpgradeButton[] upgradeButtons;

        private BusinessEntity business;

        public void SetData(BusinessEntity businessEntity)
        {
            business = businessEntity;

            business.ChangeTimeEvent.AddListener(ChangeValueSlider);
            business.ChangeDataEvent.AddListener(ChangeData);

            levelUpButton.onClick.AddListener(() => { business.ClickLevelUpButton(); });

            for (int i = 0; i < business.Upgrades.Length; i++)
            {
                upgradeButtons[i].SetData(business, business.Upgrades[i].Id);
            }

            ChangeData();
        }

        private void ChangeValueSlider(float maxValue, float currentValue)
        {
            sliderRevenue.maxValue = maxValue;
            sliderRevenue.value = currentValue;
        }

        private void ChangeData()
        {
            nameText.text = business.Name;
            priceLevelUpText.text = business.PriceLevelUp + SIGN_PRICE;

            if (business.IsBuy)
            {
                levelText.text = business.Level.ToString();
                revenueText.text = business.Revenue.ToString();
                levelUpLabelText.text = LEVEL_UP_STRING;
            }
            else
            {
                levelText.text = ZERO_PRICE;
                revenueText.text = ZERO_PRICE;
                levelUpLabelText.text = BUY_STRING;
            }

            foreach (var upgrade in business.Upgrades)
            {            
                foreach (var upgradeButton in upgradeButtons)
                {
                    if(upgrade.Id == upgradeButton.IdUpgrade)
                    {
                        string factorRevenue = upgrade.FactorRevenue + PROCENT_SIGN;
                        string price;

                        if (upgrade.IsBuy)
                        {
                            price = IS_BUY_STRING;
                        }
                        else
                        {
                            price = PRICE_STRING + upgrade.Price + SIGN_PRICE;
                        }

                        upgradeButton.SetViewData(upgrade.Name, factorRevenue, price);
                    }
                }
            }
        }
    }
}
