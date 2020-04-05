using UnityEngine;

public class Mask : MonoBehaviour
{
    public bool dragged;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject person;

    private Vector3 initialPosition;

    public void Update()
    {
        if (dragged)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 1);
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if(dist <= 1.35f)
            {
                dragged = false;
                target.GetComponent<VisualMask>().MaskFadeIn();
                person.GetComponent<MaskPerson>().SetToEndState();
                Score.Instance.UpdateScore(10, transform.position, false);
                transform.position = initialPosition;
            }
        }
    }
    private void Awake()
    {
        initialPosition = transform.position;
        Debug.Log(target.transform.position);
    }
}
