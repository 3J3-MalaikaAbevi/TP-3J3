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

        // �couteurs d'�venements pour les boutons dans la sc�ne d'instructions
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
        //Si on est � la scene d'intro, alors on utilise la barre d'espace pour charger la scene de partie
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

   // Fonction pour changer les instructions dans la sc�ne d'instruction 
    public void ChangerInstruction(int changement)
    {
        //Si on clique sur la fl�che de gauche, on passe � l'instuction suivante
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

        //Si on clique sur la fl�che de droite, on retourne � l'instruction pr�c�dente
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
