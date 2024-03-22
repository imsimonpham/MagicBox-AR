using UnityEngine;


public class Gem : MonoBehaviour
{
    public string gemColor = "";
    public bool isSelected;

    private Material _material;


    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _material.DisableKeyword("_EMISSION");
    }


    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting)
        {
            _material.EnableKeyword("_EMISSION");
        } else
        {
            _material.DisableKeyword("_EMISSION");
        }
    }
}
