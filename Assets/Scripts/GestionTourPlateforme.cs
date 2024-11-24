/*  Fonctionnement et utilité générale du script
    Gestion du déroulement global de la partie
    (niveau, round, minuteur, temps écoulé, etc)
    Par : Malaïka Abevi
    Dernière modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionTourPlateforme : MonoBehaviour
{
    float minuteurRound; //Minuteur pour le temps alou� pour aller � une bonne plateforme selon le round
    public float minuteur;  //Minuteur pour le temps alou� pour aller � une bonne plateforme
    float tempsDePartieEnCours;
    int repetitionRound = 2; //Variable pour le nombre de fois que la séquence d'un round s'execute
    int niveauEnCours = 1;  //Variable pour l'enregistrement du niveau atteint

    public GameObject kayaPersonnage;    //Réference à Kaya (personnage)
    public GameObject[] lesPlateformes;   //Tableau de gameObjects pour la gestion de chaque plateforme
    
    bool peutCoroutine = true;     //Variable pour savoir si on peut démarrer une nouvelle coroutine ou non
    bool peutReduireUIMinuteur; //Variable pour savoir si la barre du minuteur peut réduire

    public TextMeshProUGUI texteMinuteur;     //Variable Texte pour le minuteur (UI)
    public TextMeshProUGUI texteTempsPartieEnCours;     //Variable Texte pour le minuteur (UI)
    public Image barreMinuteurIMG; //Variable pour la barre de progression du minuteur (UI)
    public Color indiceBleu;
    public Color indiceRouge;
    public Color indiceVert;
    public Color indiceOrange;

    public Material matBlanc;

    void Start()
    {
        // StartCoroutine(GererTourDuree(10f));
    }

    void Update()
    {
        //----------------Niveau 1
        if (niveauEnCours == 1 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(8f));
        }

        //----------------Niveau 2
        if (niveauEnCours == 2  && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(5f));
        }

        //----------------Niveau 3
        if (niveauEnCours == 3 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(3f));
        }

        //----------------Niveau 4
        if (niveauEnCours == 4 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 5
        if (niveauEnCours == 5 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 6
        if (niveauEnCours == 6 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 7
        if (niveauEnCours == 7 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 8
        if (niveauEnCours == 8 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 9
        if (niveauEnCours == 9 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        //----------------Niveau 10 et plus 
        if (niveauEnCours >= 10 && peutCoroutine)
        {
            minuteurRound = 10f;
            StartCoroutine(GererTourDuree(10f));
        }

        /*-------------------------------------------------*/
        if (peutReduireUIMinuteur)
        {
            GestionUIMinuteur();
        }

        /*-------------------------------------------------*/
        GestionTempsPartie();
    }

    IEnumerator GererTourDuree(float pausePromenade)
 
    {
        // *******************************************************************************Tour Essaie --------
        //Appel de la fonction pour le changement de couleur
        print("C'est le niveau " + niveauEnCours);
        while (repetitionRound != 0)
        {
            minuteur = minuteurRound; //On assigne la valeur du temps pour le minuteur par rapport au niveau en cours
            peutCoroutine = false;
            barreMinuteurIMG.GetComponent<Animator>().enabled = true;
            barreMinuteurIMG.fillAmount = 1f;
            barreMinuteurIMG.color = indiceBleu;

            foreach (GameObject laPlateforme in lesPlateformes)
            {
                laPlateforme.GetComponent<GestionPlatformeIndividuelle>().ChangerCouleurPlateforme();
            }
            // Une pause est marquée
            yield return new WaitForSeconds(pausePromenade);

            //On appelle la fonction qui change la couleur de plateforme à atteindre
            GetComponent<ControleEliminationPlateforme>().ChangerCouleurObjectif();

            //On démarre le minuteur
            InvokeRepeating("GestionMinuteur", 1f, 1f);

            yield return new WaitForSeconds(minuteur);

            //Si le minuteur atteint 0, alors on peut poursuivre la suite du script
            if (minuteur <= 0)
            {
                foreach (GameObject laPlateforme in lesPlateformes)
                {
                    laPlateforme.GetComponent<GestionPlatformeIndividuelle>().EliminationPlateforme();
                }

                // Une pause est marquée
                yield return new WaitForSeconds(5.5f);

                //les plateformes réapparaissent
                foreach (GameObject laPlateforme in lesPlateformes)
                {
                    laPlateforme.GetComponent<Renderer>().material = matBlanc;
                    laPlateforme.GetComponent<GestionPlatformeIndividuelle>().ApparitionPlateforme();
                }

                repetitionRound--;

                //La plateforme d'annonce devient blanche à nouveau
                GetComponent<Renderer>().material = GetComponent<ControleEliminationPlateforme>().blanc;

                yield return new WaitForSeconds(5);
                minuteur = minuteurRound;
                //peutProchainRound = true;
            }
        }

        /*****************************************************************************************/
        yield return new WaitForSeconds(2);
        niveauEnCours++;
        foreach (GameObject laPlateforme in lesPlateformes)
        {
            laPlateforme.GetComponent<GestionPlatformeIndividuelle>().choixCouleurRange++;
        }

        GetComponent<ControleEliminationPlateforme>().choixCouleurRange++;

        repetitionRound = 2;  //Assignation du nombre de séquence du prochain round
        peutCoroutine = true;

        
        // *******************************************************************************Tour 1---- 2 couleurs/15 secondes ---------


        // *******************************************************************************Tour 2---- 3 couleurs/15 secondes --------


        // *******************************************************************************Tour 3---- 4 couleurs/15 secondes ---------


        // *******************************************************************************Tour 4---- 5 couleurs/12 secondes ---------


        // *******************************************************************************Tour 5---- 6 couleurs/12 secondes ---------


        // *******************************************************************************Tour 6---- 7 couleurs/10 secondes ---------


        // *******************************************************************************Tour 7---- 8 couleurs/10 secondes ---------


        // *******************************************************************************Tour 8---- 9 couleurs/8 secondes ---------


        // *******************************************************************************Tour 9---- 10 couleurs/8 secondes ---------


        // *******************************************************************************Tour 10 ++ ---- 10 couleurs/ 6 secondes ---------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        //Le code se r�pete jusqu'� ce que le joueur perd la partie (in�vitable car trop dure)
        /*while (!kayaPersonnage.GetComponent<ControleKalya>().finPartie)
        {
            yield return new WaitForSeconds(10); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
        }

        SceneManager.LoadScene("SceneFinale");*/
    }

    void GestionMinuteur()
    {
        if(minuteur >= 0)
        {
            peutReduireUIMinuteur = true;
            texteMinuteur.text = minuteur.ToString();
            minuteur--; //Assignation du temps de jeu du prochain round
        }
        else
        {
            peutReduireUIMinuteur = false;
            CancelInvoke("GestionMinuteur"); //On annule l'appel de la fonction pour le minuteur
        }
    }

    void GestionUIMinuteur()                                                                    
    {
        barreMinuteurIMG.GetComponent<Animator>().enabled = false;


        barreMinuteurIMG.color = indiceVert;

        if (barreMinuteurIMG.fillAmount < 0.65f)
        {
            barreMinuteurIMG.color = indiceOrange;
        }

        if (barreMinuteurIMG.fillAmount < 0.35f)
        {
            barreMinuteurIMG.color = indiceRouge;
        }

        //GESTION DE L'IMAGE DE LA BARRE DU MINUTEUR / UI
        barreMinuteurIMG.fillAmount -= Time.deltaTime / minuteurRound;
    }

    void GestionTempsPartie()
    {
        tempsDePartieEnCours += Time.deltaTime;

        texteTempsPartieEnCours.text =  Mathf.Floor(tempsDePartieEnCours / 60).ToString("00") + ":" + Mathf.FloorToInt(tempsDePartieEnCours % 60).ToString("00");
    }
}
