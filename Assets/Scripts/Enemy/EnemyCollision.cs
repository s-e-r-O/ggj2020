using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 11);
        Physics2D.IgnoreLayerCollision(11, 11);
        Physics2D.IgnoreLayerCollision(10, 11);
    }
}
