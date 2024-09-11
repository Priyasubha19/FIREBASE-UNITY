/*using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public GameObject cubePrefab; // Reference to the cube prefab

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the cylinder based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // This function is called when another collider enters the trigger collider attached to this GameObject.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the square (you might want to use tags or layers here)
        if (other.gameObject.CompareTag("Square"))
        {
            // Destroy the square GameObject.
            Destroy(other.gameObject);

            // Create a big cuboid with multiple cubes at the same position and scale
            CreateCuboid();
        }
    }

    void CreateCuboid()
    {
        // Set the size of the original cube
        Vector3 originalCubeSize = Vector3.one;

        // Define the number of cubes in each dimension
        int numCubesX = 3;
        int numCubesY = 3;
        int numCubesZ = 3;

        // Calculate the spacing between cubes
        Vector3 spacing = originalCubeSize / numCubesX;

        // Calculate the position of the center of the cuboid
        Vector3 center = transform.position;

        // Instantiate cubes within a single cuboid at the original position with original scale
        for (int i = 0; i < numCubesX; i++)
        {
            for (int j = 0; j < numCubesY; j++)
            {
                for (int k = 0; k < numCubesZ; k++)
                {
                    // Calculate position for each cube at the center position
                    Vector3 cubePosition = center + new Vector3(i * spacing.x, j * spacing.y, k * spacing.z);

                    // Instantiate the cube prefab at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

                    // Set the local scale of the new cube to match the original scale
                    newCube.transform.localScale = originalCubeSize;
                }
            }
        }
    }
}
*/
/* same position but the size of the cube has changed
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public GameObject cubePrefab; // Reference to the cube prefab

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the cylinder based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // This function is called when another collider enters the trigger collider attached to this GameObject.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the square (you might want to use tags or layers here)
        if (other.gameObject.CompareTag("Square"))
        {
            // Store the position of the square before it was destroyed
            Vector3 squarePosition = other.gameObject.transform.position;

            // Destroy the square GameObject.
            Destroy(other.gameObject);

            // Create a big cuboid with multiple cubes at the same position and scale
            CreateCuboid(squarePosition);
        }
    }

    void CreateCuboid(Vector3 squarePosition)
    {
        // Set the size of the original cube
        Vector3 originalCubeSize = Vector3.one;

        // Define the number of cubes in each dimension
        int numCubesX = 3;
        int numCubesY = 3;
        int numCubesZ = 3;

        // Calculate the spacing between cubes
        Vector3 spacing = originalCubeSize / numCubesX;

        // Calculate the position of the center of the cuboid
        Vector3 center = squarePosition;

        // Instantiate cubes within a single cuboid at the original position with original scale
        for (int i = 0; i < numCubesX; i++)
        {
            for (int j = 0; j < numCubesY; j++)
            {
                for (int k = 0; k < numCubesZ; k++)
                {
                    // Calculate position for each cube at the center position
                    Vector3 cubePosition = center + new Vector3(i * spacing.x, j * spacing.y, k * spacing.z);

                    // Instantiate the cube prefab at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

                    // Set the local scale of the new cube to match the original scale
                    newCube.transform.localScale = originalCubeSize;
                }
            }
        }
    }
}*/
/* its not in the original position but same scale 
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public GameObject cubePrefab; // Reference to the cube prefab

    private Vector3 originalCubeScale; // Store the scale of the original cube prefab

    // Start is called before the first frame update
    void Start()
    {
        // Store the scale of the original cube prefab
        originalCubeScale = cubePrefab.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the cylinder based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // This function is called when another collider enters the trigger collider attached to this GameObject.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the square (you might want to use tags or layers here)
        if (other.gameObject.CompareTag("Square"))
        {
            // Store the position of the square before it was destroyed
            Vector3 squarePosition = other.gameObject.transform.position;

            // Destroy the square GameObject.
            Destroy(other.gameObject);

            // Create a big cuboid with multiple cubes at the same position and scale
            CreateCuboid(squarePosition);
        }
    }

    void CreateCuboid(Vector3 squarePosition)
    {
        // Set the size of the original cube
        Vector3 originalCubeSize = cubePrefab.GetComponent<Renderer>().bounds.size;

        // Define the number of cubes in each dimension
        int numCubesX = 3;
        int numCubesY = 3;
        int numCubesZ = 3;

        // Calculate the spacing between cubes
        Vector3 spacing = originalCubeSize / numCubesX;

        // Calculate the position of the center of the cuboid
        Vector3 center = squarePosition;

        // Instantiate cubes within a single cuboid at the original position with original scale
        for (int i = 0; i < numCubesX; i++)
        {
            for (int j = 0; j < numCubesY; j++)
            {
                for (int k = 0; k < numCubesZ; k++)
                {
                    // Calculate position for each cube at the center position
                    Vector3 cubePosition = center + new Vector3(i * spacing.x, j * spacing.y, k * spacing.z);

                    // Instantiate the cube prefab at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

                    // Set the local scale of the new cube to match the original scale
                    newCube.transform.localScale = originalCubeScale;
                }
            }
        }
    }
}
*/
/*using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;  // Reference to the Cube Prefab
    public int gridSizeX = 10;      // Number of cubes along the X-axis
    public int gridSizeY = 10;      // Number of cubes along the Y-axis
    public int gridSizeZ = 10;      // Number of cubes along the Z-axis
    public float mainCubeSizeX = 3.5f; // Desired size of the entire structure along the X-axis
    public float mainCubeSizeY = 1.9f; // Desired size of the entire structure along the Y-axis
    public float mainCubeSizeZ = 1.78f; // Desired size of the entire structure along the Z-axis

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        float cubeSizeX = mainCubeSizeX / gridSizeX; // Size of each smaller cube along the X-axis
        float cubeSizeY = mainCubeSizeY / gridSizeY; // Size of each smaller cube along the Y-axis
        float cubeSizeZ = mainCubeSizeZ / gridSizeZ; // Size of each smaller cube along the Z-axis

        Vector3 startPosition = new Vector3(-mainCubeSizeX / 2f + cubeSizeX / 2f,
            -mainCubeSizeY / 2f + cubeSizeY / 2f,
            -mainCubeSizeZ / 2f + cubeSizeZ / 2f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    // Calculate the position of the new cube
                    Vector3 position = startPosition + new Vector3(x * cubeSizeX, y * cubeSizeY, z * cubeSizeZ);

                    // Instantiate a new cube at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, position, Quaternion.identity);

                    // Set the scale of the new cube
                    newCube.transform.localScale = new Vector3(cubeSizeX, cubeSizeY, cubeSizeZ);
                }
            }
        }
    }
}*/
/* its not moving with the clamp
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;  // Reference to the Cube Prefab
    public int gridSizeX = 20;      // Number of cubes along the X-axis
    public int gridSizeY = 20;      // Number of cubes along the Y-axis
    public int gridSizeZ = 20;      // Number of cubes along the Z-axis
    public float mainCubeSizeX = 3.9f; // Desired size of the entire structure along the X-axis
    public float mainCubeSizeY = 1.9f; // Desired size of the entire structure along the Y-axis
    public float mainCubeSizeZ = 1.7f; // Desired size of the entire structure along the Z-axis

    private GameObject mainCube;   // Reference to the main cube (optional, for replacing it)

    void Start()
    {
        mainCube = gameObject;     // Assuming this script is attached to the main cube
        GenerateCubes();
    }

    void GenerateCubes()
    {
        float cubeSizeX = mainCubeSizeX / gridSizeX; // Size of each smaller cube along the X-axis
        float cubeSizeY = mainCubeSizeY / gridSizeY; // Size of each smaller cube along the Y-axis
        float cubeSizeZ = mainCubeSizeZ / gridSizeZ; // Size of each smaller cube along the Z-axis

        // Calculate the starting position relative to the main cube's position
        Vector3 startPosition = mainCube.transform.position + new Vector3(-mainCubeSizeX / 2f + cubeSizeX / 2f,
                                                                         -mainCubeSizeY / 2f + cubeSizeY / 2f,
                                                                         -mainCubeSizeZ / 2f + cubeSizeZ / 2f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    // Calculate the position of the new cube
                    Vector3 position = startPosition + new Vector3(x * cubeSizeX, y * cubeSizeY, z * cubeSizeZ);

                    // Instantiate a new cube at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, position, Quaternion.identity);

                    // Set the scale of the new cube
                    newCube.transform.localScale = new Vector3(cubeSizeX, cubeSizeY, cubeSizeZ);
                }
            }
        }

        // Optionally, destroy the main cube after generating the grid
        Destroy(mainCube);
    }
}
*/
/*
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;  // Reference to the Cube Prefab
    public int gridSizeX = 3;      // Number of cubes along the X-axis
    public int gridSizeY = 3;      // Number of cubes along the Y-axis
    public int gridSizeZ = 3;      // Number of cubes along the Z-axis
    public float mainCubeSizeX = 3f; // Desired size of the entire structure along the X-axis
    public float mainCubeSizeY = 3f; // Desired size of the entire structure along the Y-axis
    public float mainCubeSizeZ = 3f; // Desired size of the entire structure along the Z-axis

    private GameObject mainCube;   // Reference to the main cube

    void Start()
    {
        mainCube = gameObject;     // Assuming this script is attached to the main cube
        GenerateCubes();
    }

    void GenerateCubes()
    {
        float cubeSizeX = mainCubeSizeX / gridSizeX; // Size of each smaller cube along the X-axis
        float cubeSizeY = mainCubeSizeY / gridSizeY; // Size of each smaller cube along the Y-axis
        float cubeSizeZ = mainCubeSizeZ / gridSizeZ; // Size of each smaller cube along the Z-axis

        // Calculate the starting position relative to the main cube's position
        Vector3 startPosition = new Vector3(-mainCubeSizeX / 2f + cubeSizeX / 2f,
                                            -mainCubeSizeY / 2f + cubeSizeY / 2f,
                                            -mainCubeSizeZ / 2f + cubeSizeZ / 2f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    // Calculate the position of the new cube relative to the main cube
                    Vector3 position = startPosition + new Vector3(x * cubeSizeX, y * cubeSizeY, z * cubeSizeZ);

                    // Instantiate a new cube at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, mainCube.transform.position + position, Quaternion.identity);

                    // Set the scale of the new cube
                    newCube.transform.localScale = new Vector3(cubeSizeX, cubeSizeY, cubeSizeZ);

                    // Make the new cube a child of the main cube
                    newCube.transform.parent = mainCube.transform;

                    // Add a tag to the new cube
                    newCube.tag = "Smallcube";
                }
            }
        }

        // Optionally, disable the main cube's renderer if you don't want it visible
        Renderer mainCubeRenderer = mainCube.GetComponent<Renderer>();
        if (mainCubeRenderer != null)
        {
            mainCubeRenderer.enabled = false;
        }
    }
}
*/
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;  // Reference to the Cube Prefab
    public int gridSizeX = 3;      // Number of cubes along the X-axis
    public int gridSizeY = 3;      // Number of cubes along the Y-axis
    public int gridSizeZ = 3;      // Number of cubes along the Z-axis
    public float mainCubeSizeX = 3f; // Desired size of the entire structure along the X-axis
    public float mainCubeSizeY = 3f; // Desired size of the entire structure along the Y-axis
    public float mainCubeSizeZ = 3f; // Desired size of the entire structure along the Z-axis

    private GameObject mainCube;   // Reference to the main cube
    private int destroyedCubes = 0; // Counter for destroyed cubes

    void Start()
    {
        mainCube = gameObject;     // Assuming this script is attached to the main cube
        GenerateCubes();
    }

    void GenerateCubes()
    {
        float cubeSizeX = mainCubeSizeX / gridSizeX; // Size of each smaller cube along the X-axis
        float cubeSizeY = mainCubeSizeY / gridSizeY; // Size of each smaller cube along the Y-axis
        float cubeSizeZ = mainCubeSizeZ / gridSizeZ; // Size of each smaller cube along the Z-axis

        // Calculate the starting position relative to the main cube's position
        Vector3 startPosition = new Vector3(-mainCubeSizeX / 2f + cubeSizeX / 2f,
                                            -mainCubeSizeY / 2f + cubeSizeY / 2f,
                                            -mainCubeSizeZ / 2f + cubeSizeZ / 2f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    // Calculate the position of the new cube relative to the main cube
                    Vector3 position = startPosition + new Vector3(x * cubeSizeX, y * cubeSizeY, z * cubeSizeZ);

                    // Instantiate a new cube at the calculated position
                    GameObject newCube = Instantiate(cubePrefab, mainCube.transform.position + position, Quaternion.identity);

                    // Set the scale of the new cube
                    newCube.transform.localScale = new Vector3(cubeSizeX, cubeSizeY, cubeSizeZ);

                    // Make the new cube a child of the main cube
                    newCube.transform.parent = mainCube.transform;

                    // Add a tag to the new cube
                    newCube.tag = "Smallcube";
                }
            }
        }

        // Optionally, disable the main cube's renderer if you don't want it visible
        Renderer mainCubeRenderer = mainCube.GetComponent<Renderer>();
        if (mainCubeRenderer != null)
        {
            mainCubeRenderer.enabled = false;
        }
    }

    public void CubeDestroyed()
    {
        destroyedCubes++;
        LogDestroyedCubes();
    }

    void LogDestroyedCubes()
    {
        Debug.Log("Destroyed Cubes: " + destroyedCubes);
    }
}


