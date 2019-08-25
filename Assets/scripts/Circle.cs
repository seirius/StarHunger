using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Circle : MonoBehaviour {

    public float thetaScale = 0.01f;
    public float radius = 3f;
    public float lineWidth = 0.1f;

    public float depth = 0f;


    private int size;
    private LineRenderer lineRenderer;

    void Start() { 
        float sizeValue = (2.0f * Mathf.PI) / thetaScale;
        size = (int) ((1f / thetaScale) + 1f);
        size++;
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null) {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = size;
    }

    void Update() {
        float theta = 0f;
        for (int i = 0; i < size; i++) {
            theta += (2.0f * Mathf.PI * thetaScale);
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            lineRenderer.SetPosition(i, new Vector3(x, y, depth));
        }
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

}
