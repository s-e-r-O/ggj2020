using DG.Tweening;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float secondsToLive = 0.5f;
    private TextMesh mesh;
    private void Awake()
    {
        mesh = GetComponent<TextMesh>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secondsToLive);
        /*mesh.color = Color.red*/;
        transform.DOMove(transform.position + Vector3.up, secondsToLive);
        Sequence seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => mesh.color.a,
            x => mesh.color = new Color(mesh.color.r, mesh.color.g, mesh.color.b, x),
            0, secondsToLive/2f));
        seq.PrependInterval(secondsToLive/2f);
        seq.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
