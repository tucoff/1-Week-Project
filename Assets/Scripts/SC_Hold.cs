using UnityEngine;

public class SC_Hold : MonoBehaviour
{
    bool holding = false;
    public GameObject dogInHand = null;
    public GameObject nearestDogInRange = null;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && !holding)
        {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
                nearestDogInRange.transform.parent = transform.GetChild(0).GetChild(6);
                nearestDogInRange.transform.position = transform.GetChild(0).GetChild(6).position;
                nearestDogInRange.GetComponent<Rigidbody>().isKinematic = true;
                nearestDogInRange.GetComponent<Rigidbody>().detectCollisions = false;
                holding = true;
                dogInHand = nearestDogInRange.gameObject;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                dogInHand.GetComponent<Rigidbody>().isKinematic = false;
                dogInHand.GetComponent<Rigidbody>().detectCollisions = true;
                dogInHand.transform.parent = GameObject.Find("Dogs").transform;
                holding = false;
                dogInHand = null;
        }
    }

    private void OnTriggerStay(Collider col) {
        if (col.tag == "Dog")
        {
            float dist = Vector3.Distance(col.transform.position, transform.position);
            if (!nearestDogInRange) 
            {
                nearestDogInRange = col.gameObject;
            }
            else if (dist < Vector3.Distance(nearestDogInRange.transform.position, transform.position))
            {
                nearestDogInRange = col.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider col) {
        if (nearestDogInRange == col.gameObject)
        {
            nearestDogInRange = null;
        }
    }
}