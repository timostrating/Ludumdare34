using UnityEngine;
using System.Collections.Generic;

public class Parallexing : MonoBehaviour {

    private List<Transform> backgrounds = new List<Transform>();
    private float[] parallaxScales;         // The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;			// How smooth the parallax is going to be. Make sure to set this above 0


    private Transform cam;
    private Vector3 previousCamPos;



    void Awake() {
        cam = Camera.main.transform;
    }

    void Start () {
        Recalculate();
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Count];
        for (int i = 0; i < backgrounds.Count; i++) {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update () {

        for (int i = 0; i < backgrounds.Count; i++) {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }

    void Recalculate() {
        backgrounds.Clear();

        for (int i = 0; i < gameObject.transform.childCount; i++) {
            backgrounds.Add(gameObject.transform.GetChild(1));
        }
    }
}
