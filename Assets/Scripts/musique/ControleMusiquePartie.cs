/*  Fonctionnement et utilité générale du script
    Gestion de la musique de la partie
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleMusiquePartie : MonoBehaviour
{
    // On fait jouer la musique selon l'étape de mute déja définit (synchroniser le mute des deux gameObjects de musique)
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
