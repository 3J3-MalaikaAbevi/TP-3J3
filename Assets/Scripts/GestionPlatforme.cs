using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPlatforme : MonoBehaviour
{
    public Material[] rangeCouleurPlatforme;  //Tableau de matériaux pour la couleur des plateformes
    int couleurChoisie;  //Variable pour déterminer la couleur choisie
    public int choixCouleurRange; //Variable pour définir la position maximale dans le tableau de materiaux duquel le choix peut se faire

    private void Update()
    {
        print(choixCouleurRange);
    }

    public void ChangerCouleurPlateforme(){
        //On choisit la couleur de la plateforme au hasard et on convertit en integer (int)
        //Important de convertir car sinon une valeur en float ne peut pas etre mis en tant qu'index 
        couleurChoisie = (int)Mathf.Round(Random.Range(1f, choixCouleurRange));
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleurChoisie];
    }
}
