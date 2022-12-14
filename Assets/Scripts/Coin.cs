using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;
    public int amount = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    // If coin makes contact with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddScore(amount);
            Destroy(gameObject);
            other.GetComponent<Player>().ShowGrounded();
        }
    }
}
