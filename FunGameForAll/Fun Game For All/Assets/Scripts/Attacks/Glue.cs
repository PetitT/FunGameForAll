using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    private int slow;

    public int Slow { get => slow; set => slow = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            collision.GetComponent<Character>().MoveSpeed -= Slow;
            Debug.Log(collision.GetComponent<Character>().MoveSpeed);
            GetComponent<Projectile>().Speed = 0;
            gameObject.transform.parent = collision.gameObject.transform;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            Destroy(this);
        }
    }
}
