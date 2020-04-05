using System.Collections;
using UnityEngine;

public class MallController : MonoBehaviour
{
    [SerializeField]
    private GameObject toiletPaper;

    [SerializeField]
    private GameObject cart;
    private bool mallEnabled;
    private void Start()
    {
        StartCoroutine(InitialDelay());
        mallEnabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && enabled)
        {
            if (!toiletPaper.activeInHierarchy)
            {
                toiletPaper.GetComponent<ToiletPaper>().SpawnToiletPaper(MainCamera.Instance.ReturnMousePosition());
            }
        }
    }
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("hoard");
        yield return new WaitForSeconds(3f);
        cart.GetComponent<Cart>().ActivateCarts(true);
        mallEnabled = true;
    }
}
