using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _crystalCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            _crystalCount++;
            _text.text = _crystalCount.ToString();
            Destroy(coin.gameObject);
        }
    }
}