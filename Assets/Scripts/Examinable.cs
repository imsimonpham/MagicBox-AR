using UnityEngine;

public class Examinable : MonoBehaviour
{
    private ExaminableManager _examinableManager;
    public float examineScaleOffset = 0.8f;

    private void Start()
    {
        _examinableManager = GameObject.FindObjectOfType<ExaminableManager>();
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
    }

    public void RequestExamine()
    {
        _examinableManager.PerformExamine(this);
    }

    public void RequestUnexamine()
    {
        _examinableManager.PerformUnexamine();
    }
}
