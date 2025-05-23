using System.Threading.Tasks;
using MusicStore.Models;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace MusicStore.ViewModels;

public class AlbumViewModel : ViewModelBase
{
    private readonly Album _album;
    public string Artist => _album.Artist;
    public string Title => _album.Title;
    private Bitmap? _cover;
    
    public AlbumViewModel(Album album)
    {
        _album = album;
    }
    

    public Bitmap? Cover
    {
        get => _cover;
        private set => this.RaiseAndSetIfChanged(ref _cover, value);
    }
    
    public async Task LoadCover()
    {
        await using (var imageStream = await _album.LoadCoverBitmapAsync())
        {
            Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
        }
    }
    
    public async Task SaveToDiskAsync()
    {
        await _album.SaveAsync();

        if (Cover != null)
        {
            var bitmap = Cover;

            await Task.Run(() =>
            {
                using (var fs = _album.SaveCoverBitmapStream())
                {
                    bitmap.Save(fs);
                }
            });
        }
    }
}