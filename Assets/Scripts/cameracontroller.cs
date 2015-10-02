using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {

    public GameObject Ball;

    private Vector3 offset;

	void Start () {
        offset = transform.position - Ball.transform.position;
	}

    void LateUpdate () {
        transform.position = Ball.transform.position + offset;
	}
}
