/*using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor

    void Start()
    {
        // Store the initial position of the object
        initialPosition = objectToMove.transform.position;

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos
                        float xPosValue = float.Parse(snapshot.Child("x_pos").Value.ToString());
                        float zPosValue = float.Parse(snapshot.Child("z_pos").Value.ToString());

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Check the time difference for x_pos and z_pos
                        TimeSpan timeDifference = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update position for x_pos and z_pos
                        if (timeDifference.TotalSeconds > 1.0)
                        {
                            // Keep the y-coordinate fixed and move only in the x and z coordinates
                            Vector3 newPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);

                            // Move the object directly to the new position relative to the initial position
                            objectToMove.transform.position = initialPosition + newPosition;

                            // Ensure the y-coordinate is fixed
                            objectToMove.transform.position = new Vector3(objectToMove.transform.position.x, initialPosition.y, objectToMove.transform.position.z);

                            // Update the last update time
                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
*/
/* this code for integer value

using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor

    void Start()
    {
        // Store the initial position of the object
        initialPosition = objectToMove.transform.position;

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos
                        float xPosValue = float.Parse(snapshot.Child("x_pos").Value.ToString()) - 15; // Adjust x_pos
                        float zPosValue = float.Parse(snapshot.Child("z_pos").Value.ToString()) - 16; // Adjust z_pos

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Check the time difference for x_pos and z_pos
                        TimeSpan timeDifference = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update position for x_pos and z_pos
                        if (timeDifference.TotalSeconds > 1.0)
                        {
                            // Keep the y-coordinate fixed and move only in the x and z coordinates
                            Vector3 newPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);

                            // Move the object directly to the new position relative to the initial position
                            objectToMove.transform.position = initialPosition + newPosition;

                            // Ensure the y-coordinate is fixed
                            objectToMove.transform.position = new Vector3(objectToMove.transform.position.x, initialPosition.y, objectToMove.transform.position.z);

                            // Update the last update time
                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
*/
/*
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor

    void Start()
    {
        // Store the initial position of the object
        initialPosition = objectToMove.transform.position;

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos as floats
                        float xPosValue = float.Parse(snapshot.Child("x_pos").Value.ToString()) - 15.8f; // Adjust x_pos
                        float zPosValue = float.Parse(snapshot.Child("z_pos").Value.ToString()) - 16.3f; // Adjust z_pos

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Check the time difference for x_pos and z_pos
                        TimeSpan timeDifference = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update position for x_pos and z_pos
                        if (timeDifference.TotalSeconds > 1.0)
                        {
                            // Keep the y-coordinate fixed and move only in the x and z coordinates
                            Vector3 newPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);

                            // Move the object directly to the new position relative to the initial position
                            objectToMove.transform.position = initialPosition + newPosition;

                            // Ensure the y-coordinate is fixed
                            objectToMove.transform.position = new Vector3(objectToMove.transform.position.x, initialPosition.y, objectToMove.transform.position.z);

                            // Update the last update time
                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
*/
/* perfact code
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor

    void Start()
    {
        // Store the initial position of the object
        initialPosition = new Vector3(-1.16f, 0f, -2.52f);

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos as floats
                        float xPosValue = (float.Parse(snapshot.Child("x_pos").Value.ToString()) - 14f) + initialPosition.x; // Adjust x_pos
                        float zPosValue = (float.Parse(snapshot.Child("z_pos").Value.ToString()) - 9f) + initialPosition.z; // Adjust z_pos

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Check the time difference for x_pos and z_pos
                        TimeSpan timeDifference = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update position for x_pos and z_pos
                        if (timeDifference.TotalSeconds > 1.0)
                        {
                            // Keep the y-coordinate fixed and move only in the x and z coordinates
                            Vector3 newPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);

                            // Move the object directly to the new position relative to the initial position
                            objectToMove.transform.position = newPosition;

                            // Update the last update time
                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}

*/
/*
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor

    void Start()
    {
        // Store the initial position of the object
        initialPosition = new Vector3(-1.02f, 0f, -2.52f);

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos as floats
                        float xPosValue = ((float.Parse(snapshot.Child("x_pos").Value.ToString()) - 16f)/2f) + initialPosition.x; // Adjust and halve x_pos
                        float zPosValue = ((float.Parse(snapshot.Child("z_pos").Value.ToString()) - 9f)/2f) + initialPosition.z; // Adjust and halve z_pos

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Check the time difference for x_pos and z_pos
                        TimeSpan timeDifference = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update position for x_pos and z_pos
                        if (timeDifference.TotalSeconds > 1.0)
                        {
                            // Keep the y-coordinate fixed and move only in the x and z coordinates
                            Vector3 newPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);

                            // Move the object directly to the new position relative to the initial position
                            objectToMove.transform.position = newPosition;

                            // Update the last update time
                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
*/
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveObjectXZWithFirebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject objectToMove; // Assign the bed object in the Unity Editor
    public float smoothTime = 0.3f; // Adjust the time it takes to reach the target position

    void Start()
    {
        // Store the initial position of the object
        initialPosition = new Vector3(-1.02f, 0f, -2.52f);
        targetPosition = initialPosition;

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            databaseReference.Child("status").ValueChanged += HandleValueChanged;
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
                        // Retrieve data from Firebase for x_pos and z_pos as floats
                        float xPosValue = ((float.Parse(snapshot.Child("x_pos").Value.ToString()) - 16f)/2f) + initialPosition.x; // Adjust and halve x_pos
                        float zPosValue = ((float.Parse(snapshot.Child("z_pos").Value.ToString()) - 10f)/2f) + initialPosition.z; // Adjust and halve z_pos

                        // Log the retrieved data
                        Debug.Log($"Retrieved data from Firebase: X = {xPosValue}, Z = {zPosValue}");

                        // Update the target position
                        targetPosition = new Vector3(xPosValue, initialPosition.y, zPosValue);
                    }
                }
            });
        }

        // Smoothly move the object towards the target position
        objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, targetPosition, smoothTime * Time.deltaTime);
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
