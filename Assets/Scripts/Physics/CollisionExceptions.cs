using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExceptions : MonoBehaviour
{
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Player"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Items"), LayerMask.NameToLayer("Items"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Enemies"));

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemies"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Bullet"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Items"), LayerMask.NameToLayer("Enemies"));
    }
}
