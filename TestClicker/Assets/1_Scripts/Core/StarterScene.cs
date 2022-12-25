using UnityEngine;

namespace Core
{
    public class StarterScene : Singleton<StarterScene>
    {
        [SerializeField] private BaseController[] controllers;

        public void Init()
        { 
            BoxControllers.Init(controllers);
        }
    }
}
