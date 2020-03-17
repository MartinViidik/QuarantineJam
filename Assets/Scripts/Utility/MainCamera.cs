using UnityEngine;

public class MainCamera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider.CompareTag("Door"))
            {
                hitCollider.GetComponent<Door>().SelectDoor();
            }
        }
    }
}
