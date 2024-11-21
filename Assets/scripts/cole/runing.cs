using System.Collections;
using UnityEngine;
using TMPro;  

public class runing : MonoBehaviour
{
    public TextMeshProUGUI disDisplay;
    public TextMeshProUGUI disEndDisplay;
    public int disRun = 0;              
    private bool addingDis = false;     

    
    void Start()
    {
        
        StartCoroutine(AddingDis());
    }

    
    IEnumerator AddingDis()
    {
        while (true)  
        {
            
            disRun += 1;

            
            disDisplay.text = disRun.ToString();
            


            
            yield return new WaitForSeconds(0.25f);
        }
    }
}