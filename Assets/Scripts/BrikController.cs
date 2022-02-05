using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrikController : MonoBehaviour
{
    [SerializeField] GameObject blast;

    public static event Action OnDestroy;
    private void OnCollisionEnter2D(Collision2D other)
    {
        GamePlay.Instance.score++;
        GamePlay.Instance.IncreaseSpeeds();
        GamePlay.Instance.blast.gameObject.transform.position = transform.position;
        GamePlay.Instance.blast.Play();
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}