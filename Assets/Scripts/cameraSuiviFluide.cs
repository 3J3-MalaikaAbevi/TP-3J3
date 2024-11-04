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
    Vector3 Distance;
    public Vector3 AjustementFocus;

    public Vector3 distanceCamProche;
    public Vector3 distanceCamEloigne;

    public float Amortissement;
    void Start()
    {
        // Par défaut, la caméra est proche du joueur
        // Distance = Vector3.Lerp(Distance, distanceCamProche, Amortissement);
        Distance = ChangementCam(distanceCamProche);
    }

    void Update()
    {
        //Changement de la distance de la caméra si la touche 1 est appuyée (rapprochement)
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Start();
        }

        //Changement de la distance de la caméra si la touche 2 est appuyée (éloignement)
        if (Input.GetKey(KeyCode.Alpha2))
        {
            
            Distance = ChangementCam(distanceCamEloigne);
        }

        
    }

    void FixedUpdate()
    {

        Vector3 PositionFinale = Cible.transform.TransformPoint(Distance);
        transform.position = Vector3.Lerp(transform.position, PositionFinale, Amortissement);


        transform.LookAt(Cible.transform.position + AjustementFocus);
        print(Distance);
    }

    Vector3 ChangementCam(Vector3 uneCam)
    {
        Vector3 laDistanceCam = Vector3.Lerp(Distance, uneCam, Amortissement);
        return laDistanceCam;
    }
}
