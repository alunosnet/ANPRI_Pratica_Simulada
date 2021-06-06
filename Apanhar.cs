using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apanhar : MonoBehaviour
{
  
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //verificar se ainda não leva um ovo
            if (other.GetComponentInChildren<DropMe>() == null)
            {
                transform.parent = other.gameObject.transform;
                GetComponent<Rigidbody>().isKinematic = true;

            }
        }
    }
}
