using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionTourPlateforme : MonoBehaviour
{
    public float minuteurRound; //Minuteur pour le temps alou� pour aller � une bonne plateforme (Round)
    int repetitionRound; //Variable pour le nombre de fois que la sequence d'un round s'execute
    public GameObject kayaPersonnage;

    void Start()
    {
        StartCoroutine(GererTourDuree());
    }

    IEnumerator GererTourDuree()
 
    {
        minuteurRound = 10f;
        // Tour Essaie ---------------------------------------------------------------------
        yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
        GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur

        minuteurRound = 10f; //Assignation du temps de jeu du prochain round
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round


        // Tour 1---- 2 couleurs/15 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 10f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;


        // Tour 2---- 3 couleurs/15 secondes ----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 10f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 3---- 4 couleurs/15 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 10f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 4---- 5 couleurs/12 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 8f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 5---- 6 couleurs/12 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 8f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 6---- 7 couleurs/10 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 8f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 7---- 8 couleurs/10 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 6f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 8---- 9 couleurs/8 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            repetitionRound--;
        }

        minuteurRound = 6f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 9---- 10 couleurs/8 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        while (repetitionRound != 0)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            Invoke("DisparitionPlateforme", 1f);
            yield return new WaitForSeconds(3); //Petite attente ap
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
            
            repetitionRound--;
        }

        minuteurRound = 5f;
        repetitionRound = 2;  //Assignation du nombre de s�quence du prochain round
        GetComponent<GestionPlatforme>().choixCouleurRange += 1;
        yield return new WaitForSeconds(5); // Transition entre les rounds

        // Tour 10 ++ ---- 10 couleurs/ 6 secondes -----------------------------------------------------------------------
        //Tant que la r�petition n'est pas � z�ro, alors ce code s'execute
        //Le code se r�pete jusqu'� ce que le joueur perd la partie (in�vitable car trop dure)
        while (!kayaPersonnage.GetComponent<ControleKalya>().finPartie)
        {
            yield return new WaitForSeconds(minuteurRound); // Une pause est marqu�e
            GetComponent<GestionPlatforme>().ChangerCouleurPlateforme(); //Appel de la fonction pour le changement de couleur
        }

        SceneManager.LoadScene("SceneFinale");
    }
}
