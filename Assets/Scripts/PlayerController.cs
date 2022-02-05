using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody2D rBody;

    public void IncreaseSpeed(float increase)
    {
        velocity += increase;
    }

    void InputControllerKeyboard()
    {
        if (!Input.GetButton("Horizontal"))
        {
            rBody.velocity = Vector2.zero;
            return;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rBody.velocity = Vector2.right * velocity;
        }
        else
        {
            rBody.velocity = Vector2.left * velocity;
        }

    }

    void InputControllerMobile()
    {
        if (Input.mousePosition.x > Screen.width / 2 && Input.GetMouseButton(0))
        {
            rBody.velocity = Vector2.right * velocity;
        }
        else if (Input.GetMouseButton(0))
        {
            rBody.velocity = Vector2.left * velocity;
        }
        else if (!Input.GetButton("Horizontal"))
        {
            rBody.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        InputControllerKeyboard();
        InputControllerMobile();
    }
}