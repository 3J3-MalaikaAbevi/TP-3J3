using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRetroFin : MonoBehaviour
{
    public TextMeshProUGUI tempsTotalTexte;
    public TextMeshProUGUI toursAtteintsTexte;
    public static float meilleurTemps;
    public static int meilleurTours;

    void Start()
    {
        //On enregistre une nouvelle valeur de meilleur score si celle de la partie finie est plus grande
        if(GestionTourPlateforme.tempsDePartieEnCours > meilleurTemps)
        {
            meilleurTemps = GestionTourPlateforme.tempsDePartieEnCours;
        }

        if(GestionTourPlateforme.tourEnCours > meilleurTours)
        {
            meilleurTours = GestionTourPlateforme.tourEnCours;
        }

        //On affiche les r�sultats de la partie
        tempsTotalTexte.text = Mathf.Floor(GestionTourPlateforme.tempsDePartieEnCours / 60).ToString("00") + ":" + Mathf.FloorToInt(GestionTourPlateforme.tempsDePartieEnCours % 60).ToString("00") + " min";
        toursAtteintsTexte.text = GestionTourPlateforme.tourEnCours.ToString() + " Tour(s)";

        //Puis on r�initialise les valeurs du temps de partie
        GestionTourPlateforme.tempsDePartieEnCours = 0;
        GestionTourPlateforme.tourEnCours = 0;

        //Et on indique la partie n'est plus termin�
        ControleKaya.finPartie = false;
    }

    void Update()
    {
        //Retour � l'intro
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("sceneIntro");
        }

        //Recommencer une partie
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("scenePartie");
        }
    }
}
