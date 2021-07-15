using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RobotMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
