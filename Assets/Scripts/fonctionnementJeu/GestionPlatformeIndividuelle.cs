/*  Fonctionnement et utilité générale du script
    Gestion du changement de couleur d'une plateforme
    Gestion des animations et fonctionnalités d'une plateforme
    Par : Malaïka Abevi
    Dernière modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPlatformeIndividuelle : MonoBehaviour
{
    public Material[] rangeCouleurPlatforme;  //Tableau de mat�riaux pour la couleur des plateformes
    int couleurChoisie;  //Variable pour d�terminer la couleur choisie
    public int choixCouleurRange; //Variable pour d�finir la position maximale dans le tableau de materiaux duquel le choix peut se faire

    public GameObject gestionnaireDeCouleurTour; //Référence au GameObject du gestionnaire de couleur/tour


    public void ChangerCouleurPlateforme(){
        //On choisit la couleur de la plateforme au hasard et on convertit en integer (int)
        //Important de convertir car sinon une valeur en float ne peut pas etre mis en tant qu'index 
        couleurChoisie = (int)Mathf.Round(Random.Range(1f, choixCouleurRange));
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleurChoisie];
    }

    //Fonction pour éliminer les plateforme qui n'ont pas la bonne couleur
    public void EliminationPlateforme()
    {
        if (couleurChoisie != gestionnaireDeCouleurTour.GetComponent<ControleEliminationPlateforme>().couleurChoisie)
        {
            GetComponent<Animator>().SetBool("disparaitre", true);
        }
    }

    //Fonction pour faire réapparaitre les plateformes
    public void ApparitionPlateforme()
    {
        if (GetComponent<Animator>().GetBool("disparaitre"))
        {
            GetComponent<Animator>().SetBool("disparaitre", false);
        }
    }
}
