using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public int player = 1;
    public Vector2 GetMovement()
    {
        float x = Input.GetAxis(GetInputName("Horizontal"));
        float y = Input.GetAxis(GetInputName("Vertical"));
        return new Vector2(x, y);
    }

    public bool GetJump()
    {
        return Input.GetButton(GetInputName("Jump"));
    }
    public bool GetJumpDown()
    {
        return Input.GetButtonDown(GetInputName("Jump"));
    }

    public bool GetShoot()
    {
        return Input.GetButton(GetInputName("Fire1"));
    }

    public bool GetRepair()
    {
        return Input.GetButtonDown(GetInputName("Fire2"));
    }

    private string GetInputName(string name)
    {
        return name + (player == 1 ? "" : "2");
    }
}
