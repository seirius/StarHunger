using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBuff : Buff {

    public GameObject origin;

    public Vector2 velocity;
    void Update() {
        if (velocity != null) {
            Stats stats = GetComponent<Stats>();
            Stats originStats = origin.GetComponent<Stats>();
            if (stats != null && originStats != null) {
                Vector2 originPosition = origin.transform.position;
                Vector2 thisPosition = gameObject.transform.position;
                Vector2 directionVector = originPosition - thisPosition;
                float angle = Mathf.Atan2(directionVector.y, directionVector.x);
                velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) 
                    * (originStats.mass / Vector2.Distance(thisPosition, originPosition));
                stats.currentVelocity = stats.currentVelocity + velocity;
            }
        }
    }
}
