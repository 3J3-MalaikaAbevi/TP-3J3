using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationObstacle : MonoBehaviour
{
    public GameObject[] lesObstacles;
    public RuntimeAnimatorController transformation;

    public void ChoixApparition(int quantite)
    {
        foreach (GameObject unObstacle in lesObstacles)
        {
            int indexAleatoire = (int)Mathf.Round(Random.Range(0, quantite));
            if (indexAleatoire == 0)
            {
                unObstacle.tag = "solPresent";
                unObstacle.SetActive(true);
                unObstacle.GetComponent<Animator>().SetTrigger("apparition");
            }
            else
            {
                unObstacle.tag = "solAbsent";
                unObstacle.SetActive(false);
            }
        }

        Invoke("ApparitionSol", 5f);
    }

    void ApparitionSol()
    {
        foreach (GameObject unObstacle in lesObstacles)
        {
            if (unObstacle.tag == "solPresent")
            {
                unObstacle.tag = "piqueDanger";
            }
        }
    }
}


