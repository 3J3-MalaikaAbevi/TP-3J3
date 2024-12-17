/*  Fonctionnement et utilité générale du script
    Gestion des ressorts et de la propulsion
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRessort : MonoBehaviour
{
    public float forcePropulsion; //Variable pour enregistrer la valeur de la force a donné au personnage vers le haut
    public AudioClip sonRessort;  //Son pour le ressort

    void OnCollisionEnter(Collision infoCollision)
    {
        if(infoCollision.gameObject.name == "Kaya_perso")
        {
            //On propulse Kaya
            infoCollision.gameObject.GetComponent<ControleKaya>().velocitePersoY = forcePropulsion;
            //On fait disparaitre le ressort 
            this.transform.parent.gameObject.GetComponent<Animator>().SetBool("disparition", true);
            //On invoque la fonction qui va faire reapparaitre le ressort apres un delai 
            Invoke("ApparitionRessort", 15f);
            //On fait jouer le son du ressort 
            gameObject.GetComponent<AudioSource>().PlayOneShot(sonRessort);
            // Et on active son animation de saut
            infoCollision.gameObject.GetComponent<Animator>().SetTrigger("saut");
        }    
    }

    // Fonction pour l'apparition du ressort
    void ApparitionRessort()
    {
         this.transform.parent.gameObject.GetComponent<Animator>().SetBool("disparition", false);
    }
}
