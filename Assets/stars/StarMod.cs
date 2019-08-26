using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMod : MonoBehaviour {

    public float minMassMod = 0.8f;

    public float maxMassMod = 1.8f;

    public float minSpeed = 0f;

    public float maxSpeed = 100f;


    void Start() { 
        Stats stats = GetComponent<Stats>();
        if (stats == null) {
            throw new System.Exception("No Stats defined");
        }

        stats.setMass(stats.mass * Random.Range(minMassMod, maxMassMod));
        float modSpeed = Random.Range(minSpeed, maxSpeed);
        stats.speed += modSpeed;

        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        stats.stableVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * modSpeed;
    }

    void Update() {
    }

}
