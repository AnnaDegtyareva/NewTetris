using UnityEngine;
using YG;
public class FixRBT : MonoBehaviour
{
    public Vector2 CorrectPosAtFullHD;
    public Vector2 CorrectSizeAtFullHD;
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(CorrectSizeAtFullHD.x / 1920 * Screen.width, CorrectSizeAtFullHD.y / 1080 * Screen.height);
        rt.localPosition = new Vector2(CorrectPosAtFullHD.x / 1920 * Screen.width, CorrectPosAtFullHD.y / 1080 * Screen.height);
        GetComponentInParent<BannerYG>().RecalculateRect();
    }
}
