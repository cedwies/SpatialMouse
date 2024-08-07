using UnityEngine;
using TMPro;
using Oculus.Interaction.PoseDetection;

public class VirtualMonitorInteraction : MonoBehaviour
{
    public GameObject mouse;
    public GameObject monitor;
    public GameObject app; // Reference to the cube GameObject

    public GameObject yt;
    public GameObject plant;
    public GameObject cup;

    public Mesh plantMesh;
    public Mesh CoffeCup;



    private float sensitivity = 0.001f;
    private Vector3 previousMousePosition;
    private Renderer mouseRenderer;
    private bool isMouseClicked = false;
    private bool isDraggingApp = false;
    private bool isDraggingyt = false;
    private bool isDraggingplant = false;
    private bool isDraggingcup = false;
    private Vector3 cubeOffset;

    private string last = "none";

    void Start()
    {
        previousMousePosition = Input.mousePosition;
        mouseRenderer = mouse.GetComponent<Renderer>();

    }

    void Update()
    {
        Vector3 mouseDelta = Input.mousePosition - previousMousePosition;

        Vector3 monitorSpaceDelta = new Vector3(mouseDelta.x, mouseDelta.y, 0) * sensitivity;


        mouse.transform.localPosition += monitor.transform.TransformDirection(monitorSpaceDelta);


        previousMousePosition = Input.mousePosition;

        if (!isDraggingApp && !isDraggingyt && !isDraggingplant && !isDraggingcup)
        {
            Vector3 localPos = mouse.transform.localPosition;
            localPos.x = Mathf.Clamp(localPos.x, -monitor.transform.localScale.x / 1.9f, monitor.transform.localScale.x / 1.9f);
            localPos.y = Mathf.Clamp(localPos.y, -monitor.transform.localScale.y / 1.9f, monitor.transform.localScale.y / 1.9f);
            mouse.transform.localPosition = localPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMouseClicked = true;
            mouseRenderer.material.color = Color.red;

            float distance = Vector3.Distance(mouse.transform.position, app.transform.position);
            float distanceyt = Vector3.Distance(mouse.transform.position, yt.transform.position);
            float distanceplant = Vector3.Distance(mouse.transform.position, plant.transform.position);
            float distancecup = Vector3.Distance(mouse.transform.position, cup.transform.position);

            if (distance < 0.04f)
            {
                isDraggingApp = true;
                cubeOffset = app.transform.position - mouse.transform.position;
                last = "sa";
            }
            else if (distanceyt < 0.04f)
            {
                isDraggingyt = true;
                cubeOffset = yt.transform.position - mouse.transform.position;
                last = "yt";
            }
            else if (distanceplant < 0.04f)
            {
                isDraggingplant = true;
                cubeOffset = plant.transform.position - mouse.transform.position;
                last = "plant";
            }
            else if (distancecup < 0.04f)
            {
                isDraggingcup = true;
                cubeOffset = cup.transform.position - mouse.transform.position;
                last = "cup";
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseClicked = false;
            mouseRenderer.material.color = Color.white;

            isDraggingyt = false;
            isDraggingApp = false;
            isDraggingplant = false;
            isDraggingcup= false;

            if (!IsMouseInsideMonitor())
            {
                Vector3 currentPosition = mouse.transform.localPosition;
                mouse.transform.localPosition = new Vector3(0, 0, currentPosition.z);
                if (last == "sa")
                {


                    app.transform.localScale = new Vector3(0.6f, 0.7f, 0.3f);
                    app.transform.parent = null;

                    app.tag = "app";



                    Texture2D texture = Resources.Load<Texture2D>("2safari-start-page-customize-wallpaper");

                    // Create a new material
                    Material newMaterial = new Material(Shader.Find("Standard")); // Use appropriate shader here

                    // Assign the texture to the main texture property of the material
                    newMaterial.mainTexture = texture;

                    // Apply the new material to the renderer of 'app'
                    Renderer renderer = app.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = newMaterial;
                    }

                }
                else if (last == "yt")
                {

                    yt.transform.localScale = new Vector3(0.6f, 0.7f, 0.3f);
                    yt.transform.parent = null;

                    yt.tag = "yt";


                    Texture2D texture = Resources.Load<Texture2D>("Screenshot (2)");

                    // Create a new material
                    Material newMaterial = new Material(Shader.Find("Standard")); // Use appropriate shader here

                    // Assign the texture to the main texture property of the material
                    newMaterial.mainTexture = texture;

                    // Apply the new material to the renderer of 'app'
                    Renderer renderer = yt.GetComponent<Renderer>();
                    if (renderer != null)

                    {
                        renderer.material = newMaterial;
                    }

                }
                else if (last == "plant")
                {
                    // Reset scale, parent, and tag
                    plant.transform.localScale = new Vector3(0.4f, 0.7f, 30f); // Adjust scale as needed
                    plant.transform.parent = null;
                    plant.tag = "plant";
                    plant.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                    MeshFilter meshFilter = plant.GetComponent<MeshFilter>(); // Access MeshFilter component of the 'plant' GameObject

                    if (meshFilter != null && plantMesh != null)
                    {
                        // Assign the new mesh to the MeshFilter
                        meshFilter.mesh = plantMesh;
                    }
                    Renderer renderer = plant.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Create a new material and set its color to green
                        Material newMaterial = new Material(Shader.Find("Standard"));
                        newMaterial.color = Color.green;

                        // Assign the material to the renderer
                        renderer.material = newMaterial;
                    }
                }
                else if (last == "cup")
                {
                    // Reset scale, parent, and tag
                    cup.transform.localScale = new Vector3(1.6f, 2.8f, 120f); // Adjust scale as needed
                    cup.transform.parent = null;
                    cup.tag = "cup";
                    cup.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                    MeshFilter meshFilter = cup.GetComponent<MeshFilter>(); // Access MeshFilter component of the 'cup' GameObject

                    if (meshFilter != null && CoffeCup != null)
                    {
                        // Assign the new mesh to the MeshFilter
                        meshFilter.mesh = CoffeCup;
                    }
                    Renderer renderer = cup.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Create a new material and set its color to green
                        Material newMaterial = new Material(Shader.Find("Standard"));
                        newMaterial.color = Color.white;

                        // Assign the material to the renderer
                        renderer.material = newMaterial;
                    }

                    // Adjust the collider size and center
                    BoxCollider boxCollider = cup.GetComponent<BoxCollider>();
                    if (boxCollider == null)
                    {
                        // Add a BoxCollider if the cup doesn't have one
                        boxCollider = cup.AddComponent<BoxCollider>();
                    }

                    // Adjust the size and center of the BoxCollider to better fit the cup
                    boxCollider.size = new Vector3(0.1f, 0.08f, 0.14f); // Adjust these values as needed
                    boxCollider.center = new Vector3(0f, 0.03f, 0f); // Adjust the center if needed

                }


            }
        }

        if (isDraggingApp)
        {
            Vector3 newPosition = mouse.transform.position + cubeOffset;
            app.transform.position = newPosition;
        }

        if (isDraggingplant)
        {
            Vector3 newPosition = mouse.transform.position + cubeOffset;
            plant.transform.position = newPosition;
        }

        if (isDraggingyt)
        {
            Vector3 newPosition = mouse.transform.position + cubeOffset;
            yt.transform.position = newPosition;
        }
        if (isDraggingcup)
        {
            Vector3 newPosition = mouse.transform.position + cubeOffset;
            cup.transform.position = newPosition;
        }
    }


    private bool IsMouseInsideMonitor()
    {
        Vector3 mousePosition = mouse.transform.localPosition;
        Vector3 monitorSize = monitor.transform.localScale;

        if (Mathf.Abs(mousePosition.x) <= monitorSize.x / 1.8f && Mathf.Abs(mousePosition.y) <= monitorSize.y / 1.8f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}