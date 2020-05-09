using UnityEngine;

public class DirtyHand : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 targ;

    private float speed = 1f;
    private float dist;

    [SerializeField]
    private GameObject fingerPos;

    private DirtyHandController dirtyController;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * 2f);
        dist = Vector3.Distance(target.transform.position, fingerPos.transform.position);
        if (dist <= 1)
        {
            Score.Instance.UpdateScore(-25, transform.localPosition, false);
            CurrentState.face++;
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

            float x = Random.Range(-5, 5);
            float y = Random.Range(-4, 4);
            Vector3 position = new Vector3(x, y, 1);
            float distCheck = Vector3.Distance(target.transform.position, position);

            if (distCheck <= 4)
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
