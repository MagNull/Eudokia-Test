using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MonsterSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void Start() => _audioSource.clip = _clickSound;

    private void OnMouseDown() => _audioSource.Play();
}
