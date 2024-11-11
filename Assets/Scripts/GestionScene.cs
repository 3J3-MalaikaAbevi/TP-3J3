/*  Fonctionnement et utilit� g�n�rale du script
    Script pour la gestion des changements de scene
    Par : Mala�ka Abevi
    Derni�re modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    Scene sceneActuelle;

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
                print("U");
                SceneManager.LoadScene("sceneIntro");
            }
        }
    }
}
