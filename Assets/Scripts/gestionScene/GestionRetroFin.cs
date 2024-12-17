/*  Fonctionnement et utilit� g�n�rale du script
    Script pour la gestion de la sc�ne de fin
    Par : Mala�ka Abevi
    Derni�re modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRetroFin : MonoBehaviour
{
    public TextMeshProUGUI tempsTotalTexte;   //Texte du temps de la partie faite
    public TextMeshProUGUI toursAtteintsTexte;   //Texte des tours de la partie faite
    public TextMeshProUGUI messageMeilleurScore;    //Texte pour le message si oui ou non un record a �t� battu
    public TextMeshProUGUI meilleursEnregistrement;   //Texte pour le meilleur record enregistr�
    public static float meilleurTemps;   //Enregistrement statique du meilleurs temps
    public static int meilleurTours;   //Enregistrement statique du meilleur nombre de tours accomplis

    void Start()
    {
        // Si un record a �t� battu, on affiche le message de f�licitations
        if(GestionTourPlateforme.tempsDePartieEnCours > meilleurTemps || GestionTourPlateforme.tourEnCours > meilleurTours)
        {
            messageMeilleurScore.text = "Wow, tu as battu un record !";
            messageMeilleurScore.color = new Color(0.28f, 0.8f, 0.81f, 1f);
        }

        //On enregistre une nouvelle valeur de meilleur score si celle de la partie finie est plus grande
        if (GestionTourPlateforme.tempsDePartieEnCours > meilleurTemps)
        {
            meilleurTemps = GestionTourPlateforme.tempsDePartieEnCours;
        }

        if(GestionTourPlateforme.tourEnCours > meilleurTours)
        {
            meilleurTours = GestionTourPlateforme.tourEnCours;
        }

        //Puis on �crit la valeur, nouvelle ou non, du meilleur record
        meilleursEnregistrement.text = meilleurTours + " Tour(s) et " + Mathf.Floor(meilleurTemps / 60).ToString("00") + ":" + Mathf.FloorToInt(meilleurTemps % 60).ToString("00") + " min";

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
