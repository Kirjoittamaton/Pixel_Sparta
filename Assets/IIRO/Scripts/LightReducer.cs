using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightReducer : MonoBehaviour
{
    public float reductionRate = 0.1f;
    public float reductionInterval = 10f;

    private Light2D globalLight;
    private float nextReductionTime;

    void Start()
    {
        globalLight = GetComponent<Light2D>();
        nextReductionTime = Time.time + reductionInterval;
    }

    void Update()
    {
        if (Time.time >= nextReductionTime)
        {
            ReduceLightIntensity();
            nextReductionTime = Time.time + reductionInterval;
        }
    }

    void ReduceLightIntensity()
    {
        globalLight.intensity -= reductionRate;

        // Ensure the intensity doesn't go below zero
        globalLight.intensity = Mathf.Max(0f, globalLight.intensity);
    }
}