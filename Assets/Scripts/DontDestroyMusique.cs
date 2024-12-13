/*  Fonctionnement et utilit� g�n�rale du script
    Controle et gestion du personnage Kaya
    Par : Mala�ka Abevi
    Derni�re modification : 24/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusique : MonoBehaviour
{
    public GameObject musique;   //GameObject d'origine pour la musique
    static bool dontDestroyDejaFait;

    void Start()
    {
        if (dontDestroyDejaFait == false)  //la 1e fois qu'on fait le DontDestroy
        {
            DontDestroyOnLoad(musique);
            dontDestroyDejaFait = true;
        }
        else  //c'est d�j� fait alors efface le doublon
        {
            Destroy(musique);
        }
    }
}
