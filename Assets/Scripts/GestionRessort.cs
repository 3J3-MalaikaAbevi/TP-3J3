using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRessort : MonoBehaviour
{
    public float forcePropulsion; //Variable pour enregistrer la valeur de la force a donné au personnage vers le haut

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
        if(infoCollision.gameObject.name == "Kaya_perso")
        {
            infoCollision.gameObject.GetComponent<ControleKaya>().velocitePersoY = forcePropulsion;
        }    
    }
}
