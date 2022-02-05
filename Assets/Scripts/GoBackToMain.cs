using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMain : MonoBehaviour
{
    void GoToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene((int)Scenes.MAIN);
        }
    }

    void Update()
    {
        GoToMainMenu();
    }
}