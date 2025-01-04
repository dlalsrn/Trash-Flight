using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    // Update is called once per frame
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -8f;
    [SerializeField]
    private float hp = 1f;
    public void SetmoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        if (transform.position.y < minY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.getDamage();

            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {   
                    GameManager.instance.SetGameover();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
        }
    }
}
