using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject playerBar1;
    public GameObject playerBar2;
    public GameObject towerBar1;
    private int valueBarn1;
    private int valueBarn2;
    private int valueTowerBarn1;

    void Start()
    {
        playerBar1.transform.localScale = new Vector3(
                GetBarScale(valueBarn1),
                playerBar1.transform.localScale.y,
                playerBar1.transform.localScale.z);
        playerBar2.transform.localScale = new Vector3(
            GetBarScale(valueBarn2),
            playerBar1.transform.localScale.y,
            playerBar1.transform.localScale.z);
    }

    void Update()
    {
        ChangeHealthBar(playerBar1.transform, valueBarn1);
        ChangeHealthBar(playerBar2.transform, valueBarn2);
        ChangeHealthBar(towerBar1.transform, valueTowerBarn1);
    }
    
    public void ChangeHealthBar(int value, int player)
    {
        if (player == 1)
        {
            ChangeHealthBar1(value);
        }
        else
        {
            ChangeHealthBar2(value);
        }
    }

    private void ChangeHealthBar1(int value)
    {
        valueBarn1 = value;
    }

    private void ChangeHealthBar2(int value)
    {
        valueBarn2 = value;
    }

    public void ChangeTowerHealthBar(int value, int tower)
    {
        if (tower == 1)
        {
            ChangeTowerHealthBar1(value);
        }
    }

    private void ChangeTowerHealthBar1(int value)
    {
        valueTowerBarn1 = value;
    }

    private void ChangeHealthBar(Transform transform, int value)
    {
        transform.localScale =
            new Vector3(
            Mathf.Lerp(transform.localScale.x, GetBarScale(value), Time.deltaTime * 10 ), 
            transform.localScale.y, 
            transform.localScale.z);
    }    

    private float GetBarScale(int value)
    {
        return value / 100.0f;
    }
}
