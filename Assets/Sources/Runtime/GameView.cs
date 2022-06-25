using TMPro;
using UnityEngine;

namespace Sources.Runtime
{
    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _playerPointsView;
        [SerializeField]
        private GameObject _loseScreen;
        [SerializeField]
        private GameObject _hud;

        private void Awake() => _playerPointsView.text = "0";

        public void OnPointsChanged(int points) => _playerPointsView.text = points.ToString();

        public void OnLost()
        {
            _loseScreen.SetActive(true);
            _hud.SetActive(false);
        }
    }
}