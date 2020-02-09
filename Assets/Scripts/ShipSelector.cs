using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    public GameObject ship = new GameObject();
    public GameObject dispaySpawn = new GameObject();

    public void SelectSubmarine()
    {
        Instantiate(ship, dispaySpawn.transform);
        
    }
}
