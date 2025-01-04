using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float damage = 1f;
    // Update is called once per frame

    public float getDamage()
    {
        return damage;
    }
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
