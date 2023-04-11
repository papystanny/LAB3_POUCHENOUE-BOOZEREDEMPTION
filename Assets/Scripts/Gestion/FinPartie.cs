using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****
    private bool _finPartie = false;
    private Joueur joueur;
    private GestionJeu _gestionJeu;

    // Methodes privees //
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        joueur = FindObjectOfType<Joueur>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            _finPartie = true;
            int noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == (SceneManager.sceneCountInBuildSettings -1 ))
            {
                int accrochages = _gestionJeu.GetPointage();
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();
                float tempsTotalniv2 = _gestionJeu.GetTempsNiv2() + _gestionJeu.GetAccrochagesNiv2();
                float _tempsNiveau3 = Time.time - ( _gestionJeu.GetTempsNiv1() + _gestionJeu.GetTempsNiv2() )  ; // Calcul le temps pour le niveau 3
                int _accrochagesNiveau3 = _gestionJeu.GetPointage() - ( _gestionJeu.GetAccrochagesNiv1() + _gestionJeu.GetAccrochagesNiv2() ) ; // Calcul le nombre d'accrochages pour le niveau 3
                float tempsTotalniv3 = _tempsNiveau3 + _accrochagesNiveau3; // Calcul le temps total pour le niveau 2
                // Affichage des resultats finaux dans la console 

                Debug.Log("Fin de partie !!!!!!!");

                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroche au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 2 est de : " + _gestionJeu.GetTempsNiv2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroche au niveau 2 : " + _gestionJeu.GetAccrochagesNiv2() + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 3 est de : " + _tempsNiveau3.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroche au niveau 3 : " + _accrochagesNiveau3 + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");

           
                Debug.Log("Le temps total pour les trois niveau est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");

                joueur.finPartieJoueur();
            }
            else if (noScene == 1)
            {
                // Apelle la methode publique dans gestion jeu pou conserver les informations du niveau 2
              
                _gestionJeu.SetNiveau2( (_gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiv1() ), ( Time.time - _gestionJeu.GetTempsNiv2() )  );
               
                // Charge la scene suivante 
                SceneManager.LoadScene(noScene + 1);
            }
            else 
            {
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
