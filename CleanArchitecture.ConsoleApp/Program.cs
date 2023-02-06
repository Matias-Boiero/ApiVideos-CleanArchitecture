using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext streamerDbContext = new StreamerDbContext();
//await AddNewRecords();
//QueryStream();
//await AddStreamerWhitVideo();
//await AddNewActorWhitVideo();
await AddNewDirectorWhitVideo();



void QueryStream()
{
    var streamers = streamerDbContext.Streamers.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
    }
}
async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://wwww.Disney.com"
    };

    //Hago un add de prueba a la base de datos
    streamerDbContext.Streamers.Add(streamer);
    await streamerDbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Nombre= "Tarzán",
        StreamerId=streamer.Id,
        },
    new Video
    {
        Nombre="La cenicienta",
        StreamerId = streamer.Id,
    },
     new Video
    {
        Nombre="Coco",
        StreamerId = streamer.Id,
    },

};

    streamerDbContext.AddRange(movies);
    await streamerDbContext.SaveChangesAsync();
}

async Task AddStreamerWhitVideo()
{
    var HBO = new Streamer()
    {
        Nombre = "HBO"
    };

    var Anabelle = new Video()
    {
        Nombre = "Anabelle",
        Streamer = HBO
    };

    await streamerDbContext.AddAsync(Anabelle);
    await streamerDbContext.SaveChangesAsync();
}

async Task AddNewActorWhitVideo()
{
    var actor = new Actor()
    {
        Nombre = "Tom Hanks"
    };
    await streamerDbContext.AddAsync(actor);
    await streamerDbContext.SaveChangesAsync();

    var videoActor = new VideoActor()
    {
        ActorId = actor.Id,
        VideoId = 2
    };

    await streamerDbContext.AddAsync(videoActor);
    await streamerDbContext.SaveChangesAsync();
}

async Task AddNewDirectorWhitVideo()
{
    var director = new Director()
    {
        Nombre = "Steben",
        Apellido = "Spilberg",
        VideoId = 2
    };
    await streamerDbContext.AddAsync(director);
    await streamerDbContext.SaveChangesAsync();
}