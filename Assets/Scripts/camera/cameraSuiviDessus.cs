/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi du dessus (avec un amortissement du mouvement) 
    de Kaya en Third Person Perspective
   Par : Mala�ka Abevi
   Derni�re modification : 24/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSuiviDessus : MonoBehaviour
{
    public GameObject Cible;    //Réference à Kaya, qui est la cible de la caméra
    Vector3 Distance;   //Vector3 pour la distance actuelle de la camera par rapport à Kaya
    public Vector3 AjustementFocus;

    public float Amortissement;   //Valeur pour le facteur d'ammortissement de la caméra (transition entre d'un Vector3 à un autre)

    void FixedUpdate()
    {
        //On assigne une position souhaité pour la camera avec un effet d'amortissement 
        Vector3 PositionFinale = Cible.transform.TransformPoint(Distance);  
        transform.position = Vector3.Lerp(transform.position, PositionFinale, Amortissement);
        transform.LookAt(Cible.transform.position + AjustementFocus);
    }
}
