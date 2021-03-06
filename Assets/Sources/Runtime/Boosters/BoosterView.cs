using System;
using Sources.Runtime.Utils;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class BoosterView : MonoBehaviour
{
    public event Action Clicked;
    private Button _button;
    private Image _abilityImage;
    private Timer _timer;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _abilityImage = GetComponent<Image>();
        _timer = new Timer();
    }

    public void OnUsed(float duration, float coolDown)
    {
        _button.interactable = false;
        _timer.Start(duration, () => OnCooldowned(coolDown),
            tick => _abilityImage.fillAmount = tick / _timer.Duration);
        UsedEffect();
    }

    public void OnCooldowned(float coolDown)
    {
        _timer.Start(coolDown, () => _button.interactable = true,
            tick => _abilityImage.fillAmount = (_timer.Duration - tick) / _timer.Duration);
        CooldownedEffect();
    }

    protected virtual void UsedEffect(){}
    protected virtual void CooldownedEffect(){}

    private void Update()
    {
        _timer?.Tick(Time.deltaTime);
    }

    private void OnEnable() => _button.onClick.AddListener(() => Clicked?.Invoke());

    private void OnDisable() => _button.onClick.RemoveAllListeners();
}