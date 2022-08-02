using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

public class ChairComponent : MonoBehaviour
{
    public GameObject component;
    public GameObject componentClone;
    public Vector3 spawnPoint = new Vector3(734,336,0);
    Action<string> _createComponentCallback;
    
    public void CreateComponent()
    {
        //_createComponentCallback = (jsonArrayString) =>
        //{
        //    CreateComponentRoutine(jsonArrayString);
        //};
        string projectNumber = Main.Instance.ProjectData.ProjectNumber;
        StartCoroutine(Main.Instance.GetTables.GetProjectData(projectNumber, CreateComponentRoutine));
        
    }

    void CreateComponentRoutine(string jsonArrayString)
    {
        Debug.Log("hello");
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
           
            JSONObject componentDataJson = new JSONObject();

            componentDataJson = jsonArray[0].AsObject;
            Action<string> getComponentDataCallback = (componentData) => {
                
            };

            //Instantiate(component, new Vector3(1f, 1f, 1f), Quaternion.identity);
            componentClone = Instantiate(component, spawnPoint, Quaternion.identity);
            component.transform.localScale = new Vector3(0,0,0);
            Debug.Log(componentDataJson["Width"]);
            var scaleChange = new Vector3(componentDataJson["Width"], componentDataJson["Length"], 1);
            componentClone.transform.localScale += scaleChange;
            
        }
 
    }
}
