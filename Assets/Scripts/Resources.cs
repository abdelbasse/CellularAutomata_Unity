using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct int2
{
    public int x;
    public int y;

    public int2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}


[System.Serializable]
public class MyCell<T>
{
    public T isAlive;
    public T wasAlive;

    public MyCell(T stat = default(T))
    {
        wasAlive = isAlive = stat;
    }

    // Optional: You can create a method to set the visibility externally
    public void SetVisibility(T value)
    {
        wasAlive = isAlive = value;
    }
}


[System.Serializable]
public class Rulles
{
    public List<int> Survive;
    public List<int> Born;

    public Rulles()
    {
        Survive = new List<int>();
        Born = new List<int>();
    }
}

public class Resources : MonoBehaviour
{
    
}
