using UnityEngine;

public class SC_Hold : MonoBehaviour
{
    bool holding = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && !holding)
        {
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
            holding = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
            holding = false;
        }
    }
}