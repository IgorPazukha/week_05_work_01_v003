using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManagment : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _rechedColorIn;
    [SerializeField] private Color _rechedColorOut;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private bool _isStatus;
    private IEnumerator _corrutine;

    private void Start()
    {
        _audio.Stop();
        _audio.volume = 0f;
        _corrutine = ChangeVolume();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _audio.Play();
            _isStatus = true;
            StartCoroutine(_corrutine);
            _spriteRenderer.color = _rechedColorIn;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(_corrutine);
            _isStatus = false;
            
            _spriteRenderer.color = _rechedColorOut;
        }
    }

    private IEnumerator ChangeVolume()
    {
        var waitTime = new WaitForSeconds(0.1f);

        if (_isStatus == true)
        {
            while (_audio.volume < 1)
            {
                _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, Time.deltaTime * _duration);
                yield return waitTime;
            }
        }
        else
        {
            while (_audio.volume > 0)
            {
                _audio.volume = Mathf.MoveTowards(_audio.volume, _minVolume, Time.deltaTime * _duration);
                yield return waitTime;
            }
        }
    }
}