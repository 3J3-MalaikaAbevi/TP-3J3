/*  Fonctionnement et utilité générale du script
    Script pour la gestion des changements de scene
    Par : Malaïka Abevi
    Dernière modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    Scene sceneActuelle;
    public GameObject[] textesInstructions;
    int canvasActifInstructions = 1;

    void Update()
    {
        sceneActuelle = SceneManager.GetActiveScene();
        //Si on est à la scene d'intro, alors on utilise la barre d'espace pour charger la scene de partie
        if (sceneActuelle.name == "sceneIntro" || sceneActuelle.name == "sceneInstructions")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("espace");
                SceneManager.LoadScene("scenePartie");
            }
        }

        //Si c'est la scène d'intro, on peut charger la scene d'instructions si la touche Y a été cliqué
        if (sceneActuelle.name == "sceneIntro")
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                print("Y");
                SceneManager.LoadScene("sceneInstructions");
            }
        }

        //Si c'est la scène d'instructions, on peut charger la scene d'intro si la touche U a été cliqué
        if (sceneActuelle.name == "sceneInstructions")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SceneManager.LoadScene("sceneIntro");
            }

            //Si on clique sur la flèche de gauche, on passe à l'instuction suivante
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (canvasActifInstructions > 1)
                {
                    canvasActifInstructions--;
                    print(canvasActifInstructions);
                }
                else
                {
                    canvasActifInstructions = 1;
                    print(canvasActifInstructions);
                }
            }

            //Si on clique sur la flèche de droite, on retourne à l'instruction précédente
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (canvasActifInstructions < textesInstructions.Length)
                {
                    canvasActifInstructions++;
                    print(canvasActifInstructions);
                }
                else
                {
                    canvasActifInstructions = textesInstructions.Length;
                    print(canvasActifInstructions);
                }
            }

            //On active le texte voulu et on désactive les autres 
            foreach (GameObject texte in textesInstructions)
            {
                if (texte.name == "instructions" + canvasActifInstructions.ToString())
                {
                    texte.SetActive(true);
                }
                else
                {
                    texte.SetActive(false);
                }
            }
        }
    }
}
