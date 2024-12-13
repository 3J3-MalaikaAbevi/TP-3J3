using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationObstacle : MonoBehaviour
{
    public GameObject[] lesObstacles;
    public RuntimeAnimatorController transformation;
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject unObstacle in lesObstacles)
        {
            int indexAleatoire = (int)Mathf.Round(Random.Range(0, 192));
            //unObstacle.GetComponent().runtimeAnimatorController = transformation as RuntimeAnimatorController;
        }    
    }
}



