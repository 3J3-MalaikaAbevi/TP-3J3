using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPlatforme : MonoBehaviour
{

    
   public Material[] rangeCouleurPlatforme;
    int couleurChoisie;
    // Start is called before the first frame update
    void Start()
    {
        couleurChoisie = Random.Range(0, 8);
        ChangerCouleurPlatforme(couleurChoisie);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangerCouleurPlatforme(int couleur){
        GetComponent<Renderer>().material = rangeCouleurPlatforme[couleur];
    }
}
