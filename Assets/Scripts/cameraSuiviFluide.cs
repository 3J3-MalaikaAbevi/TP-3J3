/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi fluide (avec un amortissement du mouvement) 
    de Kaya en Third Person Perspective
   Par : Malaïka Abevi
   Dernière modification : 29/10/2024
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
