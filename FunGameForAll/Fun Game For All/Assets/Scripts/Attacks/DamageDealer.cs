using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private int damage;
    public int Damage { get => damage; set => damage = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Character")
        collision.GetComponent<Character>().CurrentHealth -= Damage;
    }
}
