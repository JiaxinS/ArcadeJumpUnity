using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzoom : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            col.GetComponent<player>().Takedamage(1f);
        }
    }
}
