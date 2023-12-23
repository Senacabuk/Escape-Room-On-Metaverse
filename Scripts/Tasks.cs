using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tasks : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        playerData = ScriptableObject.CreateInstance<PlayerData>();
        playerData.lastPosition = transform.position;
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerData.previousScene >= 0) // Check if a valid previous scene index is stored
            {
                SceneManager.LoadScene(playerData.previousScene);
                GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
                mainCamera.transform.position = playerData.lastPosition;
            }
            else
            {
                UnityEngine.Debug.Log("No previous scene found.");
            }
        }
    }

    void OnMouseDown()
    {
        playerData.previousScene = SceneManager.GetActiveScene().buildIndex;
        playerData.lastPosition = transform.position;

        SceneManager.LoadScene(7);
    }
}