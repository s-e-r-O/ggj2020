using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject barn1;
    public GameObject barn2;
    private int valueBarn1;
    private int valueBarn2;

    void Start()
    {
        barn1.transform.localScale = new Vector3(
                GetBarScale(valueBarn1),
                barn1.transform.localScale.y,
                barn1.transform.localScale.z);
        barn2.transform.localScale = new Vector3(
            GetBarScale(valueBarn2),
            barn1.transform.localScale.y,
            barn1.transform.localScale.z);
    }

    void Update()
    {
        ChangeHealthBar(barn1.transform, valueBarn1);
        ChangeHealthBar(barn2.transform, valueBarn2);
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
        return (value * 4.0f) / 100.0f;
    }
}
