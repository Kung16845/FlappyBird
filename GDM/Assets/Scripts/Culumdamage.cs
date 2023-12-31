using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnDamage : MonoBehaviour
{
    private float damage = 1f;
    private Hp playerHealth;
    public float moveSpeed = 5f;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Hp>();
    }
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            playerHealth.TakeDamage(damage); 
            Debug.Log("Hit! Player takes 1 damage");
        }
    }
}