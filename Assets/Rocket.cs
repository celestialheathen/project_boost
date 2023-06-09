using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 250;
    [SerializeField] float mainThrust = 50f;
    Rigidbody rgbd;
    AudioSource audiosource;

    void Start()
    {
       rgbd = GetComponent<Rigidbody>(); 
       audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
       Thrust(); 
       Rotate();
    }

    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            default: 
                print("Dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rgbd.AddRelativeForce(Vector3.up * mainThrust);

            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else 
        {
            audiosource.Stop();
        }
    }

    private void Rotate()
    {   
        rgbd.freezeRotation = true;

        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }

        rgbd.freezeRotation = false;

    }
}
