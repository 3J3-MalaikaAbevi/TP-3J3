using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleMusique : MonoBehaviour
{
    public Image imageEtatMusique;   //Variable pour le bouton du controle de la musique 
    public Sprite imgAudioBtn;  //Variable img pour l'image du bouton en Play
    public Sprite imgMuteBtn;   //Variable img pour l'image du bouton en Pause

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            ChangerEtatMusique();
        }

        GameObject laMusique = GameObject.Find("Musique");
        if (laMusique.GetComponent<AudioSource>().isPlaying) 
        {
            imageEtatMusique.GetComponent<Image>().sprite = imgAudioBtn;
        }
        else
        {
            imageEtatMusique.GetComponent<Image>().sprite = imgMuteBtn;
        }
    }


    //Fonction pour faire jouer ou mettre sur mute la musique
    public void ChangerEtatMusique()
    {
        GameObject laMusique = GameObject.Find("Musique");
        if (laMusique.GetComponent<AudioSource>().isPlaying) 
        {
            laMusique.GetComponent<AudioSource>().Pause();
        }
        else
        {
            laMusique.GetComponent<AudioSource>().Play();
        }
        
    }
}
