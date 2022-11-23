using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.BikeEventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool _isHUDDisplayOn;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START,DisplayHUD);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.STOP,DisplayHUD);
        }

        private void DisplayHUD()
        {
            _isHUDDisplayOn = true;
        }

        private void OnGUI()
        {
            if (!_isHUDDisplayOn)
                return;
            if(GUILayout.Button("Stop Race"))
            {
                RaceEventBus.Publish(RaceEventType.STOP);
                _isHUDDisplayOn = false;
            }
        }
    }
}
