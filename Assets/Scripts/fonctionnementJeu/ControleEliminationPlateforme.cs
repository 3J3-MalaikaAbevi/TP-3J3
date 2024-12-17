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
    public TextMeshProUGUI texteCouleurChoisie;   //Variable texte pour indiquer la couleur de plateforme à atteindre (UI)
    public Image couleurIMG; //Variable pour le carré du UI qui indique la couleur à atteindre

    public Color[] indiceCouleurUI;   //Couleur pour l'indice

    //Fonction pour changer la couleur de l'objectif
    public void ChangerCouleurObjectif(){
        //On choisit la couleur de la plateforme au hasard et on convertit en integer (int)
        //Important de convertir car sinon une valeur en float ne peut pas etre mis en tant qu'index 
        couleurChoisie = (int)Mathf.Round(Random.Range(1f, choixCouleurRange));
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleurChoisie];
        texteCouleurChoisie.GetComponent<Animator>().SetTrigger("peutAnnoncer");

        /*Gestion de l'affichage de la couleur en texte pour informer le joueur*/
        if (couleurChoisie == 0)
        {
            texteCouleurChoisie.text = "Blanc";
            texteCouleurChoisie.color = indiceCouleurUI[0];
            couleurIMG.color = indiceCouleurUI[0];
        }

        if (couleurChoisie == 1)
        {
            texteCouleurChoisie.text = "Rose";
            texteCouleurChoisie.color = indiceCouleurUI[1];
            couleurIMG.color = indiceCouleurUI[1];
        }

        if (couleurChoisie == 2)
        {
            texteCouleurChoisie.text = "Jaune";
            texteCouleurChoisie.color = indiceCouleurUI[2];
            couleurIMG.color = indiceCouleurUI[2];
        }

        if (couleurChoisie == 3)
        {
            texteCouleurChoisie.text = "Bleu";
            texteCouleurChoisie.color = indiceCouleurUI[3];
            couleurIMG.color = indiceCouleurUI[3];
        }

        if (couleurChoisie == 4)
        {
            texteCouleurChoisie.text = "Orange";
            texteCouleurChoisie.color = indiceCouleurUI[4];
            couleurIMG.color = indiceCouleurUI[4];
        }

        if (couleurChoisie == 5)
        {
            texteCouleurChoisie.text = "Rouge";
            texteCouleurChoisie.color = indiceCouleurUI[5];
            couleurIMG.color = indiceCouleurUI[5];
        }

        if (couleurChoisie == 6)
        {
            texteCouleurChoisie.text = "Vert";
            texteCouleurChoisie.color = indiceCouleurUI[6];
            couleurIMG.color = indiceCouleurUI[6];
        }

        if (couleurChoisie == 7)
        {
            texteCouleurChoisie.text = "Violet";
            texteCouleurChoisie.color = indiceCouleurUI[7];
            couleurIMG.color = indiceCouleurUI[7];
        }

        if (couleurChoisie == 8)
        {
            texteCouleurChoisie.text = "Turquoise";
            texteCouleurChoisie.color = indiceCouleurUI[8];
            couleurIMG.color = indiceCouleurUI[8];
        }

        if (couleurChoisie == 9)
        {
            texteCouleurChoisie.text = "Fuschia";
            texteCouleurChoisie.color = indiceCouleurUI[9];
            couleurIMG.color = indiceCouleurUI[9];
        }

        /*--------------------------------------------*/
        if (couleurChoisie == 10)
        {
            texteCouleurChoisie.text = "Noir";
            couleurIMG.color = indiceCouleurUI[10];
        }
    }


}
