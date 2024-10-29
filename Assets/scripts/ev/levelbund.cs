using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelbund : MonoBehaviour
{
    public static float leftSide = -1f; 
    public static float rightSide = 3f; 
    public static float topSide;
    public float interanlLeft;
    public float interanlRight;
    
    void Update()
    {
        interanlLeft = leftSide;
        interanlRight = rightSide;
    }
}
