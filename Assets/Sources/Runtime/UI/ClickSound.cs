using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ClickSound : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void Start() => _audioSource.clip = _clickSound;

    public void OnPointerDown(PointerEventData eventData) => _audioSource.Play();
}
