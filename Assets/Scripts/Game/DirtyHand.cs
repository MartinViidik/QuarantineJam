using UnityEngine;

public class DirtyHand : MonoBehaviour
{
    public GameObject target;
    private Vector3 targ;
    public float speed = 500f;
    public float dist;
    public GameObject fingerPos;

    private DirtyHandController dirtyController;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * 3);
        dist = Vector3.Distance(target.transform.position, fingerPos.transform.position);
        if (dist <= 0.6f)
        {
            Score.Instance.UpdateScore(-25, transform.localPosition, false);
            dirtyController.PlaySound();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (gameObject.activeSelf)
        {
            if (dirtyController == null)
            {
                dirtyController = gameObject.GetComponentInParent<DirtyHandController>();
                target = dirtyController.target;
            }

            float x = Random.Range(-6, 6);
            float y = Random.Range(-5, 5);
            Vector3 position = new Vector3(x, y, 1);
            float distCheck = Vector3.Distance(target.transform.localPosition, position);

            if (distCheck <= 3.5f)
            {
                gameObject.SetActive(false);
                return;
            } else {
                transform.position = position;
            }

            RotateTowardsTarget();
        }
    }

    public void RotateTowardsTarget()
    {
        targ = target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (transform.localPosition.x >= 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
        }
    }

    public void MoveBack()
    {
        dirtyController.PlaySound();
        gameObject.SetActive(false);
        Score.Instance.UpdateScore(15, Input.mousePosition, true);
    }

}
