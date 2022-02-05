using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GamePlay.Instance.lives--;
        GamePlay.Instance.Goal();
    }
}