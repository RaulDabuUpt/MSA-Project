using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            KnifeHitGameControllerScript.Instance.GameUI.DerementDisplayedKnifeCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
        {
            return;
        }

        isActive = false;

        if (collision.collider.tag == "Log")
        {

            GetComponent<ParticleSystem>().Play();

            rb.linearVelocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            KnifeHitGameControllerScript.Instance.OnSuccesfulKnifeHit();
        }
        else if (collision.collider.tag == "Knife")
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -2);
            KnifeHitGameControllerScript.Instance.StartGameOverSequence(false);
        }
    }
}
