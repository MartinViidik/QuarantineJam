using UnityEngine;

public class DirtyHand : MonoBehaviour
{
    public GameObject target;
    private Vector3 targ;
    public float speed = 500f;
    public float dist;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.localPosition, targ, speed * Time.deltaTime * 3);
        dist = Vector3.Distance(targ, transform.localPosition);
        if (dist <= 4)
        {
            Score.Instance.UpdateScore(-25);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (gameObject.activeSelf)
        {
            float x = Random.Range(-6, -4);
            float y = Random.Range(-5, 5);
            Vector3 position = new Vector3(x, y, 1);
            float distCheck = Vector3.Distance(targ, position);

            if (distCheck <= 5.5f)
            {
                gameObject.SetActive(false);
                return;
            } else {
                transform.position = position;
            }
            targ = new Vector3(0, 0, 0);
            RotateTowardsTarget();
        }
    }

    public void RotateTowardsTarget()
    {
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
        gameObject.SetActive(false);
        Score.Instance.UpdateScore(15);
    }

}
