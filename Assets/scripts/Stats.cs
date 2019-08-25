using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public float radius = 1.2f;

    public float mass = 1f;

    public float speed = 0f;

    public Vector2 currentVelocity = Vector2.zero;

    private Circle circle;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rb2D;

    private Gravity gravity;
    void Start() {
        circle = GetComponent<Circle>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        gravity = GetComponentsInChildren<Gravity>()[0];
    }

    void Update() {
        if (circle != null) {
            circle.radius = radius;
        }
        if (circleCollider2D != null) {
            circleCollider2D.radius = radius;
        }

        if (currentVelocity != Vector2.zero) {
            rb2D.MovePosition(rb2D.position + currentVelocity * Time.fixedDeltaTime);
            currentVelocity = Vector2.zero;
        }
        float radiusCheck = mass * 2;

        if (radiusCheck != gravity.radius) {
            gravity.radius = radiusCheck;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Stats otherStats = other.gameObject.GetComponent<Stats>();
        if (otherStats != null) {
            if (mass > otherStats.mass) {
                mass += otherStats.mass * 0.2f;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
