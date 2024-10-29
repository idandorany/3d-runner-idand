using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float LeftRightSpeed = 2;
   
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > levelbund.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < levelbund.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed * -1);
            }
        }
    }
}
