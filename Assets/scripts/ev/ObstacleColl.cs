using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleColl : MonoBehaviour
{

    public GameObject thePlayer;
    public GameObject levelcunt;
    void OnTriggerEnter(Collider other)

    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<Pmove>().enabled = false;
        levelcunt.GetComponent<runing>().enabled = false;
        levelcunt.GetComponent <endgame>().enabled = true;

    }
}
