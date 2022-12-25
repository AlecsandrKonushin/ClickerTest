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
        [BoxGroup("Up block")]
        [SerializeField] private TextMeshProUGUI nameText;
        [BoxGroup("Up block")]
        [SerializeField] private Slider sliderRevenue;

        [BoxGroup("Center block")]
        [SerializeField] private TextMeshProUGUI levelText, revenueText, priceLevelUpText;
        [BoxGroup("Center block")]
        [SerializeField] private Button levelUpButton;

        [BoxGroup("Down block")] private UpgradeButton[] upgradeButtons;

        private BusinesEntity business;

        public void SetData(BusinesEntity businessEntity)
        {
            business = businessEntity;

            business.ChangeTimeEvent.AddListener(ChangeValueSlider);
            business.ChangeDataEvent.AddListener(ChangeData);

            levelUpButton.onClick.AddListener(() => { business.ClickLevelUpButton(); });

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
            levelText.text = business.Level.ToString();
            revenueText.text = business.Revenue.ToString();
            priceLevelUpText.text = business.PriceLevelUp.ToString();
        }
    }
}
