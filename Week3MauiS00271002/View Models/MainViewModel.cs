using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3MauiS00271002
{
    public partial class MainViewModel : ObservableObject
    {
        public IAudioManager AudioManager { get; set; }
        public IAudioPlayer AudioPlayer { get; set; }
        public MainViewModel(IAudioManager audioManager) {
            AudioManager = audioManager;
        }

        [ObservableProperty]
        public bool showConfetti = false;

        [RelayCommand]
        public async Task ShowTheConfetti()
        {
            ShowConfetti = true;
            await Task.Delay(1500); // Show for 3 seconds
            ShowConfetti = false;
        }

        [RelayCommand]
        public void PlaySound(string Sound)
        {
            System.IO.Stream s = Task.Run(() => FileSystem.OpenAppPackageFileAsync(Sound)).Result ;
            AudioPlayer = AudioManager.CreatePlayer(s);
            AudioPlayer.Play();
            ShowTheConfettiCommand.ExecuteAsync(null);
        }

    }
}
