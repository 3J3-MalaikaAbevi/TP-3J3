/*  Fonctionnement et utilité générale du script
    Gestion de l'annoncement de la couleur à atteidre
    Gestion du UI pour l'annoncement de la couleur à atteidre   
    Gestion des disparitions et apparition des plateforme du terrain de jeu
    Par : Malaïka Abevi
    Dernière modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ControleEliminationPlateforme : MonoBehaviour
{
    public Material blanc; //Variable pour la couleur de base de l'annonceur
    public Material[] rangeCouleurPlatforme;  //Tableau de mat�riaux pour la couleur des plateformes
    public int couleurChoisie;  //Variable pour d�terminer la couleur choisie
    public int choixCouleurRange; //Variable pour d�finir la position maximale dans le tableau de materiaux duquel le choix peut se faire
    public TextMeshProUGUI texteCouleurChoisie;    //Variable texte pour indiquer la couleur de plateforme à atteindre (UI)

    public void ChangerCouleurObjectif(){
        //On choisit la couleur de la plateforme au hasard et on convertit en integer (int)
        //Important de convertir car sinon une valeur en float ne peut pas etre mis en tant qu'index 
        couleurChoisie = (int)Mathf.Round(Random.Range(1f, choixCouleurRange));
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleurChoisie];

        /*Gestion de l'affichage de la couleur en texte pour informer le joueur*/
        if(couleurChoisie == 0)
        {
            texteCouleurChoisie.text = "Blanc";   
        }

        if (couleurChoisie == 1)
        {
            texteCouleurChoisie.text = "Rose";
        }

        if (couleurChoisie == 2)
        {
            texteCouleurChoisie.text = "Jaune";
        }

        if (couleurChoisie == 3)
        {
            texteCouleurChoisie.text = "Bleu";
        }

        if (couleurChoisie == 4)
        {
            texteCouleurChoisie.text = "Orange";
        }

        if (couleurChoisie == 5)
        {
            texteCouleurChoisie.text = "Rouge";
        }

        if (couleurChoisie == 6)
        {
            texteCouleurChoisie.text = "Vert";
        }

        if (couleurChoisie == 7)
        {
            texteCouleurChoisie.text = "Violet";
        }

        if (couleurChoisie == 8)
        {
            texteCouleurChoisie.text = "Turquoise";
        }

        if (couleurChoisie == 9)
        {
            texteCouleurChoisie.text = "Fuschia";
        }

        if (couleurChoisie == 10)
        {
            texteCouleurChoisie.text = "Jaune";
        }
    }


}
