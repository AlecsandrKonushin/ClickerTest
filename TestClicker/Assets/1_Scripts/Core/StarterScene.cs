using UI;
using UnityEngine;

namespace Core
{
    public class StarterScene : Singleton<StarterScene>
    {
        [SerializeField] private BaseController[] controllers;

        public void Init() 
        {
            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            BoxControllers.Init(controllers);
        }

        // TODO: DELETE. For test
        public void Start()
        {
            Init();
        }
    }
}
