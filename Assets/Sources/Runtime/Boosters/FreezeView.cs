using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime
{
    public class FreezeView : BoosterView
    {
        [SerializeField]
        private Image _freezeScreen;
        
        protected override void UsedEffect()
        {
            _freezeScreen.gameObject.SetActive(true);
        }

        protected override void CooldownedEffect()
        {
            _freezeScreen.gameObject.SetActive(false);
        }
    }
}