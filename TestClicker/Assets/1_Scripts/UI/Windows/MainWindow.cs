using Business;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace UI.Windows
{
    public class MainWindow : Window
    {
        [BoxGroup("Up block")]
        [SerializeField] private TextMeshProUGUI mainBalanceText;
        [BoxGroup("Business block prefab")]
        [SerializeField] private BlockBusinessUi blockBusinessPrefab;
        [BoxGroup("Content object")]
        [SerializeField] private GameObject content;

        private BlockBusinessUi[] blockBusinesses;

        public void ShowBusinessUi(BusinesEntity[] businesses)
        {
            blockBusinesses = new BlockBusinessUi[businesses.Length];

            for (int i = 0; i < businesses.Length; i++)
            {
                BlockBusinessUi business = Instantiate(blockBusinessPrefab, content.transform);
                business.SetData(businesses[i]);
                blockBusinesses[i] = business;
            }
        }
    }
}