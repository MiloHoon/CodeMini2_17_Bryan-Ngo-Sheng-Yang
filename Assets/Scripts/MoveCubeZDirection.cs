using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeZDirection : MonoBehaviour
{
    float speed = 5.0f;
    bool isForward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 25.0f && isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (transform.position.z > 1 && !isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        else
        {
            isForward = !isForward;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Set parent under Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Remove parent under Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
