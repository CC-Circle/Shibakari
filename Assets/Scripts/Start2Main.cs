using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start2Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start"))
        {
            Debug.Log("change scene");
            Invoke("ChangeScene", 1f);
        }
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene("main");
    }
}
