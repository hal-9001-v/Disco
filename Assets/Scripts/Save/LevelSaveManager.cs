using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveManager : MonoBehaviour
{
    /*This Class stores the data from the current Scene. In case the scene is not the same from data, nothing shall happen.
    *
    *NOTE:Use LoadGame for loading and SaveGame for saving.
     */

    static readonly string FilePath = Application.persistentDataPath + "/save.data";

    public static void LoadGame()
    {
        var data = LoadLevelData();

        if (data != null)
        {
            if (data.CurrentScene == SceneManager.GetActiveScene().buildIndex)
            {
                SetInteractablesFromData(data);

            }
            else
            {
                Debug.LogWarning("Trying to load a different scene from Data!");
            }
        }

    }

    public static void SaveGame()
    {
        SaveLevelData();
    }

    public static int GetSaveSceneIndex()
    {
        var data = LoadLevelData();

        if (data != null)
            return data.CurrentScene;
        else
            return -1;
    }

    static void SaveLevelData()
    {
        Debug.Log("LEVEL SAVE MANAGER: Saving Data of " + SceneManager.GetActiveScene().name);
        SaveData data = new SaveData();

        data.CurrentScene = SceneManager.GetActiveScene().buildIndex;

        #region Find Interaction Objects

        /*Components to Save:
        * -InputInteraction
        * -CollisionInteraction
        * -DistanceInteraction
        */

        //INPUT INTERACTION
        var inputObjects = FindObjectsOfType<InputInteraction>();
        data.InputInteractions = new InputInteractionData[inputObjects.Length];

        for (int i = 0; i < data.InputInteractions.Length; i++)
        {
            data.InputInteractions[i] = inputObjects[i].GetSaveData();
        }

        //COLLISION INTERACTION
        var collisionObjects = FindObjectsOfType<CollisionInteraction>();
        data.CollisionInteractions = new CollisionInteractionData[collisionObjects.Length];

        for (int i = 0; i < data.CollisionInteractions.Length; i++)
        {
            data.CollisionInteractions[i] = collisionObjects[i].GetSaveData();
        }

        //DISTANCE INTERACTION
        var distanceObjects = FindObjectsOfType<DistanceInteraction>();
        data.DistanceInteractions = new DistanceInteractionData[distanceObjects.Length];

        for (int i = 0; i < data.DistanceInteractions.Length; i++)
        {
            data.DistanceInteractions[i] = distanceObjects[i].GetSaveData();
        }

        #endregion
        try
        {
            StreamWriter writer = new StreamWriter(new FileStream(FilePath, FileMode.OpenOrCreate));

            writer.Write(JsonUtility.ToJson(data));

            writer.Close();

        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }


    }
    static SaveData LoadLevelData()
    {
        try
        {
            StreamReader reader = new StreamReader(FilePath);

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
    static void SetInteractablesFromData(SaveData data)
    {
        Dictionary<string, InputInteractionData> EventInteractions = new Dictionary<string, InputInteractionData>();
        Dictionary<string, CollisionInteractionData> CollisionInteractions = new Dictionary<string, CollisionInteractionData>();
        Dictionary<string, DistanceInteractionData> DistanceInteractions = new Dictionary<string, DistanceInteractionData>();

        #region Set Dictionaries with Interaction Objects

        foreach (InputInteractionData interaction in data.InputInteractions)
        {
            EventInteractions.Add(interaction.Name, interaction);
        }

        foreach (CollisionInteractionData interaction in data.CollisionInteractions)
        {
            CollisionInteractions.Add(interaction.Name, interaction);
        }

        foreach (DistanceInteractionData interaction in data.DistanceInteractions)
        {
            DistanceInteractions.Add(interaction.Name, interaction);
        }

        #endregion

        try
        {
            #region Set Gameobjects with Data
            foreach (InputInteraction interaction in FindObjectsOfType<InputInteraction>())
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
                    interaction.SetFromLoadData(interactionData);
                else
                    Debug.LogWarning("No data saved for " + interaction.name);

            }
            #endregion

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
    public InputInteractionData[] InputInteractions;

    public CollisionInteractionData[] CollisionInteractions;

    public DistanceInteractionData[] DistanceInteractions;


    public int CurrentScene;

}
