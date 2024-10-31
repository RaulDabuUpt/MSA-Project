using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSound;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            flapSound.Play();
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 6 || transform.position.y < -6)
        {
            Die();
        }
    }

    public void Die()
    {
        if (birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
            deathSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
