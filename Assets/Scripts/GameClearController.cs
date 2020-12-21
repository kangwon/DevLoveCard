using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
