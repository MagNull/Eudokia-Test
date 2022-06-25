using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime
{
    [RequireComponent(typeof(Button))]
    public class BoosterPresenter : MonoBehaviour
    {
        [SerializeReference]
        private IBooster _booster;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Update() => _booster?.Update(Time.deltaTime);

        private void OnEnable() => _button.onClick.AddListener(_booster.Use);

        private void OnDisable() => _button.onClick.AddListener(_booster.Use);
    }
}