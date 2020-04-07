using UnityEngine;
public class Crowd : MonoBehaviour
{
    [SerializeField]
    private bool single;
    private CrowdController controller;
    [SerializeField]
    private Sprite[] crowdSprites;
    private void Awake()
    {
        controller = gameObject.GetComponentInParent(typeof(CrowdController)) as CrowdController;
        SetSprites();
    }
    public void DisperseCrowd()
    {
        if (single)
        {
            Score.Instance.UpdateScore(-10,Input.mousePosition, true);
            Destroy(gameObject, 0.25f);
        } else
        {
            Score.Instance.UpdateScore(10, Input.mousePosition, true);
            Destroy(gameObject, 0.25f);
            controller.ReduceActiveGroupAmount();
        }
    }
    void SetSprites()
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer childSprite = child.GetComponent<SpriteRenderer>();
            childSprite.sprite = crowdSprites[Random.Range(0, crowdSprites.Length)];
            childSprite.flipX = RNG();
        }
    }
    private bool RNG()
    {
        float RNG = Random.Range(0f, 1f);
        if(RNG >= 0.5)
        {
            return true;
        } else {
            return false;
        }
    }
}
