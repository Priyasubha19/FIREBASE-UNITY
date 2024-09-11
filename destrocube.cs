/*using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Log the name and tag of the collided object
        Debug.Log("Collision detected with: " + other.gameObject.name + " (Tag: " + other.gameObject.tag + ")");

        // Check if the object collided with has the tag "SmallCube"
        if (other.gameObject.CompareTag("Smallcube"))
        {
            // Log the destruction
            Debug.Log("Destroying object: " + other.gameObject.name);

            // Destroy the small cube
            Destroy(other.gameObject);
        }
    }
}
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Log the name and tag of the collided object
        Debug.Log("Trigger detected with: " + other.gameObject.name + " (Tag: " + other.gameObject.tag + ")");

        // Check if the object collided with has the tag "SmallCube"
        if (other.gameObject.CompareTag("Smallcube"))
        {
            // Log the destruction
            Debug.Log("Destroying object: " + other.gameObject.name);

            // Destroy the small cube
            Destroy(other.gameObject);
        }
    }
}
*/
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float destructionProbability = 0.5f; // Probability of a cube being destroyed (between 0 and 1)
    private CubeGenerator cubeGenerator;

    void Start()
    {
        // Find the CubeGenerator in the scene
        cubeGenerator = FindObjectOfType<CubeGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smallcube"))
        {
            if (Random.value < destructionProbability)
            {
                // Destroy the small cube
                Destroy(other.gameObject);

                // Update the count of destroyed cubes in the CubeGenerator
                if (cubeGenerator != null)
                {
                    cubeGenerator.CubeDestroyed();
                }
            }
        }
    }
}

