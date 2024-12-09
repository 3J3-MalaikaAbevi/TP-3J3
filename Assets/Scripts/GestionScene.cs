/*  Fonctionnement et utilit� g�n�rale du script
    Script pour la gestion des changements de scene
    Par : Mala�ka Abevi
    Derni�re modification : 06/11/2024
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
        //Si on est � la scene d'intro, alors on utilise la barre d'espace pour charger la scene de partie
        if (sceneActuelle.name == "sceneIntro" || sceneActuelle.name == "sceneInstructions")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("espace");
                SceneManager.LoadScene("scenePartie");
            }
        }

        //Si c'est la sc�ne d'intro, on peut charger la scene d'instructions si la touche Y a �t� cliqu�
        if (sceneActuelle.name == "sceneIntro")
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                print("Y");
                SceneManager.LoadScene("sceneInstructions");
            }
        }

        //Si c'est la sc�ne d'instructions, on peut charger la scene d'intro si la touche U a �t� cliqu�
        if (sceneActuelle.name == "sceneInstructions")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SceneManager.LoadScene("sceneIntro");
            }

            //Si on clique sur la fl�che de gauche, on passe � l'instuction suivante
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

            //Si on clique sur la fl�che de droite, on retourne � l'instruction pr�c�dente
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

            //On active le texte voulu et on d�sactive les autres 
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
