using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<Door> doors = new List<Door>();
    float cooldown = 1.5f;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            doors.Add(t.gameObject.GetComponent<Door>());
        }
        StartCoroutine(InitialDelay());
    }

    void GetRandomDoor(int amount)
    {
        for(int i = 1; i <= amount; i++)
        {
            Door door = doors[Random.Range(0, doors.Count)];
            door.GetComponent<Door>().StartOpening();
        }
    }

    public IEnumerator StartDoors(float cooldown)
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            GetRandomDoor(1);
        }
    }

    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("Stay indoors!");
        yield return new WaitForSeconds(3f);
        StartCoroutine(StartDoors(cooldown));
    }

}
