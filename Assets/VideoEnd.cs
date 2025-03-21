using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEnd : MonoBehaviour
{
    public VideoPlayer video;
    public string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"video {video.time} {video.clip.length}");
        if((video.clip.length - video.time) <= 0.1)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
