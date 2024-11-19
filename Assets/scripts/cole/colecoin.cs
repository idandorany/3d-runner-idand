using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colecoin : MonoBehaviour
{
    public AudioSource coinFX;
    
    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        colecontrol.coinCount++;
        this.gameObject.SetActive(false);


    }
    
}
 