using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraRayControl : MonoBehaviour
{
    Text infoText;
    Slider timeSlider;
    float delay = 0f;
    Scene m_scene;
    string scene_name;

    void Start()
    {
        m_scene = SceneManager.GetActiveScene();
        scene_name = m_scene.name;
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        timeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        infoText.enabled = false;
        timeSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hasHit)
        {
            if (hit.collider.name == "HotspotBall")
            {
                SceneInfo(scene_name);
            }
            //mike
            else if (hit.collider.name == "TeleportCube")
            {
                ShowInfoText("Move to Hallway");
                MoveToNextRoom("Hallway"); 
            }
            //huell
            else if (hit.collider.name == "TeleportCube2")
            {
                ShowInfoText("Move to Outside");
                MoveToNextRoom("Outside");
            } 
            //patrick
            else if (hit.collider.name == "TeleportCube3")
            {
                ShowInfoText("Move to Classroom");
                MoveToNextRoom("Classroom");
            }
            else if (hit.collider.name == "TeleportCube4")
            {
                ShowInfoText("Move to Classroom 2");
                MoveToNextRoom("Classroom2");
            }
        }
        else
        {
            ResetHit();
        }

    }

    void ShowInfoText(string text)
    {
        infoText.enabled = true;
        infoText.text = text;
    }
    void ResetHit()
    {
        delay = 0f;
        infoText.enabled = false;
        timeSlider.gameObject.SetActive(false);
    }

    void MoveToNextRoom(string nextScene)
    {
        delay += Time.deltaTime;
        timeSlider.gameObject.SetActive(true);
        timeSlider.value = delay;
        if (delay >= 2)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    void SceneInfo(string name)
    {
        switch (name)
        {
            case "Classroom":
                ShowInfoText(scene_name + "\nKME570, 5th Floor" + "\nMetropolia, Karamalmi Campus");
                break;
            case "Classroom2":
                ShowInfoText(scene_name + "\nAnother Classroom, 5th Floor" + "\nMetropolia, Karamalmi Campus");
                break;
            case "Hallway":
                ShowInfoText(scene_name + "\nFloor 5 Hallway" + "\nMetropolia, Karamalmi Campus");
                break;
            case "Outside":
                ShowInfoText(scene_name + "\nEntrance of Campus" + "\nMetropolia, Karamalmi Campus");
                break;
        }
    }
}
