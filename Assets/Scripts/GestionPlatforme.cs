using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class GestionPlatforme : MonoBehaviour
{
    Material[] rangeCouleurPlatforme;
    // Start is called before the first frame update
    void Start()
    {
        int couleurChoisie = Random.Range(-10, 10);
        ChangerCouleurPlatforme(couleurChoisie);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void ChangerCouleurPlatforme(couleur){
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleur];
    }
}
