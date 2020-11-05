using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [Header("Stats Data")]
    public int health;
    public int strength;
    public int speed;
    public int resistance;
    public int intelligence;



    public void SavePlayer()
    {
        StatsData statsSave = new StatsData();
        PositionData posSave = new PositionData();

        //------stats------
        statsSave.health = health;
        statsSave.strength = strength;
        statsSave.speed = speed;
        statsSave.resistance = resistance;
        statsSave.intelligence = intelligence;

        //-------Pos--------
        posSave.posX = transform.position.x;
        posSave.posY = transform.position.y;
        posSave.posZ = transform.position.z;

        //------rot-------
        posSave.rotation[0] = transform.rotation.x;
        posSave.rotation[1] = transform.rotation.y;
        posSave.rotation[2] = transform.rotation.z;
        posSave.rotation[3] = transform.rotation.w;

        SaveLoadManager<StatsData>.Save(Application.persistentDataPath + "/player.stats", statsSave);
        SaveLoadManager<PositionData>.Save(Application.persistentDataPath + "/player.pos", posSave);
    }

    public void LoadPlayer()
    {
        StatsData statsSave = new StatsData();
        PositionData posSave = new PositionData();

        SaveLoadManager<StatsData>.Load(Application.persistentDataPath + "/player.stats", out statsSave);
        SaveLoadManager<PositionData>.Load(Application.persistentDataPath + "/player.pos", out posSave);
        //----------stats----------
        health = statsSave.health;
        strength = statsSave.strength;
        speed = statsSave.speed;
        resistance = statsSave.resistance;
        intelligence = statsSave.intelligence;

        //----------pos----------
        transform.position = new Vector3(posSave.posX, posSave.posY, posSave.posZ);

        //----------rot----------
        Quaternion rotation;
        rotation.x = posSave.rotation[0];
        rotation.y = posSave.rotation[1];
        rotation.z = posSave.rotation[2];
        rotation.w = posSave.rotation[3];
        transform.rotation = rotation;
    }
}

[Serializable]
public class StatsData
{
    public int health;
    public int strength;
    public int speed;
    public int resistance;
    public int intelligence;
}

[Serializable]
public class PositionData
{
    public float posX;
    public float posY;
    public float posZ;

    public float[] rotation = new float[4];
}