/*  Fonctionnement et utilité générale du script
    Gestion de la musique
    Par : Malaïka Abevi
    Dernière modification : 13/12/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleMusique : MonoBehaviour
{
    public GameObject musique; //Variable pour l'object de base à l'intro
    public Image imageEtatMusique;   //Variable pour le bouton du controle de la musique 
    public Sprite imgAudioBtn;   //Variable img pour l'image du bouton en Play
    public Sprite imgMuteBtn;   //Variable img pour l'image du bouton en Pause

    public static bool MusiqueMute;   //On sauvegarde l'état de la musique, utile dans un autre script (ControleMusiquePartie)

    void Update()
    {
        //On change l'état de la musique en appelant une fonction qui s'en occupe
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            ChangerEtatMusique();
        }

        //On change l'état du UI de l'état de musique
        if (musique.GetComponent<AudioSource>().isPlaying)
        {
            imageEtatMusique.GetComponent<Image>().sprite = imgAudioBtn;
        }
        else
        {
            imageEtatMusique.GetComponent<Image>().sprite = imgMuteBtn;
        }

        //Pour ne pas avoir deux musique qui joue en meme temps, on met le volume du la 
        //musique de base (DontDestroyOnLoad) à 0 dans la scène de partie uniquement
        if(GestionScene.sceneActuelle.name == "scenePartie")
        {
            musique.GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            musique.GetComponent<AudioSource>().volume = 1f;
        }
    }

    //Fonction pour faire jouer ou mettre sur mute la musique
    public void ChangerEtatMusique()
    {
        if (musique.GetComponent<AudioSource>().isPlaying)
        {
            musique.GetComponent<AudioSource>().Pause();
            MusiqueMute = true;
        }
        else
        {
            musique.GetComponent<AudioSource>().Play();
            MusiqueMute = false;
        }
    }
}
