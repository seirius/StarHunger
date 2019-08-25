using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private Rigidbody2D rb2D;

    private Stats stats;

    private Vector2 originPoint;

    private Vector2 inputVelocity = Vector2.zero;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
    }

    void Update() {
        Vector2 velocity = new Vector2(0, 0);
        if (Input.GetMouseButtonDown(0)) {
            originPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            Vector2 mouseDirection = originPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x);
            inputVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * stats.speed;
        }

        if (Input.GetKey(KeyCode.W)) {
            velocity += new Vector2(0, stats.speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            velocity += new Vector2(0, -stats.speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            velocity += new Vector2(-stats.speed, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            velocity += new Vector2(stats.speed, 0);
        }

        if (velocity != Vector2.zero) {
            stats.currentVelocity += velocity * Time.fixedDeltaTime;
        } else {
            stats.currentVelocity += inputVelocity * Time.fixedDeltaTime;
        }
    }
}
