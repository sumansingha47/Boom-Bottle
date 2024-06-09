using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("You Quit The Application");
        }
    }
}
