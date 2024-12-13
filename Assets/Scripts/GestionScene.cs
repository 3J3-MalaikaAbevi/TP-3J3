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
using UnityEngine.UI;

public class GestionScene : MonoBehaviour
{
    public static Scene sceneActuelle;
    public GameObject[] textesInstructions;
    int canvasActifInstructions = 1;
    public TextMeshProUGUI contexteDecompteTexte;
    public TextMeshProUGUI meilleurTemps;
    public TextMeshProUGUI meilleurTours;
    int decompte = 10;
    bool contexteEnCours;
    public Button suivantBnt;
    public Button precedentBnt;

    void Start()
    {
        sceneActuelle = SceneManager.GetActiveScene();

        // Écouteurs d'évenements pour les boutons dans la scène d'instructions
        if (sceneActuelle.name == "sceneInstructions")
        {
            suivantBnt.onClick.AddListener(delegate { ChangerInstruction(1); });
            precedentBnt.onClick.AddListener(delegate { ChangerInstruction(-1); });
        }

        if(sceneActuelle.name == "sceneIntro")
        {
            meilleurTemps.text = Mathf.Floor(GestionRetroFin.meilleurTemps / 60).ToString("00") + ":" + Mathf.FloorToInt(GestionTourPlateforme.tempsDePartieEnCours % 60).ToString("00") + " min";
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
                print("espace");
                SceneManager.LoadScene("sceneContexte");
            }
        }

        if(sceneActuelle.name == "sceneContexte")
        {
            if (!contexteEnCours)
            {
                InvokeRepeating("DecompteContexte", 1f, 1f);
                contexteEnCours = true;
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

        if(sceneActuelle.name == "sceneRetroFin")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("scenePartie");
            }
        }
    }
    void DecompteContexte()
    {
        decompte--;
        contexteDecompteTexte.text = "La partie commence dans " + decompte + " !";
        if(decompte == 0)
        {
            SceneManager.LoadScene("scenePartie");
        }
    }

   // Fonction pour changer les instructions dans la scène d'instruction 
    public void ChangerInstruction(int changement)
    {
        //Si on clique sur la flèche de gauche, on passe à l'instuction suivante
        if (changement == -1)
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
        if (changement == 1)
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
    }
}
