using System.Collections;
using UnityEngine;

public class Pmove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftRightSpeed = 2f;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public Joystick joystick; 

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        
        float horizontalInput = joystick.Horizontal; 

        // Check keyboard input for left and right movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || horizontalInput < 0) // Move left
        {
            if (this.gameObject.transform.position.x > levelbund.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || horizontalInput > 0) // Move right
        {
            if (this.gameObject.transform.position.x < levelbund.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }

        // Handle jumping
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || joystick.Vertical > 0) // Jump if W, UpArrow, or joystick up is pressed
        {
            if (!isJumping)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }

        // Manage jump movement
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        comingDown = false;
        isJumping = false;
        playerObject.GetComponent<Animator>().Play("Run");
    }
}