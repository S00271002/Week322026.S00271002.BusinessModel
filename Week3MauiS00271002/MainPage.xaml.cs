using Plugin.Maui.Audio;

namespace Week3MauiS00271002
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        MainViewModel MainViewModel;

        public IAudioManager AudioManager { get; set; }
        public IAudioPlayer AudioPlayer { get; set; }

        public MainPage(IAudioManager audioManager)
        {
            AudioManager = audioManager;
            this.MainViewModel = new MainViewModel(AudioManager);
            BindingContext = this.MainViewModel;
            InitializeComponent();
        }
            

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            System.IO.Stream s = Task.Run(() => FileSystem.OpenAppPackageFileAsync("29.wav")).Result;
            AudioPlayer = AudioManager.CreatePlayer(s);
            AudioPlayer.Play();

            await MainViewModel.ShowTheConfettiCommand.ExecuteAsync(null);
        }
        

        protected override void OnAppearing()
        {
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                System.IO.Stream s = Task.Run(() => FileSystem.OpenAppPackageFileAsync("pnd.mp3")).Result;
                AudioPlayer = AudioManager.CreatePlayer(s);
                AudioPlayer.Play();
            });
            base.OnAppearing();
        }
    }
}
