using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Threading.Tasks;

namespace Sandbox{


    public class Program{

        //public static PrivateUser Me { get; set; }
        public static void Print(FullTrack track)
        {
            Console.WriteLine(track.Name);
            Console.WriteLine(track.Album.Name);

            foreach (var artist in track.Artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
        public static async Task Main(String[] args){
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest("Client_id","Client_secret");
            var response = await new OAuthClient(config).RequestToken(request);
            
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));
            
            Console.Title = "Spotify";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            String ans = "y";
            while (ans == "y") {
                Console.WriteLine("Enter the track id:");
                String trackId = Console.ReadLine();
                var track = await spotify.Tracks.Get(trackId);
                Print(track);
                Console.WriteLine("Want to continue?(y/n)");
                ans = Console.ReadLine();
            }

            //Me = await spotify.UserProfile.Current();
            //Console.WriteLine(Me.DisplayName);
            //Console.WriteLine(Me.Country);
            //Console.WriteLine(Me.Type);
            //foreach (Image img in Me.Images)
            //{
            //  Console.WriteLine(img.Url);
            //}

            Console.WriteLine("Thanks! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
