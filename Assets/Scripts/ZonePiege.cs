using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonePiege : MonoBehaviour
{

    private bool _estActive = false;
    [SerializeField] private List<GameObject> _listPieges = new List<GameObject>();
    private List<Rigidbody> _listRb = new List<Rigidbody>();
    [SerializeField] private float _intensiveForce = 200;

    private void Awake()
    {
        foreach (var piege in _listPieges)
        {
            _listRb.Add(piege.GetComponent<Rigidbody>());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
       
        if (other.gameObject.tag == "Player" && !_estActive)
        {
          

            foreach (var rb in _listRb)
            {
                rb.useGravity = true;
                Vector3 direction = new Vector3(0f, -1f, 0f);
                rb.AddForce(direction * _intensiveForce);
            }
            _estActive = true;


        }

    }


}