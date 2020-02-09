using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
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
    }

    void LevelDebug()
    {

        if (Input.GetKey(KeyCode.L))
        {
            LoadnextLevel();

        }
       
    }


}
