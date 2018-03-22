using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
    [SerializeField]
    GameObject mHeartPrefab;
        void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Instantiate(mHeartPrefab, transform.position, Quaternion.identity);
            ScoreTextScript.coinAmount += 1;
            Destroy(gameObject);
            
        }
    }
}
