https://forums.xamarin.com/discussion/181010/mediaplayer-is-a-namespace-but-is-used-like-a-type
### MediaPlayer is a namespace but is used like a type
```cs
myvideo.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
myvideo.MediaPlayer.Play();
```
Well, I fixed it by adding namespace in the constructor class:
```
myvideo.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(media) { EnableHardwareDecoding = true };
```
