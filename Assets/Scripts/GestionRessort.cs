using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRessort : MonoBehaviour
{
    public float forcePropulsion; //Variable pour enregistrer la valeur de la force a donn� au personnage vers le haut

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        print("pas kaya tho");
        if(infoCollision.gameObject.name == "Kaya_perso")
        {
            print("Ya un contact");
            infoCollision.gameObject.GetComponent<ControleKaya>().velocitePersoY = forcePropulsion;
        }    
    }
}