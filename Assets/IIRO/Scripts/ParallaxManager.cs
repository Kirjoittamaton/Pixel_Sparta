using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();
    public Transform playerTransform;
    public float smoothing = 1f;

    private Vector3 previousPlayerPosition;

    private void Start()
    {
        previousPlayerPosition = playerTransform.position;
    }

    private void Update()
    {
        Vector3 playerMovement = playerTransform.position - previousPlayerPosition;

        foreach (ParallaxLayer layer in parallaxLayers)
        {
            float parallaxFactor = layer.parallaxFactor;
            Vector3 parallaxTarget = layer.layerTransform.position + playerMovement * parallaxFactor;
            layer.layerTransform.position = Vector3.Lerp(layer.layerTransform.position, parallaxTarget, smoothing * Time.deltaTime);
        }

        previousPlayerPosition = playerTransform.position;
    }
}

[System.Serializable]
public class ParallaxLayer
{
    public Transform layerTransform;
    public float parallaxFactor = 1f;
}