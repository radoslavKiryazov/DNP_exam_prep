
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace WebAPI.Data;

public class DataAccessImpl : IDataAccess
{
    private AlbumContext _context;

    public DataAccessImpl(AlbumContext _context)
    {
        this._context = _context;
    }


    public async Task<Album> AddAlbumAsync(Album album)
    {
        EntityEntry<Album> newAlbum = await _context.AddAsync(album);
        await _context.SaveChangesAsync();
        return newAlbum.Entity;
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        ICollection<string> titles = await _context.albums.Select(a => a.Title).ToListAsync();
        return titles;
    }

    public async Task AddImageToAlbum(Image image)
    {
        Console.WriteLine(image.Album_title);
        Console.WriteLine(image.Title);
        Console.WriteLine(image.Description);
        Console.WriteLine(image.Topic);
        Console.WriteLine(image.URI);
        EntityEntry<Image> newImage = await _context.AddAsync(image);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Image>> GetImagesAsync(string? albumCreator, string? topic)
    { ICollection<Image> images = new List<Image>();
        if (!string.IsNullOrEmpty(albumCreator) && string.IsNullOrEmpty(topic))
        {
            ICollection<string> albums = await _context.albums
                .Where(album => album.CreatedBy.Equals(albumCreator))
                .Select(album => album.Title).ToListAsync();
            images = await _context.images.Where(i => albums.Contains(i.Album_title)).ToListAsync();
        }
        else if (!string.IsNullOrEmpty(topic) && string.IsNullOrEmpty(albumCreator))
        {
            images = await _context.images.Where(i => i.Topic.Equals(topic)).ToListAsync();
        }
        else
        {
            ICollection<string> albums = await _context.albums
                .Where(album => album.CreatedBy.Equals(albumCreator))
                .Select(album => album.Title).ToListAsync();
            images = await _context.images.Where(i => albums.Contains(i.Album_title) && i.Topic.Equals(topic)).ToListAsync();
        }

        return images;
    }
}