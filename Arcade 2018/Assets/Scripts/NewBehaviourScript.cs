using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    
    public Rigidbody2D Bullet;
    public Transform FPoint;
    AudioSource Bustershoot;

    // Use this for initialization
    void Start()
    {
        Bustershoot = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Rigidbody2D clone;
            clone = (Rigidbody2D)Instantiate(Bullet, FPoint.position, FPoint.rotation);
            clone.velocity = transform.TransformDirection(Vector3.right * 10);
            Bustershoot.Play();
        }

    }
}
