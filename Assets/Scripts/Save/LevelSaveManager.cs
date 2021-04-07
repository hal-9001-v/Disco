using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveManager : MonoBehaviour
{
    static readonly string filePath = Application.persistentDataPath + "/save.data";

    static SaveData loadLevelData()
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

    public static void setLevelFromData()
    {
        var data = loadLevelData();


        if (data != null)
        {
            setInteractablesFromData(data);
        }



    }

    public static int getSaveSceneIndex()
    {
        var data = loadLevelData();

        if (data != null)
            return data.currentScene;
        else
            return -1;
    }

    public static void saveLevelData()
    {
        Debug.Log("LEVEL SAVE MANAGER: Saving Data of " + SceneManager.GetActiveScene().name);
        SaveData data = new SaveData();

        data.currentScene = SceneManager.GetActiveScene().buildIndex;

        var eventObjects = FindObjectsOfType<EventInteraction>();
        data.eventInteractions = new EventInteractionData[eventObjects.Length];

        for (int i = 0; i < data.eventInteractions.Length; i++)
        {
            data.eventInteractions[i] = eventObjects[i].getSaveData();
        }



        var collisionObjects = FindObjectsOfType<CollisionInteraction>();
        data.collisionInteractions = new CollisionInteractionData[collisionObjects.Length];

        for (int i = 0; i < data.collisionInteractions.Length; i++)
        {
            data.collisionInteractions[i] = collisionObjects[i].getSaveData();
        }



        var distanceObjects = FindObjectsOfType<DistanceInteraction>();
        data.distanceInteractions = new DistanceInteractionData[distanceObjects.Length];

        for (int i = 0; i < data.distanceInteractions.Length; i++)
        {
            data.distanceInteractions[i] = distanceObjects[i].getSaveData();
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

    static void setInteractablesFromData(SaveData data)
    {
        Dictionary<string, EventInteractionData> eventInteractions = new Dictionary<string, EventInteractionData>();
        Dictionary<string, CollisionInteractionData> collisionInteractions = new Dictionary<string, CollisionInteractionData>();
        Dictionary<string, DistanceInteractionData> distanceInteractions = new Dictionary<string, DistanceInteractionData>();

        #region Set Dictionaries

        foreach (EventInteractionData interaction in data.eventInteractions)
        {
            eventInteractions.Add(interaction.name, interaction);
        }



        foreach (CollisionInteractionData interaction in data.collisionInteractions)
        {
            collisionInteractions.Add(interaction.name, interaction);
        }


        foreach (DistanceInteractionData interaction in data.distanceInteractions)
        {
            distanceInteractions.Add(interaction.name, interaction);
        }

        #endregion

        try
        {
            foreach (EventInteraction interaction in FindObjectsOfType<EventInteraction>())
            {
                var interactionData = eventInteractions[interaction.name];

                if (interactionData != null)
                    interaction.setFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }

            foreach (CollisionInteraction interaction in FindObjectsOfType<CollisionInteraction>())
            {
                var interactionData = collisionInteractions[interaction.name];

                if (interactionData != null)
                    interaction.setFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }

            foreach (DistanceInteraction interaction in FindObjectsOfType<DistanceInteraction>())
            {
                var interactionData = distanceInteractions[interaction.name];

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

        public EventInteractionData[] eventInteractions;

        public CollisionInteractionData[] collisionInteractions;

        public DistanceInteractionData[] distanceInteractions;


        public int currentScene;

    }
