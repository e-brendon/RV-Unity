// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Video;
 
// public class OnlineVideoLoader : MonoBehaviour
// {
     
//     public VideoPlayer videoPlayer;
//     public string videoUrl = "yourvideourl";
     
//     // Start is called before the first frame update
//     void Start()
//     {
//         videoPlayer.url = videoUrl;
//         videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
//         videoPlayer.EnableAudioTrack (0, true);
//         videoPlayer.Prepare ();
//     }
 
//     // Update is called once per frame
//     void Update()
//     {
         
//     }
// }

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;
public class OnlineVideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    //public List<string> videoUrls = new List<string>(); // Adicione as URLs dos vídeos aqui
    public List<string> videoUrls = new List<string>{
        "https://e-brendon.github.io/RV-Unity/videos/video1.mp4",
        "https://e-brendon.github.io/RV-Unity/videos/video2.mp4"
    };
    private int currentVideoIndex = 0;

    private void Start()
    {
        videoPlayer.url = videoUrls[currentVideoIndex];
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Prepare();
    }

    public void PlayNextVideo()
    {
        currentVideoIndex++;
        if (currentVideoIndex < videoUrls.Count)
        {
            videoPlayer.url = videoUrls[currentVideoIndex];
            videoPlayer.Prepare();
        }
        else
        {
            Debug.Log("Todos os vídeos foram reproduzidos.");
            // Você pode fazer algo aqui quando todos os vídeos terminarem
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        PlayNextVideo();
    }
}