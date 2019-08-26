using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrik : MonoBehaviour {

    public Vector2 minLimit = new Vector2(-10, -10);
    public Vector2 maxLimit = new Vector2(10, 10);
    public int init = 10;
    public List<GameObject> stars = new List<GameObject>();

    public float spawnRatio = 2f;

    private float count = 0;

    void Start() {
        for (int i = 0; i < init; i++) {
            spawnStar();
        }
    }

    void Update() {
        count += Time.fixedDeltaTime;
        if (count >= spawnRatio) {
            count = 0;
            spawnStar();
        }
    }

    private void spawnStar() {
        int avaiableStars = stars.Count;
        if (avaiableStars > 0) {
            int starIndex = Random.Range(0, avaiableStars);
            float positionX = Random.Range(minLimit.x, maxLimit.x);
            float positionY = Random.Range(minLimit.y, maxLimit.y);
            Instantiate(stars[starIndex], new Vector2(positionX, positionY), Quaternion.identity, transform);
        }

    }
}
