using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRetroFin : MonoBehaviour
{
    public TextMeshProUGUI tempsTotalTexte;
    public TextMeshProUGUI toursAtteintsTexte;
    public TextMeshProUGUI messageMeilleurScore;
    public TextMeshProUGUI meilleursEnregistrement;
    public static float meilleurTemps;
    public static int meilleurTours;

    void Start()
    {
        if(GestionTourPlateforme.tempsDePartieEnCours > meilleurTemps || GestionTourPlateforme.tourEnCours > meilleurTours)
        {
            messageMeilleurScore.text = "Wow, tu as battu un record !";
            messageMeilleurScore.color = new Color(72, 205, 209, 255);
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

        //Puis on écrit la valeur, nouvelle ou non, du meilleur record
        meilleursEnregistrement.text = meilleurTours + " Tour(s) et " + Mathf.Floor(meilleurTemps / 60).ToString("00") + ":" + Mathf.FloorToInt(meilleurTemps % 60).ToString("00") + " min";

        //On affiche les résultats de la partie
        tempsTotalTexte.text = Mathf.Floor(GestionTourPlateforme.tempsDePartieEnCours / 60).ToString("00") + ":" + Mathf.FloorToInt(GestionTourPlateforme.tempsDePartieEnCours % 60).ToString("00") + " min";
        toursAtteintsTexte.text = GestionTourPlateforme.tourEnCours.ToString() + " Tour(s)";

        //Puis on réinitialise les valeurs du temps de partie
        GestionTourPlateforme.tempsDePartieEnCours = 0;
        GestionTourPlateforme.tourEnCours = 0;

        //Et on indique la partie n'est plus terminé
        ControleKaya.finPartie = false;
    }

    void Update()
    {
        //Retour à l'intro
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
