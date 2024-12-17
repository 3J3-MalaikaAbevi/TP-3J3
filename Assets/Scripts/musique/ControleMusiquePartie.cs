/*  Fonctionnement et utilit� g�n�rale du script
    Gestion de la musique de la partie
    Par : Mala�ka Abevi
    Derni�re modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleMusiquePartie : MonoBehaviour
{
    // On fait jouer la musique selon l'�tape de mute d�ja d�finit (synchroniser le mute des deux gameObjects de musique)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !ControleMusique.MusiqueMute)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (ControleMusique.MusiqueMute)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
