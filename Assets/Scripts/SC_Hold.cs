using UnityEngine;

public class SC_Hold : MonoBehaviour
{
    bool holding = false;
    public GameObject dogInHand = null;
    public GameObject nearestDogInRange = null;
    public float speed = 0;

    private void Start() 
    {
        speed = transform.GetComponent<SC_TPSController>().speed;    
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && !holding && nearestDogInRange)
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
                transform.GetComponent<SC_TPSController>().speed = speed*0.6f; 
        }
        else if (Input.GetKeyUp(KeyCode.E) && dogInHand)
        {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                dogInHand.GetComponent<Rigidbody>().isKinematic = false;
                dogInHand.GetComponent<Rigidbody>().detectCollisions = true;
                dogInHand.transform.parent = GameObject.Find("Dogs").transform;
                holding = false;
                dogInHand = null;
                transform.GetComponent<SC_TPSController>().speed = speed;
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

    public bool isHolding()
    {
        return holding;
    }
}