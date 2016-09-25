using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector3 moveVector;
    public float destroyAfterSec;

    private float startTime;
    private bool firstTime = true;


    void Update() {
        if (firstTime) {
            startTime = Time.time;
            firstTime = false;
        }

        transform.Translate(moveVector * Time.deltaTime);

        if (startTime + destroyAfterSec < Time.time) {
            Destroy(gameObject);
        }
    }
}
