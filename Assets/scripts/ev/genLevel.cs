using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 35; 
    public bool creatsection = false;
    public int secNum;
   

    // Update is called once per frame
    void Update()
    {
        if (creatsection == false)
        {
            creatsection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 35;
        yield return new WaitForSeconds(5);
        creatsection=false;
    }
}
