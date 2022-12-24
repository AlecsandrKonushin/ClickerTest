using UnityEngine;

namespace UI
{
    public class ScrollController : MonoBehaviour
    {
        [SerializeField] private GameObject blockBusinessPrefab;

        private GameObject[] blockBusinesses;

        public void Start()
        {
            ShowBusinessUi(5);
        }

        public void ShowBusinessUi(int count)
        {
            blockBusinesses = new GameObject[count];

            for (int i = 0; i < count; i++)
            {
                GameObject business = Instantiate(blockBusinessPrefab, transform);
                blockBusinesses[i] = business;
            }
        }
    }
}