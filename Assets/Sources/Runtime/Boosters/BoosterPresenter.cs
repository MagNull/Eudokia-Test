using System;
using Sources.Runtime.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sources.Runtime
{
    [RequireComponent(typeof(BoosterView))]
    public class BoosterPresenter : MonoBehaviour
    {
        [SerializeReference]
        private IBooster _booster;
        private BoosterView _boosterView;
        private TextMeshProUGUI _cooldownText;
        private IUpdateable _boosterUpdateable;

        [Inject]
        private void Init(IObjectResolver resolver)
        {
            resolver.Inject(_booster);
        }

        private void Awake()
        {
            _boosterUpdateable = _booster as IUpdateable;
            _boosterView = GetComponent<BoosterView>();
        }

        private void Update()
        {
            _boosterUpdateable?.Update(Time.deltaTime);
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