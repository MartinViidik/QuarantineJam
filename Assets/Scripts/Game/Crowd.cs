using UnityEngine;
public class Crowd : MonoBehaviour
{
    [SerializeField]
    private bool single;
    private CrowdController controller;
    private void Awake()
    {
        controller = gameObject.GetComponentInParent(typeof(CrowdController)) as CrowdController;
    }
    public void DisperseCrowd()
    {
        if (single)
        {
            Score.Instance.UpdateScore(-10, transform.position, false);
            Destroy(gameObject, 0.25f);
        } else
        {
            Score.Instance.UpdateScore(10, transform.position, false);
            Destroy(gameObject, 0.25f);
            controller.ReduceActiveGroupAmount();
        }
    }
}
