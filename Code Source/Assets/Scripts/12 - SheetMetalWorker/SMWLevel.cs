using UnityEngine;
using System.Collections;

public class SMWLevel : AbstractLevel
{

    string level1 = "SheetMetalWorker/Level1";
    string level2 = "SheetMetalWorker/Level2";
    string level3 = "SheetMetalWorker/Level3";

    Object levelPrefab;
    GameObject levelObject;

    public override void LoadLevel(int nb)
    {
        switch (nb)
        {
            case 1:
                levelPrefab = Resources.Load(level1);
                break;
            case 2:
                levelPrefab = Resources.Load(level2);
                break;
            case 3:
                levelPrefab = Resources.Load(level3);
                break;
        }
        levelObject = Instantiate(levelPrefab) as GameObject;
    }

    public override void Clear()
    {
        Destroy(levelObject);
    }
}
