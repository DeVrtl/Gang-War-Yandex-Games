using Cinemachine;
using UnityEngine;

namespace GangWar.Cinemachine
{
    public class CinemachineSwitcher : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _startCamera;
        [SerializeField] private CinemachineVirtualCamera _gameCamera;
        [SerializeField] private int _highPriority;
        [SerializeField] private int _lowPriority;

        private bool _isMainCamera = true;

        private void OnValidate()
        {
            _highPriority = Mathf.Clamp(_highPriority, 0, int.MaxValue);
            _lowPriority = Mathf.Clamp(_lowPriority, 0, int.MaxValue);
        }

        public void SwitchPriority()
        {
            if (_isMainCamera)
            {
                _gameCamera.Priority = _highPriority;
                _startCamera.Priority = _lowPriority;
            }
            else
            {
                _gameCamera.Priority = _lowPriority;
                _startCamera.Priority = _highPriority;
            }

            _isMainCamera = !_isMainCamera;
        }
    }
}