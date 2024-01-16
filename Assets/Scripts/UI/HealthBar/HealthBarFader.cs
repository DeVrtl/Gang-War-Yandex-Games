using System.Collections;
using UnityEngine;

namespace GangWar.UI.HealthBar
{
    public class HealthBarFader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _healthGroup;
        [SerializeField] private float _fadeDuration;

        private Coroutine _fadeOutJob;
        private float _elapsedTime = 0f;
        private const float _maxAlpha = 1;
        private const float _minAlpha = 0;

        public void FadeIn()
        {
            if (_fadeOutJob == null)
            {
                _healthGroup.alpha = _maxAlpha;

                _fadeOutJob = StartCoroutine(FadeOut());
            }
            else
            {
                _elapsedTime = 0f;
            }

            if (_healthGroup.alpha == _minAlpha && _fadeOutJob != null)
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
                _healthGroup.alpha = Mathf.Lerp(startAlpha, _minAlpha, _elapsedTime / _fadeDuration);

                _elapsedTime += Time.deltaTime;

                yield return null;
            }

            _healthGroup.alpha = _minAlpha;
        }
    }
}