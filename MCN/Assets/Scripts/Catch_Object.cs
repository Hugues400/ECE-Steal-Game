using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Object : MonoBehaviour
{
    [SerializeField] private AudioClip audioCatchObject = null;
    private AudioSource perso_AudioSource;



    // Start is called before the first frame update
    void Start()
    {
        perso_AudioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void PlaySound()
    {
        perso_AudioSource.PlayOneShot(audioCatchObject);
    }
}
