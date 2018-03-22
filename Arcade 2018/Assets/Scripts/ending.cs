using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour {
    [SerializeField]
    GameObject mDeathPrefab;
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("platform"))
        {
            Instantiate(mDeathPrefab, transform.position, Quaternion.identity);
        }
    }
}
