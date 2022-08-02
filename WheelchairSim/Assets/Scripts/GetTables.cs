using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class GetTables : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetTable());
    }
 
    IEnumerator GetTable()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/Connect.php"))
        {
            yield return www.SendWebRequest(); //ændrer det her til obsolete?

            if (www.error != null)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetProjectData(string projectNumber, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("projectNum", projectNumber);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GetProjectData.php", form))
        {
            yield return www.SendWebRequest(); 

            if (www.error != null)
            {
                Debug.Log(www.error);
            }
            else
            {
                
                Debug.Log(www.downloadHandler.text);
                string jsonArrayString = www.downloadHandler.text;
                callback(jsonArrayString);
            }
        }
      
    }
   

}
