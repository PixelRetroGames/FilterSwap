using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PlatformInformation
{
    public PlatformInformation(Vector3 position, Vector2 size, string color)
    {
        this.position = position;
        this.size = size;
        this.color = color;
    }

    public Vector3 position;
    public Vector2 size;
    public String color;
    
}

[Serializable]
public class SpikeInformation
{
    public SpikeInformation(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 position;
}

[Serializable]
public class ExitInformation
{
    public ExitInformation(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 position;
}

[Serializable]
public class LevelObject
{
    public Vector3 playerStartPosition;

    public List<PlatformInformation> platforms = new List<PlatformInformation>();

    public List<SpikeInformation> spikes = new List<SpikeInformation>();

    public List<ExitInformation> exits = new List<ExitInformation>();

}
