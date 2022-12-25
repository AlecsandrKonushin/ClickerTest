using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [System.Serializable]
    public class ChangeMoney : UnityEvent<int> { }

    [CreateAssetMenu(fileName = "MoneyController", menuName = "Controllers/MoneyController")]
    public class MoneyController : BaseController
    {
        [HideInInspector]
        public ChangeMoney ChangeMoneyEvent = new ChangeMoney();

        private int moneyPlayer = 0;

        public void AddMoney(int value)
        {
            moneyPlayer += value;

            ChangeMoneyEvent?.Invoke(moneyPlayer);
        }
    }
}