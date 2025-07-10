using UnityEngine;

public class LightObject : MonoBehaviour
{
    GameObject player = null;
    bool playerDetected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            detectPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            playerDetected = false;
        }
    }

    void detectPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20.0f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerDetected = true;
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red, 1.0f);
            }
            else
            {
                playerDetected = false;
            }
        }
    }
}
