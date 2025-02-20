# QuestExternalCameraFeed

## Dependencies:

* TextMeshProUGUI
* [ExternalCameraFeed](https://github.com/SimpleDevs-Dev/ExternalCameraFeed)

## Notes

Since the Quest systems are based on Android, I attempted to access the cameras attached to the Quest systems directly. However, this appears to be... impossible. Even if the `ExternalCameraFeed` system detects that there are cameras, the Unity system cannot appear to access them.

As such we must rely on external camera feeds provided by another computer or system. The idea is to pipe the footage directly from a Rasberry Pi camera into Unity via local streaming. We will attempt to set up a local stream from the Rasberry Pi system that the Unity build can access and pipe footage directly from.

## Next Steps:

* Try to set up a PiCamera system for passthrough: [https://www.youtube.com/watch?v=qs3KhLDUBmk](https://www.youtube.com/watch?v=qs3KhLDUBmk)
* Set up a camera feed to Quest: [https://stackoverflow.com/questions/39494986/streaming-live-footage-from-camera-to-unity3d](https://stackoverflow.com/questions/39494986/streaming-live-footage-from-camera-to-unity3d)
    * Somewhat related, but apparently has a potentially significant flaw with `System.Drawing`: [https://github.com/DanielArnett/SampleUnityMjpegViewer](https://github.com/DanielArnett/SampleUnityMjpegViewer)
* Basic real-time streaming: [https://forums.raspberrypi.com/viewtopic.php?f=26&t=7557&p=92461&hilit=webcam+streaming#p92461](https://forums.raspberrypi.com/viewtopic.php?f=26&t=7557&p=92461&hilit=webcam+streaming#p92461)