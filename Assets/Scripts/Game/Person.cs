using UnityEngine;

public class Person : MonoBehaviour
{
    private enum PersonState
    {
        Stationary,
        Retreating,
        Moving,
        Talking
    }
    public GameObject target;
    public DistanceController controller;
    Vector3 startPosition;
    PersonState _state;
    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        switch (_state)
        {
            case PersonState.Moving:
                {
                    MoveTo(target.transform.localPosition, 2.5f);
                    if (GetDistance(target.transform.localPosition) <= 4f)
                    {
                        _state = PersonState.Talking;
                    }
                }
                break;
            case PersonState.Retreating:
                {
                    MoveTo(startPosition, 3.5f);
                    if(GetDistance(startPosition) <= 0.5f)
                    {
                        _state = PersonState.Moving;
                    }
                }
                break;
            case PersonState.Talking:
                {
                    controller.TalkingTimer();
                }
                break;
            case PersonState.Stationary:
                {

                }
                break;
            default:
                _state = PersonState.Stationary;
                break;
        }
    }

    void MoveTo(Vector3 target, float speed)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime * speed);
    }

    float GetDistance(Vector3 target)
    {
        return Vector3.Distance(transform.localPosition, target);
    }

    public void SetRetreating()
    {
        if(_state != PersonState.Retreating)
        {
            _state = PersonState.Retreating;
            Score.Instance.UpdateScore(5);
            Score.Instance.ShowIndicator(transform.localPosition, false);
        }
    }
    public void SetMoving()
    {
        _state = PersonState.Moving;
    }
}
