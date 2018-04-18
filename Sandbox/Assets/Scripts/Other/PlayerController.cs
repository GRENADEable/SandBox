using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerRotation;

    public GameObject prefab;
    public Transform spawnPoint;
    public float prefabSpeed;

    public bool isAlive;


    private void Start()
    {
        isAlive = true;
    }
    // Update is called once per frame
    void Update ()
    {
        float translation = Input.GetAxis("Vertical") * playerSpeed;
        float rotation = Input.GetAxis("Horizontal") * playerRotation;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * prefabSpeed;
            Destroy(bullet, 0.5f);
        }

        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }

    /*public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);
    }*/
}
