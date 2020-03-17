using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<Door> doors = new List<Door>();
    float cooldown = 2f;
    int amount = 0;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            doors.Add(t.gameObject.GetComponent<Door>());
        }
        StartCoroutine(StartDoors(cooldown));
    }

    void GetRandomDoor(int amount)
    {
        for(int i = 1; i <= amount; i++)
        {
            Door door = doors[Random.Range(0, doors.Count)];
            door.GetComponent<Door>().StartOpening();
        }
    }

    private void Update()
    {
        Debug.Log(cooldown);
    }

    public IEnumerator StartDoors(float cooldown)
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            GetRandomDoor(1);
        }
    }

}
