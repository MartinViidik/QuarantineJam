using System.Collections;
using UnityEngine;

public class MaskPerson : MonoBehaviour
{
    public GameObject visualMask;
    private Vector3 initialPosition;
    private Vector3 destination;
    public GameObject[] cosmeticParts;
    private enum MaskPersonState
    {
        Stationary,
        Begin,
        End
    }

    MaskPersonState _state;
    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(InitialDelay());
    }
    private void Update()
    {
        switch (_state)
        {
            case MaskPersonState.Begin:
                {
                    destination = new Vector3(-0.55f, 0.55f, 0);
                    MoveToDestination(destination, 12);
                    if(AtDestination(destination))
                    {
                        _state = MaskPersonState.Stationary;
                    }
                }
                break;
            case MaskPersonState.End:
                {
                    destination = new Vector3(6.5f, 0.55f, 0);
                    MoveToDestination(destination, 15);
                    if(AtDestination(destination))
                    {
                        MoveToStart();
                        _state = MaskPersonState.Begin;
                        visualMask.GetComponent<VisualMask>().MaskFadeOut();
                    }
                }
                break;
            default:
                _state = MaskPersonState.Stationary;
                break;
        }
    }

    void MoveToStart()
    {
        transform.position = initialPosition;
    }

    void MoveToDestination(Vector3 destination, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }

    bool AtDestination(Vector3 destination)
    {
        if (transform.position == destination)
        {
            return true;
        } else {
            return false;
        }
    }

    public void SetToEndState()
    {
        _state = MaskPersonState.End;
    }


    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("Wear protective gear!");
        yield return new WaitForSeconds(3f);
        _state = MaskPersonState.Begin;
    }
}
