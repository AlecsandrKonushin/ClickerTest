using Business;
using Data;
using Logs;
using SaveSystem;
using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BusinessController", menuName = "Controllers/BusinessController")]
    public class BusinessController : BaseController
    {
        [SerializeField] private BusinessData[] businessesData;

        public BusinessEntity[] Businesses { get; private set; }

        public override void OnStart()
        {
            if (BoxControllers.GetController<SaveController>().IsHaveSave)
            {
                SaveBusinessData[] saveData = BoxControllers.GetController<SaveController>().GetBusinessData;

                if(saveData.Length != businessesData.Length)
                {
                    LogManager.Instance.LogError($"Save business count != business scriptable count");
                }

                Businesses = new BusinessEntity[saveData.Length];

                for (int i = 0; i < saveData.Length; i++)
                {
                    Businesses[i] = new BusinessEntity(saveData[i]);
                }
            }
            else
            {
                Businesses = new BusinessEntity[businessesData.Length];

                for (int i = 0; i < businessesData.Length; i++)
                {
                    Businesses[i] = new BusinessEntity(businessesData[i]);
                }
            }

            UIManager.GetWindow<MainWindow>().ShowBusinessUi(Businesses);
        }
    }
}