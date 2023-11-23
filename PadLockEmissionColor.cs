using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    TimeBlinking tb;

    private GameObject _myRuller;

    [HideInInspector]
    public bool _isSelect;

    private void Awake()
    {
        tb = FindObjectOfType<TimeBlinking>();
    }

    void Start()
    {
        _myRuller = gameObject;
    }

    public void BlinkingMaterial()
    {
        _myRuller.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

        if (_isSelect)
        {
            float intensity = 0.2f; // Adjust this value to control the intensity (0.0 to 1.0)
            Color targetColor = new Color(1f, 0.92f, 0.016f, intensity); // Yellow color with reduced intensity
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.clear, targetColor, Mathf.PingPong(Time.time, tb.blinkingTime)));
        }
        else
        {
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }
    }
}
