using UnityEngine;

public class Examinable : MonoBehaviour
{
    private ExaminableManager _examinableManager;
    public float examineScaleOffset = 0.8f;

    private void Start()
    {
        _examinableManager = GameObject.FindObjectOfType<ExaminableManager>();
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
