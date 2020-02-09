using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    public GameObject ship = new GameObject();

    public void SelectSubmarine()
    {
        Instantiate(ship, transform.parent);
    }
}
