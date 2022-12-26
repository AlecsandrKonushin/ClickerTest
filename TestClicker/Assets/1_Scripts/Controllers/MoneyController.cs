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

        public int MoneyPlayer { get; private set; }

        public override void OnStart()
        {
            if (BoxControllers.GetController<SaveController>().IsHaveSave)
            {
                MoneyPlayer = BoxControllers.GetController<SaveController>().GetMoneyPlayer;
            }
            else
            {
                MoneyPlayer = 0;
            }

            ChangeMoneyEvent?.Invoke(MoneyPlayer);

        }

        public void AddMoney(int value)
        {
            MoneyPlayer += value;

            ChangeMoneyEvent?.Invoke(MoneyPlayer);
        }

        public bool CanBuy (int value)
        {
            return value <= MoneyPlayer;            
        }

        public void BuyEntity(int value)
        {
            MoneyPlayer -= value;

            ChangeMoneyEvent?.Invoke(MoneyPlayer);
        }
    }
}