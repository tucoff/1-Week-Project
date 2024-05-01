using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{
    public int life = 100;
    public TMP_Text text;

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Sheep")
        {
            life -= 10;
            text.text = "Life: " + life;
            GameObject.Destroy(col.gameObject);
        }
    }

    private void FixedUpdate() {
        text.text = "Life: " + life;
        
        if (life <= 0)
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
