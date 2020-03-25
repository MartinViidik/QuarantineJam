using UnityEngine;

public class VisualMask : MonoBehaviour
{
    public void MaskFadeIn()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void MaskFadeOut()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f);
        }
    }
}
