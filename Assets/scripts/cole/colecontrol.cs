using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Add this to use TextMeshPro

public class colecontrol : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;

    void Update()
    {
        // Check if the coinCountDisplay is assigned and if it's a TextMeshProUGUI component
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