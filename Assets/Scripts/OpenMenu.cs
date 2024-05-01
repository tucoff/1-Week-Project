using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !GameObject.FindWithTag("Canvas").transform.GetChild(2).gameObject.activeInHierarchy)
        {
            GameObject.FindWithTag("Player").transform.GetComponent<SC_TPSController>().enabled = false;
            GameObject.FindWithTag("MainCamera").transform.GetComponent<SC_CameraCollision>().enabled = false;
            GameObject.FindWithTag("Canvas").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.FindWithTag("Canvas").transform.GetChild(3).gameObject.SetActive(true); 
            foreach(GameObject sheeps in GameObject.FindGameObjectsWithTag("Sheep"))
            {
                sheeps.GetComponent<SheepBehaviour>().enabled = false;
            }
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject.FindWithTag("Player").transform.GetComponent<SC_TPSController>().enabled = true;
            GameObject.FindWithTag("MainCamera").transform.GetComponent<SC_CameraCollision>().enabled = true;
            GameObject.FindWithTag("Canvas").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.FindWithTag("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            foreach(GameObject sheeps in GameObject.FindGameObjectsWithTag("Sheep"))
            {
                sheeps.GetComponent<SheepBehaviour>().enabled = true;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void CloseMenu()
    {
            GameObject.FindWithTag("Player").transform.GetComponent<SC_TPSController>().enabled = true;
            GameObject.FindWithTag("MainCamera").transform.GetComponent<SC_CameraCollision>().enabled = true;
            GameObject.FindWithTag("Canvas").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.FindWithTag("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            foreach(GameObject sheeps in GameObject.FindGameObjectsWithTag("Sheep"))
            {
                sheeps.GetComponent<SheepBehaviour>().enabled = true;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
    }
}
