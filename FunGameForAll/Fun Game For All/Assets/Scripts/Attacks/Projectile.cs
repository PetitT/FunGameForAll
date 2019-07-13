using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
}
