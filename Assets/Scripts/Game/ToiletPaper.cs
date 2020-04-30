using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    private float speed = 15;
    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime * speed;
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
        CurrentState.tp++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cart")
        {
            Cart cart = collision.gameObject.GetComponent<Cart>();
            if (!cart.fullCart)
            {
                Score.Instance.UpdateScore(10, cart.transform.position, false);
                cart.SetState(true);
            } else {
                Score.Instance.UpdateScore(-10, cart.transform.position, false);
            }
            cart.ImpactSound();
            gameObject.SetActive(false);
        }
    }
}
