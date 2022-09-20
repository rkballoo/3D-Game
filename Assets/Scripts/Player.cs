using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;

    public int score;

    private bool isGrounded;

    public UI ui;

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Set out velocity based on out inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // Create a copy of our velocity variable and set the y axis to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // If we are moving, rotate to face our moving direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }
    }

    // Checks if the player is standing on something
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
            
        }
    }

    // Reloads the current scene
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Add coin amount to score
    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }

    public void ShowGrounded()
    {
        Debug.Log(isGrounded);
    }
}
