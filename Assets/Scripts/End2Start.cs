using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End2Start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Change"))
        {
            Debug.Log("change scene");
            Invoke("ChangeScene", 1f);
        }
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene("start");
    }
}
