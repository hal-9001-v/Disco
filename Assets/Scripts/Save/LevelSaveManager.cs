using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveManager : MonoBehaviour
{
    static readonly string filePath = Application.persistentDataPath + "/save.data";

    static SaveData LoadLevelData()
    {

        try
        {
            StreamReader reader = new StreamReader(filePath);

            string jsonData = reader.ReadToEnd();

            var data = JsonUtility.FromJson<SaveData>(jsonData);

            return data;

        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }


    }

    public static void SetLevelFromData()
    {
        var data = LoadLevelData();


        if (data != null)
        {
            SetInteractablesFromData(data);
        }



    }

    public static int getSaveSceneIndex()
    {
        var data = LoadLevelData();

        if (data != null)
            return data.CurrentScene;
        else
            return -1;
    }

    public static void SaveLevelData()
    {
        Debug.Log("LEVEL SAVE MANAGER: Saving Data of " + SceneManager.GetActiveScene().name);
        SaveData data = new SaveData();

        data.CurrentScene = SceneManager.GetActiveScene().buildIndex;

        var eventObjects = FindObjectsOfType<EventInteraction>();
        data.EventInteractions = new EventInteractionData[eventObjects.Length];

        for (int i = 0; i < data.EventInteractions.Length; i++)
        {
            data.EventInteractions[i] = eventObjects[i].GetSaveData();
        }



        var collisionObjects = FindObjectsOfType<CollisionInteraction>();
        data.CollisionInteractions = new CollisionInteractionData[collisionObjects.Length];

        for (int i = 0; i < data.CollisionInteractions.Length; i++)
        {
            data.CollisionInteractions[i] = collisionObjects[i].GetSaveData();
        }



        var distanceObjects = FindObjectsOfType<DistanceInteraction>();
        data.DistanceInteractions = new DistanceInteractionData[distanceObjects.Length];

        for (int i = 0; i < data.DistanceInteractions.Length; i++)
        {
            data.DistanceInteractions[i] = distanceObjects[i].getSaveData();
        }


        try
        {
            StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate));

            writer.Write(JsonUtility.ToJson(data));

            writer.Close();

        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }


    }

    static void SetInteractablesFromData(SaveData data)
    {
        Dictionary<string, EventInteractionData> EventInteractions = new Dictionary<string, EventInteractionData>();
        Dictionary<string, CollisionInteractionData> CollisionInteractions = new Dictionary<string, CollisionInteractionData>();
        Dictionary<string, DistanceInteractionData> DistanceInteractions = new Dictionary<string, DistanceInteractionData>();

        #region Set Dictionaries

        foreach (EventInteractionData interaction in data.EventInteractions)
        {
            EventInteractions.Add(interaction.name, interaction);
        }



        foreach (CollisionInteractionData interaction in data.CollisionInteractions)
        {
            CollisionInteractions.Add(interaction.name, interaction);
        }


        foreach (DistanceInteractionData interaction in data.DistanceInteractions)
        {
            DistanceInteractions.Add(interaction.name, interaction);
        }

        #endregion

        try
        {
            foreach (EventInteraction interaction in FindObjectsOfType<EventInteraction>())
            {
                var interactionData = EventInteractions[interaction.name];

                if (interactionData != null)
                    interaction.SetFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }

            foreach (CollisionInteraction interaction in FindObjectsOfType<CollisionInteraction>())
            {
                var interactionData = CollisionInteractions[interaction.name];

                if (interactionData != null)
                    interaction.SetFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }

            foreach (DistanceInteraction interaction in FindObjectsOfType<DistanceInteraction>())
            {
                var interactionData = DistanceInteractions[interaction.name];

                if (interactionData != null)
                    interaction.setFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }

        }
        catch (KeyNotFoundException e)
        {
            Debug.LogError(e.ToString());
        }



    }
}

    [Serializable]
    class SaveData
    {

        public EventInteractionData[] EventInteractions;

        public CollisionInteractionData[] CollisionInteractions;

        public DistanceInteractionData[] DistanceInteractions;


        public int CurrentScene;

    }
