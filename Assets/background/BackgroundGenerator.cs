using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public Vector2 start;
    public Vector2 end;

    public int number;

    public GameObject backgroundStarPrefab;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < number; i++) {
            Vector2 position = new Vector2(Random.Range(start.x, end.x), Random.Range(start.y, end.y));
            GameObject backgroundStar = Instantiate(backgroundStarPrefab, position, Quaternion.identity);
            backgroundStar.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
