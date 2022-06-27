using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class UIScroller : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed;
    private ScrollRect _scrollRect;

    private void Awake() => _scrollRect = GetComponent<ScrollRect>();

    private void Update() => _scrollRect.velocity = Vector2.up * _scrollSpeed;

    private void OnEnable() => _scrollRect.normalizedPosition = Vector2.one;
}
