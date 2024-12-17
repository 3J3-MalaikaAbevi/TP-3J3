/*  Fonctionnement et utilité générale du script
    Script pour la gestion des changements de scene
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionScene : MonoBehaviour
{
    public static Scene sceneActuelle;   //Variable statique pour connetre la scene actuelle
    public GameObject[] textesInstructions;   //Tableau pour enregistrer les canvas pour la scènes d'instructions
    int canvasActifInstructions = 1;   //Variable pour identifier le canvas d'instruictions à rendre actif
    public TextMeshProUGUI contexteDecompteTexte;   //Variable pour le décompte avant que la partie ne commence dans la scène de contexte
    public TextMeshProUGUI meilleurTemps;    //Variable pour afficher le meilleur temps dans l'intro
    public TextMeshProUGUI meilleurTours;    //Variable pour afficher le meilleur nombre de tours fait 
    int decompte = 10;    //Décompte pour la scène de contexte
    bool contexteEnCours;     //Pour savoir si on est dans la scène de contexte

    void Start()
    {
        sceneActuelle = SceneManager.GetActiveScene();   //Enregistrement de la scene actuelle

        //Affichage du meilleur score dans l'introduction
        if(sceneActuelle.name == "sceneIntro")
        {
            meilleurTemps.text = Mathf.Floor(GestionRetroFin.meilleurTemps / 60).ToString("00") + ":" + Mathf.FloorToInt(GestionRetroFin.meilleurTemps % 60).ToString("00") + " min";
            meilleurTours.text = GestionRetroFin.meilleurTours + " tours";
        }
    }


    void Update()
    {
        //Si on est à la scene d'intro, alors on utilise la barre d'espace pour charger la scene de partie
        if (sceneActuelle.name == "sceneIntro" || sceneActuelle.name == "sceneInstructions")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("sceneContexte");
            }
        }

        //On appelle la fonction du decompte quand on est dans la scene de contexte 
        if(sceneActuelle.name == "sceneContexte")
        {
            if (!contexteEnCours)
            {
                InvokeRepeating("DecompteContexte", 1f, 1f);
                contexteEnCours = true; //Pour ne pas que la fonction soir appeler a répétition
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

        // Dans la scène finale, on peut retourner à l'introduction en appuyant sur la barre d'espace
        if(sceneActuelle.name == "sceneRetroFin")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("scenePartie");
            }
        }
    }

    //Fonction pour le decompte dans la scène de mise en contexte
    void DecompteContexte()
    {
        decompte--;
        contexteDecompteTexte.text = "La partie commence dans " + decompte + " !";
        if(decompte == 0)
        {
            SceneManager.LoadScene("scenePartie");
        }
    }
}
