/*  Fonctionnement et utilité générale du script
    Controle et gestion du personnage Kaya
    Par : Malaïka Abevi
    Dernière modification : 06/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleKaya : MonoBehaviour
{
    public float vitesse;// vitesse de déplacement
    public float vitesseTourne; // vitesse de rotation
    CharacterController controleur; // référence au component characterController
    public AudioClip sonDefaite;   //Audioclip pour le son de défaite du joueur (effet)

    public float forceDuSaut; // hauteur du saut
    public float gravite; // force de la gravité

    float velocitePersoY;  //Variable pour la vélocité du joueur en hauteur (saut)

    bool toucheSaut;   //Variable pour savoir si le joueur a sauter ou non
    bool finPartie;     //Variable pour savoir si la partie est finie ou non 
    public bool auSol;    //Variable pour savoir si le joueur est au sol ou non
    public bool avecAnimationPerso;    //Variable pour savoir si le joueur a des animations à éxecuter

    void Start()
    {
        // Permet de verrouiller le curseur et de le masquer
        Cursor.lockState = CursorLockMode.Locked;
        // On garde dans une variable la référence au component CharacterController
        controleur = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toucheSaut = true;
        }
    }

    // Gestion du déplacement du CharacterController avec Move qui permet le saut.
    void FixedUpdate()
    {
        if (!finPartie)
        {
            // on mémorise la valeur des axes Horizontal et Vertical. On pourrait utiliser GetAxisRaw aussi.
            float deplaceX = Input.GetAxisRaw("Horizontal");
            float deplaceZ = Input.GetAxisRaw("Vertical");

            // transform.TransformDirection permet de transformer une direction locale en direction du monde (local space to world space)
            // On calcul le vecteur de déplacement en utilisant la direction qu'on mutiplie par la vitesse;
            Vector3 deplacement = transform.TransformDirection(new Vector3(deplaceX, 0f, deplaceZ) * vitesse);



            // Permet de savoir si le characterController touche au sol
            auSol = controleur.isGrounded;

            // On remet la velocitePersoY à 0 si le personnage est au sol et que la velocitePerso est
            // plus petite que zéro.
            if (auSol && velocitePersoY < 0) velocitePersoY = 0f;

            // On permet le saut seulement si le characterController est au sol (avec la touche espace)
            if (toucheSaut && auSol)
            {
                velocitePersoY = forceDuSaut; // On ajuste la variable velociteYPerso à la force du saut.
                toucheSaut = false;
                GetComponent<Animator>().SetTrigger("saut"); //On active le trigger pour l'animation du saut 

                if (auSol)
                {
                    GetComponent<Animator>().SetTrigger("atterrissage");
                }
            }

            velocitePersoY += gravite * Time.deltaTime; // On applique la gravité à la variable velocitePersoY (soustraction d'une valeur à velocityPerso



            // On ajuste la valeur Y de notre variable de déplacement
            deplacement.y = velocitePersoY;

            // On applique le déplacement. Multiplié par Time.deltaTime pour éviter la variation du frameRate
            controleur.Move(deplacement * Time.deltaTime);

            // On fait tourner le personnage en fonction du déplacement horizontal de la souris
            float tourne = Input.GetAxis("Mouse X") * vitesseTourne * Time.deltaTime;
            transform.Rotate(0f, tourne, 0f);

            if (avecAnimationPerso) GestionAnim(deplacement);
            TournePersonnage();
        }
        else
        {
            //Après un court délai, on appelle la fonction pour le redémmarage de la partie
            Invoke("RecommencerPartie", 10f);
        }
    }

    //Fonction pour faire tourner dans une direction Kaya avec la souris
    void TournePersonnage()
    {
        /*crée un rayon à partir de la caméra vers l’avant à la position de la souris. Le rayon est mémorisé dans la variable
         * locale camRay (variable de type Ray)*/
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // variable locale infoCollision : contiendra les infos retournées par le Raycast sur l’objet touché 
        RaycastHit infoCollision;

        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 5000, LayerMask.GetMask("zoneTerrain")))
        {
            // si le rayon frappe le plancher...
            // le personnage regarde vers le point de contact (là ou le rayon à touché le plancher)
            transform.LookAt(infoCollision.point);

            /* Ici, on s'assure que le personnage tourne seulement sur son Axe Y en mettant ses rotations X et Z à 0. Pour changer
             * ces valeurs par programmation, il faut changer la propriété localEuleurAngles.*/
            Vector3 rotationActuelle = transform.localEulerAngles;
            rotationActuelle.x = 0f;
            rotationActuelle.z = 0f;
            transform.localEulerAngles = rotationActuelle;
        }
        //outil de déboggage pour visualiser le rayon dans l'onglet scene
        Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.yellow);
    }

    //Fonction pour la gestion des animations de Kaya
    void GestionAnim(Vector3 valeurDeplacement)
    {
        valeurDeplacement.y = 0f;
        if (!finPartie)
        {           
            bool marche = false;
            if (valeurDeplacement.magnitude > 1f && auSol) marche = true;
            GetComponent<Animator>().SetBool("marche", marche);
        }
        else
        {
            valeurDeplacement = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetBool("defaite", true);
            GetComponent<Animator>().SetBool("marche", false);
            GetComponent<AudioSource>().PlayOneShot(sonDefaite);
        }
    }

    //Fonction adaptée pour le CharacterController pour la gestion des collisions
    void OnControllerColliderHit(ControllerColliderHit infoHit)
    {
        if (infoHit.gameObject.tag == "piqueDanger")
        {
            finPartie = true;
            print("c'est la fin!");
        }
    }

    //Fonction pour detecter les collisions de type trigger
    void OnTriggerEnter(Collider infoTrigger)
    {
        //S'il y a une detection d'une collision Trigger avec le detecteur de chute du joueur, alors c'est la fin de la partie
        if(infoTrigger.gameObject.tag == "chuteFin")
        {
            finPartie = true;
            print("c'est la fin!");
        }   
    }


    //Fonction pour recommencer la partie
    void RecommencerPartie()
    {
        SceneManager.LoadScene("scenePartie");
    }

}

