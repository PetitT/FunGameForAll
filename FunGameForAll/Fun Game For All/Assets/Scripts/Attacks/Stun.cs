using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    private float stunTime;

    public float StunTime { get => stunTime; set => stunTime = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Character")
        {
            collision.GetComponent<Character>().StartCoroutine("Assommer",(StunTime));
        }
    }

}
