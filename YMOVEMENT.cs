/* without redusing the value
 using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class ymovement : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3[] initialPositions;
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value

    public GameObject[] objectsToMove; // Assign your objects in the Unity Editor

    void Start()
    {
        // Store the initial positions of the objects
        initialPositions = new Vector3[objectsToMove.Length];
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            initialPositions[i] = objectsToMove[i].transform.position;
        }

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
            // Fetch the y_pos value from Firebase under the "status" node
            databaseReference.Child("status").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists && snapshot.Child("y_pos").Exists)
                    {
                        float yPosValue = float.Parse(snapshot.Child("y_pos").Value.ToString());

                        Debug.Log("Retrieved yPosValue: " + yPosValue);

                        // Check the time difference for y_pos
                        TimeSpan timeDifferenceY = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update positions for y_pos
                        if (timeDifferenceY.TotalSeconds > 1.0)
                        {
                            // Move each object in the Y direction based on the absolute value of yPosValue
                            float distanceToMove = Mathf.Abs(yPosValue);

                            for (int i = 0; i < objectsToMove.Length; i++)
                            {
                                // Update the Y position of each object relative to its initial position
                                Vector3 newPosition = initialPositions[i];
                                newPosition.y = initialPositions[i].y - distanceToMove;

                                // Update the position of each object
                                objectsToMove[i].transform.position = newPosition;
                            }

                            // Update the last update time for y_pos
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
/* this code for taking integer
using UnityEngine;// import the necessary library for unity and  firebase, those namespace allowing to use class and methods
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class ymovement : MonoBehaviour //(The ymovement class is declared, inheriting from MonoBehaviour, which is the base class for Unity scripts. )
{
    private DatabaseReference databaseReference; //A reference to the Firebase Database.
    private Vector3[] initialPositions; //An array to store the initial positions of the objects to be moved
    private DateTime lastUpdateTime = DateTime.MinValue; // Initialize with a default value
    private const float distanceThreshold = 0.10f; // Threshold for considering values as zero (8 cm)

    public GameObject[] objectsToMove; // Assign your objects in the Unity Editor

    void Start()
    {
        // Store the initial positions of the objects
        initialPositions = new Vector3[objectsToMove.Length];
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            initialPositions[i] = objectsToMove[i].transform.position;
        }

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
            // Fetch the y_pos value from Firebase under the "status" node  
           // In the context of asynchronous programming, "synchronously fetches" means that the code execution waits for the fetch operation to complete before moving on to the next line of code. In contrast, "asynchronously fetches" means that the code execution continues immediately after initiating the fetch operation, without waiting for it to complete.
            databaseReference.Child("status").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists && snapshot.Child("y_pos").Exists)
                    {
                        float yPosValue = float.Parse(snapshot.Child("y_pos").Value.ToString());

                        Debug.Log("Retrieved yPosValue: " + yPosValue);

                        // Check the time difference for y_pos
                        TimeSpan timeDifferenceY = DateTime.Now - lastUpdateTime;

                        // If the time difference is greater than a certain threshold (e.g., 1 second), update positions for y_pos
                        if (timeDifferenceY.TotalSeconds > 1.0)
                        {
                            // Adjust the yPosValue to consider 8 cm as zero
                            yPosValue -= 10f; // Assuming the unit is in cm

                            // Move each object in the Y direction based on the absolute value of yPosValue
                            float distanceToMove = Mathf.Abs(yPosValue);

                            for (int i = 0; i < objectsToMove.Length; i++)
                            {
                                // Update the Y position of each object relative to its initial position
                                Vector3 newPosition = initialPositions[i];
                                newPosition.y = initialPositions[i].y - distanceToMove;

                                // Update the position of each object
                                objectsToMove[i].transform.position = newPosition;
                            }

                            // Update the last update time for y_pos
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

public class ymovement : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3[] initialPositions;
    private DateTime lastUpdateTime = DateTime.MinValue;
    private const float distanceThreshold = 10f;

    public GameObject[] objectsToMove;

    void Start()
    {
        initialPositions = new Vector3[objectsToMove.Length];
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            initialPositions[i] = objectsToMove[i].transform.position;
        }

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
            databaseReference.Child("status").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists && snapshot.Child("y_pos").Exists)
                    {
                        float yPosValue = float.Parse(snapshot.Child("y_pos").Value.ToString());

                        Debug.Log("Retrieved yPosValue: " + yPosValue);

                        TimeSpan timeDifferenceY = DateTime.Now - lastUpdateTime;

                        if (timeDifferenceY.TotalSeconds > 1.0)
                        {
                            yPosValue -= 10f; // Adjust the value as needed

                            float distanceToMove = Mathf.Abs(yPosValue);

                            for (int i = 0; i < objectsToMove.Length; i++)
                            {
                                Vector3 newPosition = initialPositions[i];
                                newPosition.y = initialPositions[i].y - distanceToMove;

                                objectsToMove[i].transform.position = newPosition;
                            }

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

public class ymovement : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private Vector3[] initialPositions;
    private Vector3[] targetPositions;
    private DateTime lastUpdateTime = DateTime.MinValue;
    private const float distanceThreshold = 10f;

    public GameObject[] objectsToMove;
    public float smoothTime = 0.3f; // Adjust the time it takes to reach the target position

    void Start()
    {
        initialPositions = new Vector3[objectsToMove.Length];
        targetPositions = new Vector3[objectsToMove.Length];

        for (int i = 0; i < objectsToMove.Length; i++)
        {
            initialPositions[i] = objectsToMove[i].transform.position;
            targetPositions[i] = initialPositions[i];
        }

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
            databaseReference.Child("status").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists && snapshot.Child("y_pos").Exists)
                    {
                        float yPosValue = float.Parse(snapshot.Child("y_pos").Value.ToString());

                        Debug.Log("Retrieved yPosValue: " + yPosValue);

                        TimeSpan timeDifferenceY = DateTime.Now - lastUpdateTime;

                        if (timeDifferenceY.TotalSeconds > 1.0)
                        {
                            yPosValue -= 10f; // Adjust the value as needed

                            float distanceToMove = Mathf.Abs(yPosValue);

                            for (int i = 0; i < objectsToMove.Length; i++)
                            {
                                targetPositions[i] = initialPositions[i];
                                targetPositions[i].y = initialPositions[i].y - distanceToMove;
                            }

                            lastUpdateTime = DateTime.Now;
                        }
                    }
                }
            });
        }

        // Smoothly move each object towards its target position
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            objectsToMove[i].transform.position = Vector3.Lerp(objectsToMove[i].transform.position, targetPositions[i], smoothTime * Time.deltaTime);
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        // Handle additional logic for real-time updates if needed
    }
}
