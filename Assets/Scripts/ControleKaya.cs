/*  Fonctionnement et utilité générale du script
    Controle et gestion du personnage Kaya
    Par : Malaïka Abevi
    Dernière modification : 24/11/2024
*/
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleKaya : MonoBehaviour
{
    public float vitesse;// vitesse de déplacement
    public float vitesseTourne; // vitesse de rotation
    Rigidbody rigidbodyPerso; // référence au component characterController
    public AudioClip sonDefaite;   //Audioclip pour le son de défaite du joueur (effet)

    public float forceDuSaut; // hauteur du saut
    public float velocitePersoY;
    public float gravite; // force de la gravité

    bool toucheSaut;   //Variable pour savoir si le joueur a sauter ou non
    bool finPartie;     //Variable pour savoir si la partie est finie ou non 
    public bool auSol;    //Variable pour savoir si le joueur est au sol ou non
    public bool avecAnimationPerso;    //Variable pour savoir si le joueur a des animations à éxecuter

    void Start()
    {
        // Permet de verrouiller le curseur et de le masquer
        Cursor.lockState = CursorLockMode.Locked;
        // On garde dans une variable la référence au component RigidBody
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toucheSaut = true;
        }
    }

    // Gestion du déplacement du Rigidbody avec Move qui permet le saut.
    void FixedUpdate()
    {
        // On mémorise la valeur des axes Horizontal et Vertical. On pourrait utiliser GetAxisRaw aussi.
        float deplaceX;
        float deplaceZ;

        if (!finPartie)
        {
            deplaceX = Input.GetAxis("Horizontal");
            deplaceZ = Input.GetAxis("Vertical");
        }
        else
        //----------------------------FIN DE LA PARTIE****************************
        {   
            //Le joueur n'a plus de velocité en X et Z (marche)
            deplaceX = 0;
            deplaceZ = 0;
            //Le joueur ne peut plus sauter
            toucheSaut = false;
            //On appelle la scène de fin après un délai
            Invoke("RecommencerPartie", 10f);
        }

        // transform.TransformDirection permet de transformer une direction locale en direction du monde (local space to world space)
        // On calcul le vecteur de déplacement en utilisant la direction qu'on mutiplie par la vitesse;
        Vector3 deplacement = transform.TransformDirection(new Vector3(deplaceX, 0f, deplaceZ) * vitesse);


        // Permet de savoir si le characterController touche au sol
        RaycastHit hit;
        auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.2f, 0), 0.15f, -Vector3.up, out hit, 0.16f);

// ---------------------------SAUT***************************
        // On remet la velocitePersoY à 0 si le personnage est au sol et que la velocitePerso est
        // plus petite que zéro.
        if (auSol && velocitePersoY < 0) velocitePersoY = 0f;

        // On permet le saut seulement si le characterController est au sol (avec la touche espace)
        if (toucheSaut && auSol)
        {
            //On invoque l'animation après un délai pour ajouter du réalisme à l'animation
            Invoke("SautePersonnage", 0.3f);
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

        //if(auSol) print(hit.transform.name);   //Debug


// ---------------------------DÉPLACEMENT***************************
        // Application de la nouvelle vélocité enregistrée au rigidbody
        rigidbodyPerso.velocity = deplacement;


//-----------------------------ROTATION-----------------------------
        // On fait tourner le personnage en fonction du déplacement horizontal de la souris
        float tourne = Input.GetAxis("Mouse X") * vitesseTourne * Time.deltaTime;
        transform.Rotate(0f, tourne, 0f);

        if (avecAnimationPerso) GestionAnim(deplacement);
        TournePersonnage();
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

    //Fonction pour faire sauter Kaya
    void SautePersonnage()
    {
        velocitePersoY = forceDuSaut; // On ajuste la variable velociteYPerso à la force du saut.
    }


    //Fonction pour la gestion des animations de Kaya
    void GestionAnim(Vector3 valeurDeplacement)
    {
        valeurDeplacement.y = 0f;
        if (!finPartie)
        {   
            // on mémorise la valeur des axes Horizontal et Vertical. On pourrait utiliser GetAxisRaw aussi.
            float deplaceX = Input.GetAxis("Horizontal");
            float deplaceZ = Input.GetAxis("Vertical");

            //-------------------------IDLE (Animation lorsque le personnage est en arrêt);
            if(valeurDeplacement.magnitude < 1f) GetComponent<Animator>().SetInteger("statueAnimation", -1);

            //-------------------------DÉPLACEMENT VERS L'AVANT
            if (valeurDeplacement.magnitude > 1f && deplaceZ > 0.1f)
            {
                GetComponent<Animator>().SetInteger("statueAnimation", 2);
            }


            //-------------------------DÉPLACEMENT VERS L'ARRIÈRE
            if (valeurDeplacement.magnitude > 1f && deplaceZ < -0.1f )
            {
                GetComponent<Animator>().SetInteger("statueAnimation", 3);
            }


            //-------------------------DÉPLACEMENT À GAUCHE
            if (deplaceX < -0.1f && Mathf.Abs(deplaceZ) < 0.1f)
            {
                GetComponent<Animator>().SetInteger("statueAnimation", 0);
            }


            //-------------------------DÉPLACEMENT À DROITE
            if (deplaceX > 0.1f && Mathf.Abs(deplaceZ) < 0.1f)
            {
                GetComponent<Animator>().SetInteger("statueAnimation", 1);
            }

        }
        else
        {
            //valeurDeplacement = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetBool("defaite", true);
            
            //GetComponent<AudioSource>().PlayOneShot(sonDefaite);
        }
    }

    //Fonction adaptée pour le Rigidbody pour la gestion des collisions
    void OnCollisionEnter(Collision infoCollision)
    {
        if (infoCollision.gameObject.tag == "piqueDanger")
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

    
    
    //FONCTION POUR DEBUGGER LE SPHERECAST--------------------------------------
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0.3f, 0) - transform.up * 0.16f, 0.15f);
    }
}

