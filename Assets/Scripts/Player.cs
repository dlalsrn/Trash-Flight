using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    private int weaponNum = 0;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        // if (Input.GetKey(KeyCode.LeftArrow))
        //     transform.position -= moveTo;
        // else if (Input.GetKey(KeyCode.RightArrow))
        //     transform.position += moveTo;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float X = Mathf.Clamp(mousePos.x, -3.1f, 3.1f);
        transform.position = new Vector3(X, transform.position.y, transform.position.z);

        if (!GameManager.instance.isGameOver)
            Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            if (weaponNum > weapons.Length)
                weaponNum = weapons.Length - 1;
            Instantiate(weapons[weaponNum], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            GameManager.instance.SetGameover();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponNum++;
        if (weaponNum >= weapons.Length)
            weaponNum = weapons.Length - 1;
    }
}
