using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    void Update()
    {
        transform.localPosition += Vector3.up * 0.35f;
        if(transform.localPosition.y > 6)
        {
            gameObject.SetActive(false);
        }
    }
    public void SpawnToiletPaper(Vector3 inputPOS)
    {
        float x = inputPOS.x;
        gameObject.SetActive(true);
        transform.localPosition = new Vector3(x, -6, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cart")
        {
            gameObject.SetActive(false);
            Score.Instance.UpdateScore(10);
            Score.Instance.ShowIndicator(transform.localPosition);
        }
    }
}
