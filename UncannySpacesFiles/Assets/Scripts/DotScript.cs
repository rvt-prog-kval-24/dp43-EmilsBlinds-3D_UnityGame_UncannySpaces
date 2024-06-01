using UnityEngine;
using UnityEngine.UI;

public class DotScript : MonoBehaviour
{
    public float beepInterval = 0.5f;
    private Image DotImage;

    void Start()
    {
        DotImage = GetComponent<Image>();
        InvokeRepeating("ToggleVisibility", 0f, beepInterval);
    }

    void ToggleVisibility()
    {
        DotImage.enabled = !DotImage.enabled;
    }
}
