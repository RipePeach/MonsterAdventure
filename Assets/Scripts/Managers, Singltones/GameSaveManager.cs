using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class GameSaveManager
{
    public static string savePath = "./PlayerData.save";

    public static void SavePlayer(CharacterScript player)
    {
        // open binaryFormatter
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        // create filestreem. tell it two things where it is going to be saving this file and how you want to be opening it
        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate);

        PlayerData data = new PlayerData(player);
        // сохранить объекты в потоке
        binaryFormatter.Serialize(fileStream, data);
        //закрыть поток
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);
            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;

            fileStream.Close();

            return data;
        }

        Debug.LogError("File does not exist");
        return null;
    }
}

[Serializable]
public class PlayerData
{
    public int health;
    public int maxHealth;
    public int damage;
    public float attackRadius;
    public string attackType;
    public float startPositionX;
    public float startPositionY;

    public PlayerData(CharacterScript player)
    {
        health = player.health;
        maxHealth = player.maxHealth;
        damage = player.damage;
        attackRadius = player.attackRadius;
        attackType = player.attackType;
        //startPositionX = player.startPosition.x;
        //startPositionY = player.startPosition.y;
    }
}