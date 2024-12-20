/*  Fonctionnement et utilité générale du script
    Gestion du déroulement global de la partie
    (niveau, round, minuteur, temps écoulé, etc)
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
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
    int repetitionRound = 2; //Variable pour le nombre de fois que la séquence d'un round s'execute
    int niveauEnCours = 1;  //Variable pour l'enregistrement du niveau atteint
    public static int tourEnCours = 0;  //Variable statique pour enregistrer le nombre de tour fait
    public static float tempsDePartieEnCours;   //Variable statique pour enregistrer temps de la partie

    public GameObject kayaPersonnage;   //Réference à Kaya (personnage)
    public GameObject[] lesPlateformes;   //Tableau de gameObjects pour la gestion de chaque plateforme
    public GameObject[] lesPiquesMouvants;  //Tableau de gameObjects pour les piques Mouvants
    
    bool peutCoroutine = true;     //Variable pour savoir si on peut démarrer une nouvelle coroutine ou non
    bool peutReduireUIMinuteur; //Variable pour savoir si la barre du minuteur peut réduire

    public TextMeshProUGUI texteMinuteur;     //Variable Texte pour le minuteur (UI)
    public TextMeshProUGUI texteTempsPartieEnCours;     //Variable Texte pour le minuteur (UI)
    public TextMeshProUGUI texteAnnonceTour; //Texte qui affiche le tour en cours
    public TextMeshProUGUI texteAnnonceCouleur; //Texte qui annonce la couleur de plateforme a atteindre
    public TextMeshProUGUI texteFinPartie;    //Texte pour le message de fin de partie

    public Image barreMinuteurIMG; //Variable pour la barre de progression du minuteur (UI)
    public Image couleurIMG; //Cadre de la minuterie
    public Image fondFinPartie;   //Le fond noir pour la fin de partie

    //Ce sont les quatres couleurs utilisées pour la barre de temps
    public Color indiceBleu;
    public Color indiceRouge;
    public Color indiceVert;
    public Color indiceOrange;

    public Material matBlanc;   //Materiel de base pour les plateformes

    public int nbActivationPiques;    //index du poteaux piquants à activer
    public int nbActivationSolPiquant = 20;   //Le nombre de sols piquants à activer

    void Update()
    {
        if (!ControleKaya.finPartie)
        {
            //----------------Niveau 1
            if (niveauEnCours == 1 && peutCoroutine)
            {
                minuteurRound = 5f;
                nbActivationSolPiquant = 20;
                StartCoroutine(GererTourDuree(5f));
            }

            //----------------Niveau 2
            if (niveauEnCours == 2 && peutCoroutine)
            {
                minuteurRound = 5f;
                nbActivationSolPiquant = 4;
                nbActivationPiques = 1;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 3
            if (niveauEnCours == 3 && peutCoroutine)
            {
                minuteurRound = 4f;              
                nbActivationSolPiquant = 4;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 4
            if (niveauEnCours == 4 && peutCoroutine)
            {
                minuteurRound = 4f;
                nbActivationPiques = 2;
                nbActivationSolPiquant = 3;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 5
            if (niveauEnCours == 5 && peutCoroutine)
            {
                minuteurRound = 3f;
                nbActivationSolPiquant = 3;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 6
            if (niveauEnCours == 6 && peutCoroutine)
            {
                minuteurRound = 3f;
                nbActivationPiques = 3;
                nbActivationSolPiquant = 3;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 7
            if (niveauEnCours == 7 && peutCoroutine)
            {
                minuteurRound = 3f;
                nbActivationPiques = 4;
                nbActivationSolPiquant = 2;
                StartCoroutine(GererTourDuree(3f));
            }

            //----------------Niveau 8
            if (niveauEnCours == 8 && peutCoroutine)
            {
                minuteurRound = 3f;
                nbActivationPiques = 5;
                nbActivationSolPiquant = 2;
                StartCoroutine(GererTourDuree(2f));
            }

            //----------------Niveau 9
            if (niveauEnCours == 9 && peutCoroutine)
            {
                minuteurRound = 2f;
                nbActivationPiques = 6;
                nbActivationSolPiquant = 2;
                StartCoroutine(GererTourDuree(2f));
            }

            //----------------Niveau 10 et plus 
            if (niveauEnCours >= 10 && peutCoroutine)
            {
                minuteurRound = 2f;
                nbActivationPiques = 8;
                nbActivationSolPiquant = 2;
                StartCoroutine(GererTourDuree(2f));
            }

            /*-------------------------------------------------*/
            GestionObstacles();

            /*-------------------------------------------------*/
            if (peutReduireUIMinuteur)
            {
                GestionUIMinuteur();
            }

            /*-------------------------------------------------*/
            GestionTempsPartie();
        }
        else
        {
            StopAllCoroutines(); //On arrête toutes les coroutines en cours
            // Et c'est la fin de la partie
            texteFinPartie.gameObject.SetActive(true);
            fondFinPartie.gameObject.SetActive(true);  
        }
    }

    //Fonction qui s'occupe de faire jouer le jeu
    IEnumerator GererTourDuree(float pausePromenade)
 
    {
        // *******************************************************************************Tour Essaie --------
        //Appel de la fonction pour le changement de couleur
        //print("C'est le niveau " + niveauEnCours);
        while (repetitionRound != 0)
        {
            tourEnCours++; //On augmente le numero du tour en cours
            texteAnnonceTour.text = "Tour " + tourEnCours;
            texteAnnonceCouleur.text = "";
            texteMinuteur.text = "?";
            couleurIMG.GetComponent<Animator>().enabled = true;

            minuteur = minuteurRound; //On assigne la valeur du temps pour le minuteur par rapport au niveau en cours
            peutCoroutine = false;
            barreMinuteurIMG.GetComponent<Animator>().enabled = true;
            barreMinuteurIMG.fillAmount = 1f;
            barreMinuteurIMG.color = indiceBleu;

            GetComponent<TransformationObstacle>().ChoixApparition(nbActivationSolPiquant);

            foreach (GameObject laPlateforme in lesPlateformes)
            {
                laPlateforme.GetComponent<GestionPlatformeIndividuelle>().ChangerCouleurPlateforme();
            }
            // Une pause est marquée
            yield return new WaitForSeconds(pausePromenade);

            //On appelle la fonction qui change la couleur de plateforme à atteindre
            couleurIMG.GetComponent<Animator>().enabled = false;
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
        if (niveauEnCours < 10)
        {
            niveauEnCours++; //On augemente le niveau si on n'est pas encore au niveau infini 10
            foreach (GameObject laPlateforme in lesPlateformes)
            {
                laPlateforme.GetComponent<GestionPlatformeIndividuelle>().choixCouleurRange++;   //On indique aux plateforme qu'elle peuvent prendre une toute nouvelle couleur
            }

            GetComponent<ControleEliminationPlateforme>().choixCouleurRange++; //On augmente les choix de couleurs de
            repetitionRound = 2;  //Assignation du nombre de séquence du prochain round
        }
        else
        {
            repetitionRound = 10000; //Pour le niveau 10, Assignation d'une valeur de tour permis que je pense personne atteindra...
        }

        peutCoroutine = true;   //Puis on indique qu'une nouvelle coroutine peut etre démarré
    }

    //Fonctions pour a gestion des obstacles
    void GestionObstacles()
    {
        //On veut activer les piques du tableau selon le nombre voulu
        for (int i = 0; i < nbActivationPiques; i++)
        {
            //Activation des piques selon l'index

            lesPiquesMouvants[i].gameObject.SetActive(true);
        }
    }

    //Fonction pour le fonctionnement du minuteur 
    void GestionMinuteur()
    {
        if(minuteur > 0)
        {
            peutReduireUIMinuteur = true;
            minuteur--; //Assignation du temps de jeu du prochain round
            texteMinuteur.text = minuteur.ToString();
        }
        else
        {
            peutReduireUIMinuteur = false;
            CancelInvoke("GestionMinuteur"); //On annule l'appel de la fonction pour le minuteur
        }
    }

    //Fonction pour la gestion du UI du minuteur 
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

    //Fonction pour la gestion du temps de la partie
    void GestionTempsPartie()
    {
        tempsDePartieEnCours += Time.deltaTime;

        texteTempsPartieEnCours.text =  Mathf.Floor(tempsDePartieEnCours / 60).ToString("00") + ":" + Mathf.FloorToInt(tempsDePartieEnCours % 60).ToString("00");
    }
}
