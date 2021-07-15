using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public float shootingForce = 100f;
    public float turnSpeed = 40f;

    public Transform spawnPoint;

    

    void OnEnable()
    {
        InvokeRepeating("ShootAtPlayer", 3f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!Robot())
        {
            return;
        }
        else
        {
            Vector3 targetDirection = Robot().transform.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(direction);

        }
    }

    private void ShootAtPlayer()
    {
        if (Robot())
        {
            GameObject _cannonball = Instantiate(cannonBall, spawnPoint.position, spawnPoint.rotation);
            _cannonball.GetComponent<Rigidbody>().AddForce(shootingForce * cannonBall.transform.forward);

            Destroy(_cannonball, 2f);
        }
    }

    private GameObject Robot()
    {
        RobotMovement robot = FindObjectOfType<RobotMovement>();

        if (robot)
        {
            return robot.gameObject;
        }

        return default;
    }
}
