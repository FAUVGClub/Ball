using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {

    public GameObject Ball;
    public Camera other;
    public Camera me;

    float smoothing = 5f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Ball.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = Ball.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}