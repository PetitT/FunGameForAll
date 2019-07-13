using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartExplosion : MonoBehaviour
{

    private float Timer;
    private float explosionTimer;
    private int explosionDamage;
    private GameObject explosion;

    public float Timer1 { get => Timer; set => Timer = value; }
    public float ExplosionTimer { get => explosionTimer; set => explosionTimer = value; }
    public int ExplosionDamage { get => explosionDamage; set => explosionDamage = value; }

    void Start()
    {
        explosion = FindObjectOfType<DataContainer>().data.others.explosion;
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine("Clock");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            collision.GetComponent<Character>().CurrentHealth = 0;
        }
    }

    public IEnumerator Clock()
    {
        yield return new WaitForSeconds(Timer1);
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(ExplosionTimer);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
