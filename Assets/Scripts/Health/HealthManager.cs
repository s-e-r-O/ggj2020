using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject playerBar1;
    public GameObject playerBar2;
    public GameObject towerBar1;
    public GameObject towerBar2;
    private int valueBarn1;
    private int valueBarn2;
    private int valueTowerBarn1;
    private int valueTowerBarn2;

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
        ChangeHealthBar(towerBar2.transform, valueTowerBarn2);
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
        else if (tower ==2)
        {
            ChangeTowerHealthBar2(value);
        }
    }

    private void ChangeTowerHealthBar1(int value)
    {
        valueTowerBarn1 = value;
    }

    private void ChangeTowerHealthBar2(int value)
    {
        valueTowerBarn2 = value;
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
        return Mathf.Max(value / 100.0f, 0f);
    }
}
