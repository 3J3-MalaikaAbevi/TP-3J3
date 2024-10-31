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
    public Vector3 Distance;

    public Vector3 AjustementFocus;
    public float Amortissement;
    void Start()
    {

    }

    void FixedUpdate()
    {

        Vector3 PositionFinale = Cible.transform.TransformPoint(Distance);
        transform.position = Vector3.Lerp(transform.position, PositionFinale, Amortissement);


        transform.LookAt(Cible.transform.position + AjustementFocus);
    }
}
