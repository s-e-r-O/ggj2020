using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int secondsToLive = 15;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.parent.gameObject, secondsToLive);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player>().AddItems();
            Destroy(transform.parent.gameObject);
        }
    }
}
