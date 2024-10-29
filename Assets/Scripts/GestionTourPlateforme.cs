using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionTourPlateforme : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GererTourDuree());
    }

    IEnumerator GererTourDuree()
    {   
        // Tour Essaie
        yield return new WaitForSeconds(30); // Une pause est marquée

        // Tour 1
        yield return new WaitForSeconds(20);
        yield return new WaitForSeconds(20);

        // Tour 2
        yield return new WaitForSeconds(20);
        yield return new WaitForSeconds(20);

        // Tour 3
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 4
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 5
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 6
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 7
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15); 

        // Tour 8
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 9
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);
        yield return new WaitForSeconds(15);

        // Tour 10
        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);

        // Tour 10
        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("SceneFinale");
    }

}
