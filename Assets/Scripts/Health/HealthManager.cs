using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public GameObject barn1;
    //public GameObject barn2;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            barn1.transform.localScale = new Vector3(4, barn1.transform.localScale.y, barn1.transform.localScale.z);
        }
    }

    public void ChangeHealthBar1(int value)
    {
        barn1.transform.localScale = 
            new Vector3((value*4.0f)/100.0f, barn1.transform.localScale.y, barn1.transform.localScale.z);  
    }

    //public void ChangeHealthBar2(int value)
    //{
    //    barn2.transform.localScale = 
    //        new Vector3(value * 4 / 100, barn1.transform.localScale.y, barn1.transform.localScale.z);
    //}
}
