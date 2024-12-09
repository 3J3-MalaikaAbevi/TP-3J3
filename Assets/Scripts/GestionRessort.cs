using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRessort : MonoBehaviour
{
    public float forcePropulsion; //Variable pour enregistrer la valeur de la force a donné au personnage vers le haut

    void OnCollisionEnter(Collision infoCollision)
    {
        if(infoCollision.gameObject.name == "Kaya_perso")
        {
            infoCollision.gameObject.GetComponent<ControleKaya>().velocitePersoY = forcePropulsion;
            this.transform.parent.gameObject.GetComponent<Animator>().SetBool("disparition", true);
            Invoke("ApparitionRessort", 15f);
        }    
    }

    void ApparitionRessort()
    {
         this.transform.parent.gameObject.GetComponent<Animator>().SetBool("disparition", false);
    }
}
