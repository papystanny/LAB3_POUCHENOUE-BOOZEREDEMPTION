using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ***** Attributs *****

    // private float _vitesseRotation = 0.5f;  // Établi la vitesse de rotation du gameObject

    // ***** Méthodes publiques *****

    // On utilise le FixedUpdate car l'objet va gérer des collisions avec un ou des rigidbody
    void FixedUpdate()
    {
        transform.Rotate(0,2f, 0f);  // Etabli une rotation du gameObject autour de l'axe des Y
    }
}
