using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{


    // ***** Attributs *****

    [SerializeField] private float _vitesse = 5f;

    [SerializeField] private float _vitesseRotation = 140f;





    void Start()
    {
        transform.position = new Vector3(68.88f, 28.36f, 55.33f);  // place le joueur à sa position initiale 
    }

    // Ici on utilise FixedUpdate car les mouvements du joueurs implique le déplacement d'un rigidbody
    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    /*
     * Méthode qui gère les déplacements du joueur
     */
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal"); // Récupère la valeur de l'axe horizontal de l'input manager
        float positionZ = Input.GetAxis("Vertical");  // Récupère la valeur de l'axe vertical de l'input manager
        Vector3 direction = new Vector3(positionX, 0f, positionZ);  // Établi la direction du vecteur à appliquer sur le joueur
        direction.Normalize();
        transform.Translate(direction * _vitesse * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _vitesseRotation * Time.deltaTime);
        }
    }




}
