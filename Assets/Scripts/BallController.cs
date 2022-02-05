using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float[] kickYMultipliers;
    [SerializeField] private float velocityDiffForce;

    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity += new Vector2(transform.position.x - collision.gameObject.transform.position.x * velocityDiffForce, 0);
        }
    }

    public void IncreaseSpeed(float increase)
    {
        speed += increase;
    }

    public void Kick()
    {
        Vector2 kickRange = Random.insideUnitCircle;
        kickRange.y = kickRange.x * Random.Range(kickYMultipliers[0], kickYMultipliers[1]);

        rb.velocity = kickRange * speed;
    }

    void MoveBall()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void FixedUpdate()
    {
        MoveBall();
    }
}