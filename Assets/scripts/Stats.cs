using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    private float radius = 0f;

    public float massRadiusChange = 1f;

    public float mass = 1f;

    public float speed = 0f;

    public Vector2 currentVelocity = Vector2.zero;

    public Vector2 stableVelocity = Vector2.zero;

    private Circle circle;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rb2D;

    private Gravity gravity;
    void Start() {
        circle = GetComponent<Circle>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        gravity = GetComponentsInChildren<Gravity>()[0];

        calculateRadius();
        updateStats();
    }

    void calculateRadius() {
        float tempRadius = massRadiusChange * mass;
        if (tempRadius != radius) {
            radius = tempRadius;
        }
    }

    public void setMass(float mass) {
        this.mass = mass;
        calculateRadius();
    }

    void updateStats() {
        if (circle != null) {
            circle.radius = radius;
        }
        if (circleCollider2D != null) {
            circleCollider2D.radius = radius;
        }

        currentVelocity += stableVelocity;
        if (currentVelocity != Vector2.zero) {
            rb2D.MovePosition(rb2D.position + currentVelocity * Time.fixedDeltaTime);
            currentVelocity = Vector2.zero;
        }

        float radiusCheck = mass * 5;
        if (radiusCheck != gravity.radius) {
            gravity.radius = radiusCheck;
        }

        if (rb2D.velocity != Vector2.zero) {
            rb2D.velocity = Vector2.zero;
        }
    }

    void Update() {
        updateStats();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Stats otherStats = other.gameObject.GetComponent<Stats>();
        if (otherStats != null) {
            if (mass > otherStats.mass) {
                mass += otherStats.mass * 0.2f;
                calculateRadius();
            } else {
                Destroy(gameObject);
            }
        }

        if (gameObject.name != "Player" && other.gameObject.name == "Limits") { //Reflection against walls
            stableVelocity = Vector2.Reflect(stableVelocity, other.contacts[0].normal);
        }
    }
}
