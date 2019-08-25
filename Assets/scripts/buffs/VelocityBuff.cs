using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBuff : Buff {

    public Vector2 velocity;
    void Update() {
        if (velocity != null) {
            Stats stats = GetComponent<Stats>();
            if (stats != null) {
                stats.currentVelocity = stats.currentVelocity + velocity;
            }
        }
    }
}
