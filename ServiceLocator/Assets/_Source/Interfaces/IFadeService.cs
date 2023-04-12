using DG.Tweening;
using UnityEngine.UI;

namespace UISystem
{
    public interface IFadeService
    {
        Tween FadeIn(Image img, float duration);
        Tween FadeOut(Image img, float duration);
    }
}