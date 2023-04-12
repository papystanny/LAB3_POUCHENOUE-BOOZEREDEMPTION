using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollition : MonoBehaviour
{
    // ***** Attributs *****
    private GestionJeu _gestionJeu;  // Sert a recupererle l'attribut pointage dans la classe GestionJeu
    private bool _touche;  // Booleen qui permet de detecter si l'objet a ete touche
    private float _temps;

    // ***** Methodes privees *****
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // lie la variable au gameObject GestionJeu de la scene
        _touche = false;  // initialise le booleen  faux au debut de la scene
    }

    /* 
     * Role : Methode qui se declenche quand une collision se produit avec l'objet
     * Entree : un objet de type Collision qui represente l'objet avec qui la collision s'est produite
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )  // Si l'objet avec la collision s'est produite est le joueur et qu'il n'a pas deja et touche
        {
            if( !_touche)
            {
                MeshRenderer[] pouletCorps = gameObject.GetComponentsInChildren<MeshRenderer>();
                        foreach (MeshRenderer corps in pouletCorps) 
                        {
                            corps.material.color = Color.red;
                        }
                        _gestionJeu.AugmenterPointage();  // Appelle la methode publique dans GestionJeu pour augmenter le pointage
                        _touche = true;
                        _temps = Time.time + 4;
            }
        
            //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;  //change la couleur du materiel  rouge
           
          //  _touche = true;  // change le booleen  vrai pour indique que l'objet a ete touche
        }
    }

    private void FixedUpdate () 
    {
        if (_touche)
        {
             if(_temps == Time.time)
                    {
                        _touche = false;
                        MeshRenderer[] pouletCorps = gameObject.GetComponentsInChildren<MeshRenderer>();
                        foreach (MeshRenderer corps in pouletCorps)
                        {
                            corps.material.color = Color.white;
                            
                        }
                       
                    }
         
        }
       
    }
}
