using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class charDatabase : ScriptableObject
{
    public Character[] characterList;

    public int characterCount
    {
        get
        {
            return characterList.Length;
        }
    }

    public Character GetChar(int index)
    {
        return characterList[index];
    }
}
