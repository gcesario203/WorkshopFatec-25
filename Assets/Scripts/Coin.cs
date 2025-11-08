using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent Collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collect?.Invoke();
            MoneyManager.Instance.AddMoney();
        }
    }

    public void Disable()
    {
        StartCoroutine(Desabilitar());
    }

    IEnumerator Desabilitar()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}