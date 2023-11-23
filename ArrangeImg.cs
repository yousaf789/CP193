using UnityEngine;
using UnityEngine.UI;

public class ArrangeRawImages : MonoBehaviour
{
    public RawImage rawImage1;
    public RawImage rawImage2;

    void Start()
    {
        // Assuming you've set up the rawImage1 and rawImage2 references in the Inspector
        ArrangeImagesBackToBack();
    }

    void ArrangeImagesBackToBack()
    {
        RectTransform rectTransform1 = rawImage1.rectTransform;
        RectTransform rectTransform2 = rawImage2.rectTransform;

        // Adjust the position of rawImage1
        rectTransform1.anchoredPosition = new Vector2(-rectTransform1.sizeDelta.x / 2, 0f); // Example position
        rectTransform1.sizeDelta = new Vector2(200f, 200f); // Example size

        // Adjust the position of rawImage2 to be back to back with rawImage1
        rectTransform2.anchoredPosition = new Vector2(rectTransform1.anchoredPosition.x + rectTransform1.sizeDelta.x / 2 + rectTransform2.sizeDelta.x / 2, 0f); // Example position
        rectTransform2.sizeDelta = new Vector2(200f, 200f); // Example size
    }
}
