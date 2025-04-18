using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using MusicStore.Models;
using MusicStore.Views;
using System.Reactive.Concurrency;

namespace MusicStore.ViewModels;
using ReactiveUI;
using System.Windows.Input;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }
    public ICommand RemoveMusic { get; }

    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }

    public ObservableCollection<AlbumViewModel> Albums { get; } = new();
    private AlbumViewModel? _selectedAlbum;
    public AlbumViewModel? SelectedAlbum
    {
        get => _selectedAlbum;
        set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
    }
    
    public MainWindowViewModel()
    {
        RxApp.MainThreadScheduler.Schedule(LoadAlbums);
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();

        BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var store = new MusicStoreViewModel();
            var result = await ShowDialog.Handle(store);
            if (result != null)
            {
                Albums.Add(result);
                await result.SaveToDiskAsync();
            }
        });
        
        RemoveMusic = ReactiveCommand.Create(() =>
        {
            if (Albums.Count > 0 && SelectedAlbum != null)
            {
                Albums.Remove(SelectedAlbum);
                
            }
        });
        
    }

    public async void LoadAlbums()
    {
        var albums = (await Album.LoadCachedAsync()).Select(x => new AlbumViewModel(x));

        foreach (var album in albums)
        {
            Albums.Add(album);
        }

        foreach (var album in Albums.ToList())
        {
            await album.LoadCover();
        }
    }

    
}