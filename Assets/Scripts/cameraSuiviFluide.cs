/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fluide (avec un amortissement du mouvement) 
    de Kaya en Third Person Perspective
   Par : Mala�ka Abevi
   Derni�re modification : 04/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSuiviFluide : MonoBehaviour
{
    public GameObject Cible;    //Réference à Kaya, qui est la cible de la caméra
    Vector3 Distance;   //Vector3 pour la distance actuelle de la camera par rapport à Kaya
    public Vector3 AjustementFocus;

    public Vector3 distanceCamProche;   //Vector3 pour la distance souhaitée en caméra proche
    public Vector3 distanceCamEloigne;   //Vector3 pour la distance souhaitée en caméra éloignée

    public float Amortissement;   //Valeur pour le facteur d'ammortissement de la caméra (transition entre d'un Vector3 à un autre)
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
        //On assigne une position souhaité pour la camera avec un effet d'amortissement 
        Vector3 PositionFinale = Cible.transform.TransformPoint(Distance);  
        transform.position = Vector3.Lerp(transform.position, PositionFinale, Amortissement);
        transform.LookAt(Cible.transform.position + AjustementFocus);
    }

    //Fonction pour le changement de distance de la caméra, un vector3 est demandé pour avoir un point d'arrivé désiré
    void ChangementCam(Vector3 unDistanceCam){
        //Tant que la caméra n'a pas atteint la distance désirée par rapport au personnage, le rapprochement/éloignement s'éffectue
        while(Distance != unDistanceCam){
            // Pour avoir un effet de rapprochement/éloignement smooth, on change la distance avec un Lerp
            Distance =  Vector3.Lerp(Distance, unDistanceCam, Amortissement);
        }
    }
}
