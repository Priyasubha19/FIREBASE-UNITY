using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;

public class CubeCuttingProgress : MonoBehaviour
{
    // Reference to Firebase database
    private DatabaseReference databaseReference;

    // Total cubes to track in the layer
    private const int TotalCubesInLayer = 30;

    // Count of cubes cut
    private int cubesCut;

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        });
    }

    // Call this method when a cube is cut successfully
    public void OnCubeCut()
    {
        cubesCut++;
        UpdateCutPercentage();
    }

    // Calculate percentage and send data to Firebase
    private void UpdateCutPercentage()
    {
        float percentageCompleted = (float)cubesCut / TotalCubesInLayer * 100;
        Debug.Log($"Percentage Completed: {percentageCompleted}%");

        // Send percentage to Firebase
        SendPercentageToFirebase(percentageCompleted);
    }

    // Function to send data to Firebase
  /*  private void SendPercentageToFirebase(float percentage)
    {
        // Assuming we are storing the data under a node named "CuttingProgress"
        databaseReference.Child("status").SetValueAsync(percentage).ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to send data to Firebase: " + task.Exception);
            }
            else
            {
                Debug.Log("Successfully sent data to Firebase.");
            }
        });
    }*/
  private void SendPercentageToFirebase(float completePercentage)
  {
      // Assuming we are storing the data under a node named "CuttingProgress"
      Dictionary<string, object> updateData = new Dictionary<string, object>();
      updateData["status"] = completePercentage;

      databaseReference.UpdateChildrenAsync(updateData).ContinueWithOnMainThread(task => {
          if (task.IsFaulted)
          {
              Debug.LogError("Failed to send data to Firebase: " + task.Exception);
          }
          else
          {
              Debug.Log("Successfully sent data to Firebase.");
          }
      });
  }

}