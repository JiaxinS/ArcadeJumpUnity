using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    public GameObject playerbullet;
    public GameObject BulletPosition;
    public float movementSpeed = 10f;
    AudioSource shoot;
    int coinAmount;
    bool mInvincible;
    float kDamagePushForce = 2.5f;
    float mInvincibleTimer;
    public float Health = 1;
    Rigidbody2D RigidBody2D;
    Vector2 mFacingDirection;
    Rigidbody2D rb;
    float someScale;
    float movement = 0f;

    [SerializeField]
    GameObject mDeathParticleEmitter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mFacingDirection = Vector2.right;
        shoot = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(playerbullet);
            bullet.transform.position = BulletPosition.transform.position;
            shoot.Play();
        }   
        movement = Input.GetAxis("Horizontal") * movementSpeed;
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
   
    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }

    public void Takedamage(double dmg)
    {
        Vector2 forceDirection = new Vector2(-mFacingDirection.x, 1.0f) * kDamagePushForce;
        rb.velocity = Vector2.zero;
        rb.AddForce(forceDirection, ForceMode2D.Impulse);
        Health -= (float)dmg;

        if (Health <= 0)
            Die();
    }

    public void Die()
    {
        Instantiate(mDeathParticleEmitter, transform.position, Quaternion.identity);
        SceneManager.LoadScene("End");
        Destroy(gameObject);
    }
}