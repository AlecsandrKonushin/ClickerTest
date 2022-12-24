using System.Collections;
using System.Collections.Generic;
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

    }
}
