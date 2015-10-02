using UnityEngine;
using System.Collections;


public class rotator : MonoBehaviour {

   // private double value = Random.value;

    private Vector3 direction = new Vector3 (5, 0, 5);
    private Vector3 offset1;
    private Vector3 offset2;

    private GameObject wall;
    private Vector3 center = new Vector3 (0, 0, 0);

    void Update () {
        
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        float x = direction.x;
        float z = direction.z;

        if (other.gameObject.CompareTag("Wall"))
        {


            if (x > 0 && z > 0)
            {
                direction.x *= -1;
                offset1 = center - other.transform.position + direction;
                offset2 = center - other.transform.position - direction;
                if (offset1.magnitude < offset2.magnitude)
                {
                    direction.z *= -1;
                    direction.x *= -1;
                }
            }

            else if (x < 0 && z > 0)
            {
                direction.z *= -1;
                offset1 = center - other.transform.position + direction;
                offset2 = center - other.transform.position - direction;
                if (offset1.magnitude < offset2.magnitude)
                {
                    direction.z *= -1;
                    direction.x *= -1;
                }

            }

            else if (x < 0 && z < 0)
            {
                direction.x *= -1;
                offset1 = center - other.transform.position + direction;
                offset2 = center - other.transform.position - direction;
                if (offset1.magnitude < offset2.magnitude)
                {
                    direction.z *= -1;
                    direction.x *= -1;
                }
            }


            else if (x > 0 && z < 0)
            {
                direction.z *= -1;
                offset1 = center - other.transform.position + direction;
                offset2 = center - other.transform.position - direction;
                if (offset1.magnitude < offset2.magnitude)
                {
                    direction.z *= -1;
                    direction.x *= -1;
                }
            }

        }
    }
}
