using System.Collections;
using UnityEngine;
using TMPro;  // Make sure to include the TextMeshPro namespace

public class runing : MonoBehaviour
{
    public TextMeshProUGUI disDisplay;  // Use TextMeshProUGUI for UI text
    public int disRun = 0;              // The running distance
    private bool addingDis = false;     // Flag to control when to add distance

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine when the game begins
        StartCoroutine(AddingDis());
    }

    // Coroutine to increment the distance at regular intervals
    IEnumerator AddingDis()
    {
        while (true)  // Infinite loop to keep adding distance
        {
            // Increment the distance
            disRun += 1;

            // Update the UI text using TextMeshPro
            disDisplay.text = disRun.ToString();

            // Wait for 0.25 seconds before continuing the loop
            yield return new WaitForSeconds(0.25f);
        }
    }
}