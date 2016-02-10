using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playercontroller : MonoBehaviour {

    public float Speed;
    public Text countText;
    public Text wintext;
    public Text TimeText;

    rotator rotator;

    public Camera Main;
    public Camera Central;

    public AudioSource ping;
    public AudioSource clap;

    private float timecount;
    private Vector3 pickupposition = new Vector3 (0,.5f,0);
    private Vector3 ballposion = new Vector3(0, .5f, -4);
    private Rigidbody rb;
    private int count;
    private bool called = false;
    private GameObject[] pickup;


    void Start () {

        if (!called)
        {
            pickup = GameObject.FindGameObjectsWithTag("Pick Up");
            called = true;
        }

        foreach (GameObject item in pickup)
        {
            item.SetActive(true);
            item.transform.position = pickupposition;
        }

        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = ballposion;

        count = 0;
        SetCountText();
        wintext.text = "";
        timecount = 0;

        clap.Stop();  
	}

    void Update() {
        if (count < 13)
        {
            timecount += Time.deltaTime;
            TimeText.text = timecount.ToString("f2");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Start();
        }

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
            ping.Play();
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
        if (count > 12)
        {
            wintext.text = "You Win!\n" + timecount.ToString("f2") + " s";
            clap.Play();
        }
    }
}
