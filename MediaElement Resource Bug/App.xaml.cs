using System.Diagnostics;
using CommunityToolkit.Maui.Views;

namespace MediaElement_Resource_Bug {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MediaElement mediaElement = new ();
            //mediaElement.Source = MediaSource.FromUri("https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4"); //alternative video link: https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4
            //mediaElement.Source = "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4";
            //mediaElement.Source = MediaSource.FromResource("big_buck_bunny_720p_1mb.mp4");
            mediaElement.Source = MediaSource.FromResource("MediaElement_Resource_Bug.Resources.Raw.big_buck_bunny_720p_1mb.mp4");
            
            mediaElement.ShouldShowPlaybackControls = false;
            mediaElement.ShouldAutoPlay = true;
            mediaElement.ShouldLoopPlayback = true;
            mediaElement.Play();
            
            MainPage = new ContentPage();
            (MainPage as ContentPage).Content = mediaElement;

            //Debug Resources to test if embedded:
            TapGestureRecognizer gesture = new();
            mediaElement.GestureRecognizers.Add(gesture);
            gesture.Tapped += delegate {
                foreach (string currentResource in System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()) {
                    Debug.WriteLine(currentResource);
                }
            };
        }
    }
}