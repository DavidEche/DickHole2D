using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != transform.parent.gameObject.name)
        {
            transform.parent.GetComponent<PlayerMovement>().itsgrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("exit");
        transform.parent.GetComponent<PlayerMovement>().itsgrounded = false;
    }
}
