using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private bool _isWork;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        StartCoroutine(CreationCoins());
    }

    private IEnumerator CreationCoins()
    {
        float waitSecond = 2;
        var waitTime = new WaitForSeconds(waitSecond);

        while(_isWork)
        {
            Instantiate(_coin, new Vector2(transform.position.x, transform.position.y) , Quaternion.identity);

            yield return waitTime;
        }
    }
}