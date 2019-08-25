using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float radius = 5f;

    private List<GravityAfflictedEntity> pullable = new List<GravityAfflictedEntity>();

    private CircleCollider2D circleCollider2D;

    void Start() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update() {
        if (circleCollider2D.radius != radius) {
            circleCollider2D.radius = radius;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Stats stats = other.gameObject.GetComponent<Stats>();
        if (stats != null) {
            GravityBuff buff = other.gameObject.AddComponent<GravityBuff>();
            buff.origin = gameObject.transform.parent.gameObject;
            pullable.Add(new GravityAfflictedEntity(other.gameObject, buff));
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        GravityAfflictedEntity gae = null;
        for (int i = 0; i < pullable.Count; i++) {
            GravityAfflictedEntity gaeAux = pullable[i];
            if (other.gameObject == gaeAux.gameObject) {
                gae = gaeAux;
                pullable.RemoveAt(i);
                i = pullable.Count;
            }
        }
        if (gae != null) {
            Destroy(gae.gravityBuff);
        }
    }

    private class GravityAfflictedEntity {
        public GameObject gameObject;
        public GravityBuff gravityBuff;

        public GravityAfflictedEntity() {}

        public GravityAfflictedEntity(GameObject gameObject, GravityBuff gravityBuff) {
            this.gameObject = gameObject;
            this.gravityBuff = gravityBuff;
        }
    }
}
