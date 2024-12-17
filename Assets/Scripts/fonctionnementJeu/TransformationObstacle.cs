/*  Fonctionnement et utilité générale du script
    Gestion de l'apparition des plateformes avec des piques (sol piquant)
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationObstacle : MonoBehaviour
{
   
    public GameObject[] lesObstacles;   // On enregistre les plateformes d'obstacles

    //Fonction pour le choix des plateforme qui prendont un sol piquant
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

    // Fonction pour rendre les sols piquants dangereux pour le joueur
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


