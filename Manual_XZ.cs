using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Manual_XZ : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    public float smoothTime = 0.1f; // Adjust the time it takes to reach the target position

    public GameObject objectToMove; // Single object to move

    void Start()
    {
        initialPosition = objectToMove.transform.position;
        targetPosition = initialPosition;

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                // Start listening for changes in the Firebase database
                databaseReference.Child("status").ValueChanged += HandleValueChanged;
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Exception);
            }
        });
    }

    void Update()
    {
        if (databaseReference != null)
        {
            // Fetch the x_pos and z_pos values from Firebase under the "status" node
            databaseReference.Child("status").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists && snapshot.Child("x_pos").Exists && snapshot.Child("z_pos").Exists)
                    {
                        float xPosValue = float.Parse(snapshot.Child("x_pos").Value.ToString());
                        float zPosValue = float.Parse(snapshot.Child("z_pos").Value.ToString());

                        // Debug log the fetched values
                        Debug.Log("Fetched x_pos value: " + xPosValue);
                        Debug.Log("Fetched z_pos value: " + zPosValue);

                        // Convert positive values to negative for movement
                        if (xPosValue > 0)
                        {
                            xPosValue = -xPosValue;
                            Debug.Log("Converted positive x_pos value to negative: " + xPosValue);
                        }
                        if (zPosValue > 0)
                        {
                            zPosValue = -zPosValue;
                            Debug.Log("Converted positive z_pos value to negative: " + zPosValue);
                        }

                        // Update target position based on x_pos and z_pos values
                        targetPosition = initialPosition + new Vector3(xPosValue, 0, zPosValue);
                    }
                }
            });
        }

        // Smoothly move the object towards its target position
        objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, targetPosition, smoothTime * Time.deltaTime);
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
