using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_coffre : MonoBehaviour
{



 private GestionJeu _gestionJeu;
    private bool _touche;

    private void Start()
    {
       _gestionJeu= FindObjectOfType<GestionJeu>();
        _touche = false;
    }

    void Update()
    {
              transform.Rotate(new Vector3(5f,0f,0f) * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && !_touche)
        {
            _touche = true;

            Debug.Log("Vous avez accrocher un coffre");
          
            _gestionJeu.AugmenterCoffre();
            Destroy(gameObject);

        }
       
    }


}
