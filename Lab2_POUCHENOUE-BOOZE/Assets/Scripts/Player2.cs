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
        transform.position = new Vector3(68.88f, 28.36f, 55.33f);  // place le joueur � sa position initiale 
    }

    // Ici on utilise FixedUpdate car les mouvements du joueurs implique le d�placement d'un rigidbody
    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    /*
     * M�thode qui g�re les d�placements du joueur
     */
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal"); // R�cup�re la valeur de l'axe horizontal de l'input manager
        float positionZ = Input.GetAxis("Vertical");  // R�cup�re la valeur de l'axe vertical de l'input manager
        Vector3 direction = new Vector3(positionX, 0f, positionZ);  // �tabli la direction du vecteur � appliquer sur le joueur
        direction.Normalize();
        transform.Translate(direction * _vitesse * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _vitesseRotation * Time.deltaTime);
        }
    }




}
