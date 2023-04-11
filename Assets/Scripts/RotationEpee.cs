using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEpee : MonoBehaviour
{
    // ***** Attributs *****

    
    // ***** Mthodes publiques *****

    // On utilise le FixedUpdate car l'objet va grer des collisions avec un ou des rigidbody
    void FixedUpdate()
    {
        transform.Rotate(6f, 0f, 0f);  // tabli une rotation du gameObject autour de l'axe des Y
    }
}
