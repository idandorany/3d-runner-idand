using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColl : MonoBehaviour
{

    public GameObject thePlayer;
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<Pmove>().enabled = false;

    }
}
