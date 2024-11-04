/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fluide (avec un amortissement du mouvement) 
    de Kaya en Third Person Perspective
   Par : Mala�ka Abevi
   Derni�re modification : 29/10/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSuiviFluide : MonoBehaviour
{
    public GameObject Cible;
    Vector3 Distance;
    public Vector3 AjustementFocus;

    public Vector3 distanceCamProche;
    public Vector3 distanceCamEloigne;

    public float Amortissement;
    void Start()
    {
        // Par d�faut, la cam�ra est proche du joueur
        //Appel de la fonction pour le changement de distance de la caméra
        ChangementCam(distanceCamProche);
    }

    void Update()
    {
        //Changement de la distance de la cam�ra si la touche 1 est appuy�e (rapprochement)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Start();
        }

        //Changement de la distance de la cam�ra si la touche 2 est appuy�e (�loignement)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Appel de la fonction pour le changement de distance de la caméra
            ChangementCam(distanceCamEloigne);
        }

        
    }

    void FixedUpdate()
    {

        Vector3 PositionFinale = Cible.transform.TransformPoint(Distance);
        transform.position = Vector3.Lerp(transform.position, PositionFinale, Amortissement);
        transform.LookAt(Cible.transform.position + AjustementFocus);
    }

    //Fontion pour le changement de distance de la caméra, un vector3 est demandé pour avoir un point d'arrivé désiré
    void ChangementCam(Vector3 unDistanceCam){
        //Tant que la caméra n'a pas atteint la distance désirée par rapport au personnage, le rapprochement/éloignement s'éffectue
        while(Distance != unDistanceCam){
            Distance =  Vector3.Lerp(Distance, unDistanceCam, Amortissement); //Possiblement mettre dans une fonction !
        }
    }
}
