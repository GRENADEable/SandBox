using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public Text scoreText;
    private float scoreCounter;
    public bool isRocketStart;
    public bool isCounterStarted;
    public bool isSphereTriggered;
    [Header("GameObject References")]
    public GameObject rocket;
    public GameObject sphere;
    public Rigidbody cube;
    [Header("Float References")]
    public float cubeFallDuration;
    public float sphereShrinkSpeed;
    [Header("Rocket Variables")]
    public float rocketSpeed;
    public float rocketRotation;

    void Start()
    {
        scoreCounter = 0;
        cube.GetComponent<Rigidbody>();
        scoreText.text = "HELLO";
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && hit.collider.tag == "Sphere" && isCounterStarted && scoreCounter >= cubeFallDuration)
        {
            Debug.Log(hit.collider);
            isSphereTriggered = true;
        }

        if (isCounterStarted)
        {
            scoreCounter += Time.deltaTime;
            scoreText.text = scoreCounter.ToString("f0");
            isRocketStart = true;

            if (scoreCounter >= cubeFallDuration)
            {
                cube.isKinematic = false;
            }
        }

        if (isRocketStart)
        {
            rocket.transform.Translate(transform.up * rocketSpeed * Time.deltaTime);
            if (scoreCounter >= 1.5f)
                rocket.transform.Rotate(0, 0, rocketRotation * Time.deltaTime);
            else
                rocket.transform.Rotate(0, 0, -rocketRotation * Time.deltaTime);
        }

        if (isSphereTriggered)
        {
            sphere.transform.localScale += new Vector3(-sphereShrinkSpeed, -sphereShrinkSpeed, -sphereShrinkSpeed) * Time.deltaTime;

            if (sphere.transform.localScale.x <= 0)
            {
                isCounterStarted = false;
                scoreText.text = "THE END";
                isSphereTriggered = false;
            }
        }
    }

    public void StartCounter()
    {
        isCounterStarted = true;
    }
}
