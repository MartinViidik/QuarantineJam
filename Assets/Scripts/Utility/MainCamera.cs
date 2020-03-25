﻿using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera _instance;
    GameObject rubTarget;
    GameObject grabTarget;
    Vector3 pos;

    public static MainCamera Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider.CompareTag("Door"))
            {
                Door door = hitCollider.GetComponent<Door>();
                if (door.open)
                {
                    door.SelectDoor();
                    Score.Instance.ShowIndicator(Input.mousePosition, true);
                }
                
            }
            if (hitCollider.CompareTag("Hand"))
            {
                Debug.Log(pos);
                rubTarget = hitCollider.gameObject;
            }
            if (hitCollider.CompareTag("DirtyHand"))
            {
                Debug.Log("test");
                hitCollider.GetComponent<DirtyHand>().MoveBack();
                pos = Input.mousePosition;
                Score.Instance.ShowIndicator(Input.mousePosition, true);
            }
            if (hitCollider.CompareTag("Person"))
            {
                hitCollider.GetComponent<Person>().SetRetreating();
            }
            if (hitCollider.CompareTag("Mask"))
            {
                grabTarget = hitCollider.gameObject;
                hitCollider.GetComponent<Mask>().dragged = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(rubTarget != null)
            {
                rubTarget.GetComponent<Hand>().StopRubbing();
                rubTarget = null;
            }
            if(grabTarget != null)
            {
                grabTarget.GetComponent<Mask>().dragged = false;
                grabTarget = null;
            }
        }

        if (rubTarget != null)
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

    public Vector3 ReturnMousePosition()
    {
        Vector3 position = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(pos);
    }
}
