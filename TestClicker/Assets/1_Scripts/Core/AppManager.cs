using Logs;
using NaughtyAttributes;
using UnityEngine;

namespace Core
{
    public class AppManager : Singleton<AppManager>
    {
        [BoxGroup("Parameters app")]
        [SerializeField] private bool isNeedLog;

        private void Start()
        {
            LogManager.Instance.SetIsNeedLog = isNeedLog;

            LoadSceneManager.Instance.LoadGameScene();
        }
    }
}