using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnermy : MonoBehaviour {

    [SerializeField]
    GameObject mExplosionPrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            Destroy(col.gameObject);
            Instantiate(mExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            col.GetComponent<player>().Takedamage(1);
        }
    }
}
