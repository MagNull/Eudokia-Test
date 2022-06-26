using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime
{
    public class ScreenBoosterView : BoosterView
    {
        [SerializeField]
        private Image _screenEffect;
        
        protected override void UsedEffect()
        {
            _screenEffect.gameObject.SetActive(true);
        }

        protected override void CooldownedEffect()
        {
            _screenEffect.gameObject.SetActive(false);
        }
    }
}