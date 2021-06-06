using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteLigarDesLigarLuz : MonoBehaviour
{
    [SerializeField]
    Light luz;
    // Start is called before the first frame update
    void Start()
    {
        luz.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            luz.enabled = !luz.enabled;
    }
}
