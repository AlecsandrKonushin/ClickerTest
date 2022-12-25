using Business;
using Data;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BusinessController", menuName = "Controllers/BusinessController")]
    public class BusinessController : BaseController
    {
        [SerializeField] private BusinessData[] businessesData;

        public BusinesEntity[] Businesses { get; private set; }

        public override void OnInitialize()
        {
            Businesses = new BusinesEntity[businessesData.Length];

            for (int i = 0; i < businessesData.Length; i++)
            {
                Businesses[i] = new BusinesEntity(businessesData[i]);
            }
        }
    }
}