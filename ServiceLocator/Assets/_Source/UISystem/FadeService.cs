using DG.Tweening;
using UnityEngine.UI;

namespace UISystem
{
    public class FadeService : IFadeService
    {
        private const float _maxDuration = 1;
        private const float _minDuration = 0;

        public Tween FadeIn(Image img, float duration) => Fade(img, _maxDuration, duration);

        public Tween FadeOut(Image img, float duration) => Fade(img, _minDuration, duration);

        private Tween Fade(Image img, float endValue, float duration) => img.DOFade(endValue, duration);
    }
}