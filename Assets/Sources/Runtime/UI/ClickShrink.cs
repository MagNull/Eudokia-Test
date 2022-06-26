using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sources.Runtime
{
    public class ClickShrink : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField]
        private float _power;
        [SerializeField]
        private float _duration;

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(Vector3.one, _duration);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOScale(Vector3.one * _power, _duration);
        }
    }
}