using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    private int _accrochageNiveau1 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau1 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1
    private int _accrochageNiveau2 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 21
    private float _tempsNiveau2 = 0.0f;  // Attribut qui conserve le temps pour le niveau 2
    private int _accrochageNiveau3 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
 private float _tempsNiveau3 = 0.0f;  // Attribut qui conserve le temps pour le niveau 2
    private int _coffre = 0;


    // ***** Methodes privees *****
    private void Awake()
    {
        // Verifie si un gameObject GestionJeu est deja present sur la scene si oui
        // on detruit celui qui vient d'etre ajoute. Sinon on le conserve pour le 
        // scene suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InstructionsDepart();  // Affiche les instructions de depart
    }

    /*
     * Methode qui affiche les instructions au depart
     */
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course a obstacles");
        Debug.Log("Vous �tes devenu un fermier qui doit �viter tout objet et animaux");
        Debug.Log("Chaque contact avec un obstable entrainera une penalite");
        Debug.Log("");
    }

    // ***** Methodes publiques ******

    /*
     * Methode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
        Debug.Log("Nombe d'accrochages =" + _pointage);
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv1()
    {
        return _tempsNiveau1;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv1()
    {
        return _accrochageNiveau1;
    }

    // Accesseur qui retourne le temps pour le niveau 2
    public float GetTempsNiv2()
    {
        return _tempsNiveau2;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 2
    public int GetAccrochagesNiv2()
    {
        return _accrochageNiveau2;
    }

     // Accesseur qui retourne le temps pour le niveau 3
    public float GetTempsNiv3()
    {
        return _tempsNiveau3;
    }

     // Accesseur qui retourne le nombre d'accrochages pour le niveau 2
    public int GetAccrochagesNiv3()
    {
        return _accrochageNiveau3;
    }

  public void AugmenterCoffre() {

        _coffre++;
       // Debug.Log("Vous avez : " + _coffre +  " coffre ");
    }

     public int GetCoffre(){

        return _coffre;
    }


    // Methode qui recoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau1(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv1;
    }

    // Methode qui recoit les valeurs pour le niveau 2 et qui modifie les attributs respectifs
    public void SetNiveau2(int accrochages, float tempsNiv2)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv2;
    }

     // Methode qui recoit les valeurs pour le niveau 2 et qui modifie les attributs respectifs
    public void SetNiveau3(int accrochages, float tempsNiv3)
    {
        _accrochageNiveau3 = accrochages;
        _tempsNiveau3 = tempsNiv3;
    }
}
