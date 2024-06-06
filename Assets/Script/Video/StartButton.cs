using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);

        videoPlayer.playOnAwake = false;

        // 초기 상태에서 playButton을 활성화하고 pauseButton을 비활성화
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    void PlayVideo()
    {
        videoPlayer.Play();

        // playButton을 비활성화하고 pauseButton을 활성화
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    void PauseVideo()
    {
        videoPlayer.Pause();

        // playButton을 활성화하고 pauseButton을 비활성화
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
}
