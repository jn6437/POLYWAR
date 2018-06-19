using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public GameObject levelButtonPrefab;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;
    private static float smooth = 3.0F;
    private static float distanceFromPanel = 300F;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(cameraDesiredLookAt != null) 
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, smooth * Time.deltaTime);
            cameraTransform.position = Vector3.Slerp(cameraTransform.position, cameraDesiredLookAt.position - cameraDesiredLookAt.forward*300f, smooth * Time.deltaTime);
            print(cameraDesiredLookAt.forward);
        }
	}

    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
    }

    public void GoToGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
