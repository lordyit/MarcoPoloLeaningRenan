using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnEnable()
    {
        BrikController.OnDestroy += PlayBlast;
    }

    private void OnDisable()
    {
        BrikController.OnDestroy -= PlayBlast;
    }

    void PlayBlast()
    {
        audioSource.Play();
    }
}
