using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime
{
    [RequireComponent(typeof(BoosterView))]
    public class BoosterPresenter : MonoBehaviour
    {
        [SerializeReference]
        private IBooster _booster;
        private BoosterView _boosterView;
        private TextMeshProUGUI _cooldownText;

        private void Awake()
        {
            _boosterView = GetComponent<BoosterView>();
        }

        private void OnEnable()
        {
            _boosterView.Clicked += _booster.Use;
            _booster.Used += _boosterView.OnUsed;

        }

        private void OnDisable()
        {
            _boosterView.Clicked -= _booster.Use;
            _booster.Used -= _boosterView.OnUsed;
        }
    }
}