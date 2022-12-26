using Business;
using Data;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BusinessController", menuName = "Controllers/BusinessController")]
    public class BusinessController : BaseController
    {
        [SerializeField] private BusinessData[] businessesData;

        public BusinessEntity[] Businesses { get; private set; }

        public override void OnInitialize()
        {
            Businesses = new BusinessEntity[businessesData.Length];

            for (int i = 0; i < businessesData.Length; i++)
            {
                Businesses[i] = new BusinessEntity(businessesData[i]);
            }
        }
    }
}