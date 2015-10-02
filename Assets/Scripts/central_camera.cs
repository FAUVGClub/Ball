using UnityEngine;
using System.Collections;

public class central_camera : MonoBehaviour {
    public Camera other;
    public Camera me;

    void Update()
    {
        if (other.isActiveAndEnabled == false)
            me.enabled = true;
    }
}
