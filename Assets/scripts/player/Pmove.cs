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

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || horizontalInput < 0) 
        {
            if (this.gameObject.transform.position.x > levelbund.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || horizontalInput > 0) 
        {
            if (this.gameObject.transform.position.x < levelbund.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }

        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || joystick.Vertical > 0) 
        {
            if (!isJumping)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }

        
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