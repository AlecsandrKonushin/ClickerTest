using Business;
using Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace UI.Windows
{
    public class MainWindow : Window
    {
        [BoxGroup("Up block")]
        [SerializeField] private TextMeshProUGUI moneyPlayerText;
        [BoxGroup("Business block prefab")]
        [SerializeField] private BlockBusinessUi blockBusinessPrefab;
        [BoxGroup("Content object")]
        [SerializeField] private GameObject content;

        private BlockBusinessUi[] blockBusinesses;

        public override void OnStart()
        {
            // TODO: Load money from save
            moneyPlayerText.text = 0 + "$";
        }

        public void ShowBusinessUi(BusinessEntity[] businesses)
        {
            blockBusinesses = new BlockBusinessUi[businesses.Length];

            for (int i = 0; i < businesses.Length; i++)
            {
                BlockBusinessUi business = Instantiate(blockBusinessPrefab, content.transform);
                business.SetData(businesses[i]);
                blockBusinesses[i] = business;
            }

            BoxControllers.GetController<MoneyController>().ChangeMoneyEvent.AddListener(ChangeMoneyText);
        }

        private void ChangeMoneyText(int value)
        {
            moneyPlayerText.text = value + "$";
        }
    }
}