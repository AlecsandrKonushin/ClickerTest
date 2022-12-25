using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameController", menuName = "Controllers/GameController")]
    public class GameController : BaseController
    {        
        public override void OnStart()
        {
            UIManager.GetWindow<MainWindow>().ShowBusinessUi(BoxControllers.GetController<BusinessController>().Businesses);
        }        
    }
}