using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main Instance;
    public GetTables GetTables;
    public ProjectData ProjectData;
    void Start()
    {
        Instance = this;
        GetTables = GetComponent<GetTables>();
        ProjectData = GetComponent<ProjectData>();
    }

}
