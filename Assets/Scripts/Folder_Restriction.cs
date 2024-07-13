using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Folder_Restriction : MonoBehaviour
{
    /*
    public GameObject Obj;
    public GameObject camara;
    
    public void OnInteraction() 
    {
        Obj.SetActive(false);
        camara.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void MoveToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
