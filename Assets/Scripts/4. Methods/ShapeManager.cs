using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class ShapeManager : MonoBehaviour
{
    public VRTK_BaseControllable controllable;

    public ShapeHandler shapeHandler;
    public MatchHandler matchHandler;

    public List<Key> allKeys;

    public int keyIndex;

    [System.Serializable]
    public class Key
    {
        public List<int> key;
    }


    // Start is called before the first frame update
    void Start()
    {
        keyIndex = 0;
        ChangeKey();

        controllable.MaxLimitReached += Controllable_MaxLimitReached;

    }

    private void Controllable_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        bool result = CheckKey();

        if(result)
        {
            IncIndex();
            ChangeKey();
        }
    }

    public void IncIndex()
    {
        keyIndex++;
        keyIndex = keyIndex % allKeys.Count;
    }

    public bool CheckKey()
    {

        if (shapeHandler.key.Count != matchHandler.matchKey.Count)
        {
            return false;
        }
        for (int i = 0; i < shapeHandler.key.Count; i++)
        {
            if (shapeHandler.key[i] != matchHandler.matchKey[i])
            {
                return false;
            }  
        }

        return true;

    }

    public void ChangeKey()
    {
        matchHandler.matchKey = allKeys[keyIndex].key;
        matchHandler.SetShape();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
