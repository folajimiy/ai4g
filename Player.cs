using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    private Controller gameController;

    public float speed = 3f;


    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    void Start()
    {
        gameController = FindObjectOfType<Controller>();
        TeleportObjectToRandomLocation(RandomDirection());
    }

    void Update()
    {
        if (transform.position.y < -1)
        {
            // Handle collision between the cylinder and a wall
            Debug.Log("agent enetrs trap");
            Controller.scores[0] -= 3;
            TeleportObjectToRandomLocation(RandomDirection());
        }



    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        gameController.HandleCollision(gameObject, collision.gameObject);
    }

    public  Vector3 RandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Vector3(x, 0, z).normalized;
    }



    void TeleportObjectToRandomLocation(Vector3 direction)
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        transform.position = new Vector3(x, 0.5f, z);
        direction = RandomDirection();
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
