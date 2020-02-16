using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public GameObject spawnPoint;
    [SerializeField] float levelLoadDelay = 2f;
    public GameObject Ship = new GameObject();
    public enum shipStatus {started, notStarted }
    public shipStatus ship = shipStatus.started;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (ship == shipStatus.started)
        {
            spawnActiveShip();
        }
    }

    public void invokeLoadFirstLevel()
    {
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void invokeLevelLoad()
    {
        
        Invoke("LoadnextLevel", levelLoadDelay);
    }

    public void LoadnextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        ship = shipStatus.started;
    }

    void LevelDebug()
    {

        if (Input.GetKey(KeyCode.L))
        {
            LoadnextLevel();

        }
       
    }

    public void spawnActiveShip()
    {
        GameObject test = GameObject.Find("ShipSelector");
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        Ship = test.GetComponent<ShipSelector>().activeShip;
        Instantiate(Ship, spawnPoint.transform);
        ship = shipStatus.notStarted;
    }


}
