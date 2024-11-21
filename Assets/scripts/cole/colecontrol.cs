using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class colecontrol : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

    void Update()
    {
        
        if (coinCountDisplay != null)
        {
            coinCountDisplay.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        }
        else
        {
            Debug.LogError("coinCountDisplay is not assigned!");
        }

    }
}