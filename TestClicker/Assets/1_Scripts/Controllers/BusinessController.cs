using Business;
using Data;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BusinessController", menuName = "Managers/BusinessController")]
    public class BusinessController : BaseController
    {
        [SerializeField] private BusinessData[] businessesData;

        private BusinesEntity[] businesses;

        public override void OnInitialize()
        {
            businesses = new BusinesEntity[businessesData.Length];

            for (int i = 0; i < businessesData.Length; i++)
            {
                businesses[i] = new BusinesEntity(businessesData[i]);
            }
        }
    }
}