using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject rubTarget;
    Vector3 pos;
    bool rubbing;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider.CompareTag("Door"))
            {
                hitCollider.GetComponent<Door>().SelectDoor();
            }
            if (hitCollider.CompareTag("Hand"))
            {
                Debug.Log(pos);
                rubTarget = hitCollider.gameObject;
                rubbing = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(rubTarget != null)
            {
                rubbing = false;
                rubTarget.GetComponent<Hand>().StopRubbing();
            }
        }

        if (rubbing)
        {
            RubTarget();
        }
    }

    void RubTarget()
    {
        Vector3 inputPos = Input.mousePosition;
        if(pos != inputPos)
        {
            pos = Input.mousePosition;
            rubTarget.GetComponent<Hand>().inputPOS = pos;
            rubTarget.GetComponent<Hand>().GetRubbed();
        }
    }
}
