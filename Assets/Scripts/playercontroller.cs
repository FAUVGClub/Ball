using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playercontroller : MonoBehaviour {

    public float Speed;
    public Text countText;
    public Text wintext;
    public Text TimeText;

    private float timecount;
    private Rigidbody rb;
    private int count;

	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        wintext.text = "";
        timecount = 0;   

	}

    void Update() {
        if (count < 13)
        {
            timecount += Time.deltaTime;
            TimeText.text = timecount.ToString("f2");
        }

        if (Input.GetKeyDown(KeyCode.Space))
              Application.LoadLevel(0);
            

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);
	}

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText () {
        countText.text = count.ToString();
        if (count > 12)
            wintext.text = "You Win!\n" + timecount.ToString("f2") + " s";
    }
}
