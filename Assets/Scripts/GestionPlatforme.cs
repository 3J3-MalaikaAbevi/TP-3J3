using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPlatforme : MonoBehaviour
{
    public Material[] rangeCouleurPlatforme;  //Tableau de mat�riaux pour la couleur des plateformes
    int couleurChoisie;  //Variable pour d�terminer la couleur choisie
    public int choixCouleurRange; //Variable pour d�finir la position maximale dans le tableau de materiaux duquel le choix peut se faire

    public GameObject gestionnaireDeCouleurTour;

    private void Update()
    {
        //print(choixCouleurRange);
    }

    public void ChangerCouleurPlateforme(){
        //On choisit la couleur de la plateforme au hasard et on convertit en integer (int)
        //Important de convertir car sinon une valeur en float ne peut pas etre mis en tant qu'index 
        couleurChoisie = (int)Mathf.Round(Random.Range(1f, choixCouleurRange));
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleurChoisie];

        if(couleurChoisie != gestionnaireDeCouleurTour.GetComponent<GestionPlatforme>().couleurChoisie){
            GetComponent<Animator>().SetBool("disparaitre", true);
        }
    }

    
}
