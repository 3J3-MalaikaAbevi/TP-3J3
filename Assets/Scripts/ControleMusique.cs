using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleMusique : MonoBehaviour
{
    public Image imageEtatMusique;   //Variable pour le bouton du controle de la musique 
    public Sprite imgAudioBtn;  //Variable img pour l'image du bouton en Play
    public Sprite imgMuteBtn;   //Variable img pour l'image du bouton en Pause

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            ChangerEtatMusique();
        }
    }


    //Fonction pour faire jouer ou mettre sur mute la musique
    public void ChangerEtatMusique()
    {
        if (GetComponent<AudioSource>().isPlaying) {

            imageEtatMusique.GetComponent<Image>().sprite = imgMuteBtn;
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            imageEtatMusique.GetComponent<Image>().sprite = imgAudioBtn;
            GetComponent<AudioSource>().Play();
        }
        
    }
}
