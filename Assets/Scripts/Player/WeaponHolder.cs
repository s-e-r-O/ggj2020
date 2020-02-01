using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weaponPrefab;
    public Vector2 rightOffset, leftOffset;

    private Weapon weapon;
    private bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        weapon = Instantiate(weaponPrefab, transform);
        weapon.input = GetComponent<PlayerInput>();
        Flip(true);     
    }

    void Update()
    {
        weapon.gameObject.transform.position = transform.position +
            (Vector3)(isRight ? rightOffset : leftOffset);
    }

    public void Flip(bool isRight)
    {
        this.isRight = isRight;
        weapon.direction = isRight? Vector2.right : Vector2.left;
    }
}
