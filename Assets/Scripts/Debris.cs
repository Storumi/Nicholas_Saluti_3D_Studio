using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField] GameObject[] debris;
    [SerializeField] List <Material> Darkrock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Collapse(GameObject Breaker)
    {
        Debug.Log("Wood breaking noise");
        foreach(GameObject a in debris)
        {
            a.GetComponent<Transform>().position -= new Vector3(0,2,0);
            a.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        GetComponent<BoxCollider>().isTrigger = true;
        Breaker.GetComponent<MeshRenderer>().SetMaterials(Darkrock);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rock")
        {
            Collapse(collision.gameObject);
        }
    }
}
