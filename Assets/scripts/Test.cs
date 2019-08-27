using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject canvas;

    private PauseController pauseController;

    private Rigidbody2D rb2D;

    private Stats stats;

    private Vector2 originPoint;

    private Vector2 inputVelocity = Vector2.zero;

    private bool inputZeroPushed = false;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        pauseController = canvas.GetComponent<PauseController>();
    }

    void Update() {
        Vector2 velocity = new Vector2(0, 0);
        if (Input.GetMouseButtonDown(0) && !inputZeroPushed) {
            originPoint = Input.mousePosition;
            inputZeroPushed = true;
        }

        if (inputZeroPushed) {
            calculateVelocity();
        }

        if (Input.GetMouseButtonUp(0) && inputZeroPushed) {
            inputZeroPushed = false;
            inputVelocity = Vector2.zero;
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
            stats.currentVelocity += velocity;
        } else {
            stats.currentVelocity += inputVelocity;
        }
    }

    void OnDestroy() {
        pauseController.gameOver();
    }

    void calculateVelocity() {
        Vector2 mouseDirection = originPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x);
        inputVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * stats.speed;
    }
}
