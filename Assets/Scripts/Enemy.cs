using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Are we moving to the start?
        if(movingToStart)
        {
            // Over time move towards the start position
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            // Have we reached the start?
            if (transform.position == startPos)
            {
                movingToStart = false;
            }
        } 
        // Are we moving away from the start?
        else
        {
            // What is the end position?
            Vector3 endPos = startPos + (moveDirection * moveDistance);

            // Over time move towards the enda position
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

            // Have we reached the end?
            if (transform.position == endPos)
            {
                movingToStart = true;
            }
        }
    }
    
    // If enemy makes contact with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }
}
