using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleKalya : MonoBehaviour
{
    public float vitesse;// vitesse de déplacement
    public float vitesseTourne; // vitesse de rotation
    private CharacterController controleur; // référence au component characterController

    public float forceDuSaut; // hauteur du saut
    public float gravite; // force de la gravité

    private float velocitePersoY;

    private bool toucheSaut;

    public bool auSol;
    public bool avecAnimationPerso;
    public bool finPartie;

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

    void GestionAnim(Vector3 valeurDeplacement)
    {
        valeurDeplacement.y = 0f;
        bool marche = false;
        if (valeurDeplacement.magnitude > 1f) marche = true;
        GetComponent<Animator>().SetBool("marche", marche);

    }
}

