using UnityEngine;

public class SpriteTiler : MonoBehaviour
{
    private Renderer sprite;
    private void Awake()
    {
        sprite = GetComponent<Renderer>();
    }
    private void Update()
    {
        TileSprite(0.1f);
    }
    void TileSprite(float amount)
    {
        float offset = Time.time * amount;
        sprite.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
