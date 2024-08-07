using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDrag : MonoBehaviour
{
    public GameObject tracker;
    public GameObject monitor;
    public GameObject app; // Reference to the cube GameObject
    public GameObject yt;
    public GameObject plant;
    public GameObject cup;
    public LineRenderer lineRenderer;
    public Material rayOne;
    public Material rayTwo;

    public Mesh cube;

    private bool isGrabbing = false;
    private GameObject grabbedObject = null; // To keep track of the currently grabbed object
    private RaycastHit _hit; // Declaring _hit variable
    private KeyCode grabKey = KeyCode.Mouse3; // Key to initiate grabbing
    private KeyCode resetKey = KeyCode.Mouse4; // Key to reset position and properties

    private const float Speed = 4f;

    void Update()
    {
        Vector3 trackerPosition = tracker.transform.position;
        Vector3 trackerForward = tracker.transform.right;

        if (Physics.Raycast(trackerPosition, trackerForward, out _hit, 25))
        {
            GameObject hitObject = _hit.collider.gameObject;
            if (!isGrabbing && (hitObject.CompareTag("app") || hitObject.CompareTag("yt") || hitObject.CompareTag("plant") || hitObject.CompareTag("cup")))
            {
                HandleObjectInteraction(hitObject, hitObject.tag);

                if (Input.GetKey(grabKey))
                {
                    if (!isGrabbing)
                    {
                        isGrabbing = true;
                        grabbedObject = hitObject;
                        lineRenderer.material = rayTwo;
                        if (_hit.collider != null)
                            _hit.collider.transform.SetParent(tracker.transform);
                    }
                }
            }
        }

        if (isGrabbing)
        {
            if (!Input.GetKey(grabKey))
            {
                isGrabbing = false;
                lineRenderer.material = rayOne;
                if (grabbedObject != null)
                {
                    grabbedObject.transform.SetParent(null);
                    grabbedObject = null;
                }
            }
        }
    }

    private void HandleObjectInteraction(GameObject test, string name)
    {
        if (Input.GetKeyDown(resetKey))
        {
            ResetObject(test, name);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            test.transform.position += tracker.transform.right * Speed * Time.deltaTime;
        }
        else if (scroll < 0f)
        {
            test.transform.position -= tracker.transform.right * Speed * Time.deltaTime;
        }
    }

    private void ResetObject(GameObject test, string name)
    {
        Vector3 localPosition;
        Quaternion localRotation = Quaternion.identity;
        Vector3 localScale = new Vector3(0.05f, 0.1f, 2f);

        if (name == "app")
        {
            localPosition = new Vector3(0.42f, -0.37f, 0.02f);
        }
        else if (name == "yt")
        {
            localPosition = new Vector3(0.42f, -0.20f, 0.02f);
        }
        else if (name == "plant")
        {
            localPosition = new Vector3(-0.42f, -0.20f, 0.02f);
            if (test.GetComponent<MeshFilter>() != null && cube != null)
            {
                test.GetComponent<MeshFilter>().mesh = cube;
            }
        }
        else
        {
            localPosition = new Vector3(-0.42f, -0.37f, -0.02f);
            if (test.GetComponent<MeshFilter>() != null && cube != null)
            {
                test.GetComponent<MeshFilter>().mesh = cube;
            }
        }

        test.transform.SetParent(monitor.transform);
        test.transform.localPosition = localPosition;
        test.transform.localRotation = localRotation;
        test.transform.localScale = localScale;
        test.transform.tag = "Test";

        Texture2D texture = Resources.Load<Texture2D>(name + "_texture"); // Assume textures are named as 'app_texture', etc.
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.mainTexture = texture;
        Renderer renderer = test.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
    }
}
