using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    private AudioSource audioSource;
    private Rigidbody _rigivody;
    public float footstepThreshold;
    public float footstepRate;
    private float lasgFootstepTime;

    private void Start()
    {
        _rigivody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Mathf.Abs(_rigivody.velocity.y) < 0.1f)
        {
            if(_rigivody.velocity.magnitude > footstepThreshold)
            {
                if(Time.time - lasgFootstepTime > footstepRate)
                {
                    lasgFootstepTime = Time.time;
                    audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
                }
            }
        }
    }
}
