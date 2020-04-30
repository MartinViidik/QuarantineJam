using UnityEngine;
public class Crowd : MonoBehaviour
{
    [SerializeField]
    private bool single;
    private CrowdController controller;
    [SerializeField]
    private Sprite[] crowdSprites;
    [SerializeField]
    private GameObject[] crowdItems;

    private Animator anim;
    private void Awake()
    {
        controller = gameObject.GetComponentInParent(typeof(CrowdController)) as CrowdController;
        anim = GetComponent<Animator>();
        SetSprites();
    }
    public void DisperseCrowd()
    {
        if (single)
        {
            Score.Instance.UpdateScore(-10,Input.mousePosition, true);
            Disappear();
        } else
        {
            CurrentState.crowds++;
            Score.Instance.UpdateScore(10, Input.mousePosition, true);
            Disappear();
            controller.ReduceActiveGroupAmount();
        }
    }
    void SetSprites()
    {
        for(int i = 0; i <crowdItems.Length; i++)
        {
            SpriteRenderer childSprite = crowdItems[i].GetComponent<SpriteRenderer>();
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
    public void Disappear()
    {
        anim.SetBool("Disappear", true);
        Destroy(gameObject, 0.75f);
    }
}
