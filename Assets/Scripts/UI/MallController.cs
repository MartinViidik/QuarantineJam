using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MallController : MonoBehaviour
{
    [SerializeField]
    private GameObject toiletPaper;

    [SerializeField]
    private GameObject cart;
    private bool mallEnabled;

    [SerializeField]
    private GameObject frontShelves;
    [SerializeField]
    private GameObject backShelves;
    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject wall;
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
        yield return new WaitForSeconds(1.3f);
        Appear();
        yield return new WaitForSeconds(0.8f);
        Objective.Instance.UpdateObjective("hoard");
        yield return new WaitForSeconds(3f);
        cart.GetComponent<Cart>().ActivateCarts(true);
        mallEnabled = true;
    }
    void Appear()
    {
        wall.transform.DOLocalMove(new Vector3(0, 4.5f, 0), 0.5f, false);
        floor.transform.DOLocalMove(new Vector3(0, -5f, 0), 0.5f, false);
        frontShelves.transform.DOLocalMove(new Vector3(1.3f, 0.8f, 0), 0.75f, false);
        backShelves.transform.DOLocalMove(new Vector3(1, 2.75f, 0), 0.75f, false);
    }
}
