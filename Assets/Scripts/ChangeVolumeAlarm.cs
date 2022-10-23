using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolumeAlarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _rechedColorIn;
    [SerializeField] private Color _rechedColorOut;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _coroutine;

    private void Start()
    {
        _audio.Stop();
        _audio.volume = 0f;
    }

    public void Activate()
    {
        _audio.Play();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
        _spriteRenderer.color = _rechedColorIn;
    }

    public void Deactivate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ChangeVolume(_minVolume));

        if (_audio.volume == 0)
        {
            _audio.Stop();
        }
        _spriteRenderer.color = _rechedColorOut;
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (target != _audio.volume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, Time.deltaTime * _duration);
            
            yield return null;
        }
    }
}