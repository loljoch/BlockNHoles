using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int amountNeededToOpenDoor;
    public int amountHit;
    private SpawnHole spawner;

    private void Start()
    {
        spawner = GetComponentInChildren<SpawnHole>();
        spawner.SpawnHoles(amountNeededToOpenDoor);
        GameManager.Instance.gate = GetComponent<Gate>();
    }

    public void UpdateAmountHit()
    {
        amountHit++;
        if(amountHit >= amountNeededToOpenDoor)
        {
            OnGateClear();
        }
    }

    public void OnGateClear()
    {
        amountHit = 0;

        spawner.ResetHoles();
        spawner.SpawnHoles(amountNeededToOpenDoor);
    }


}
