using UnityEngine;
using System.Collections;

public class flyHigh : MonoBehaviour
{

    // Variables for speed and hight
    private float minHeight = -0.01000381f;
    private float maxHeight = 25f;
    private float boxSpeed = 0.03f;

    private MeshRenderer mesh;
    private Transform trans;
    private bool activated;
    private GameObject obj;
    private Transform boxTransform;

    public Transform head;
    public GameObject VRbox;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        trans = GetComponent<Transform>();
        boxTransform = VRbox.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((trans.position.y > (head.position.y + 0.15f) && (boxTransform.transform.position.y <= maxHeight)))
        {
            boxTransform.Translate(0, boxSpeed, 0, Space.Self);
        }
        if ((trans.position.y <= head.position.y + 0.15f) && (boxTransform.transform.position.y >= minHeight))
        {
            boxTransform.Translate(0, -boxSpeed, 0, Space.Self);
        }
    }
}
