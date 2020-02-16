using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipSelector : MonoBehaviour
{
    public static ShipSelector Instance;

    public GameObject shipPlaceholder = new GameObject();
    public GameObject submarinePlaceholder = new GameObject();
    public GameObject realShip;
    public GameObject realSubmarine;
    public Canvas canvas;

    public GameObject activeShip;


   

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        activeShip = realShip;
    }


    public void SelectSubmarine()
    {
        activeShip = realSubmarine;
        Instantiate(submarinePlaceholder, canvas.transform);
        
    }


    public void SelectShip()
    {
        activeShip = realShip;
        Instantiate(shipPlaceholder, canvas.transform);

    }



}
