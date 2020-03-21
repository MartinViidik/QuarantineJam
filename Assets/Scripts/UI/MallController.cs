using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallController : MonoBehaviour
{
    public GameObject toiletPaper;
    public GameObject cart;
    bool enabled;
    private void Start()
    {
        StartCoroutine(InitialDelay());
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
        Objective.Instance.UpdateObjective("Don't hoard supplies!");
        yield return new WaitForSeconds(3f);
        cart.GetComponent<Cart>().activated = true;
        enabled = true;
    }
}
