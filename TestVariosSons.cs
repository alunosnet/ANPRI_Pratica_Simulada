using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVariosSons : MonoBehaviour
{
    [SerializeField]
    AudioClip[] Sons;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _audioSource.clip = Sons[0];
            _audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.clip = Sons[1];
            _audioSource.Play();
        }
    }
}
