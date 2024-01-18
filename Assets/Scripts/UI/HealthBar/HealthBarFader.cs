using System.Collections;
using UnityEngine;

namespace GangWar.UI.HealthBar
{
    public class HealthBarFader : MonoBehaviour
    {
        private const float MaxAlpha = 1;
        private const float MinAlpha = 0;

        [SerializeField] private CanvasGroup _healthGroup;
        [SerializeField] private float _fadeDuration;

        private Coroutine _fadeOutJob;
        private float _elapsedTime = 0f;

        public void FadeIn()
        {
            if (_fadeOutJob == null)
            {
                _healthGroup.alpha = MaxAlpha;

                _fadeOutJob = StartCoroutine(FadeOut());
            }
            else
            {
                _elapsedTime = 0f;
            }

            if (_healthGroup.alpha == MinAlpha && _fadeOutJob != null)
            {
                StopCoroutine(_fadeOutJob);
                _fadeOutJob = null;
            }
        }

        private IEnumerator FadeOut()
        {
            float startAlpha = _healthGroup.alpha;

            while (_elapsedTime < _fadeDuration)
            {
                _healthGroup.alpha = Mathf.Lerp(startAlpha, MinAlpha, _elapsedTime / _fadeDuration);

                _elapsedTime += Time.deltaTime;

                yield return null;
            }

            _healthGroup.alpha = MinAlpha;
        }
    }
}