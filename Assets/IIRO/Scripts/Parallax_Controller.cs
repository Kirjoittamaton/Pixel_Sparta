using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Controller : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    [SerializeField] private Transform cameraPosition;

    public float startXPos;

    // Start is called before the first frame update
    void Start()
    {
        startXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cameraPosition.position.x * speed;
        transform.position = new Vector3(startXPos + distance, transform.position.y, transform.position.z);
    }
}
