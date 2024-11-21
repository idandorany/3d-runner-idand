using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    public GameObject gameover;
    
    void Start()
    {
        StartCoroutine(Endgame31());    
    }
    IEnumerator Endgame31()
    {
        yield return new WaitForSeconds(0);
        gameover.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
