
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ExerciseDI_FeedReader
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();

            //FeedService servicePodcast = new FeedService();
            //string feed1 = servicePodcast.GetFeed();
            //Console.WriteLine(feed1);
            //Console.ReadLine();

            FeedService serviceYoutube = new FeedService(_serviceProvider.GetServices<IFeed>().ElementAt(0));
            Console.WriteLine(serviceYoutube.GetFeed());

            FeedService servicePodcast = new FeedService(_serviceProvider.GetServices<IFeed>().ElementAt(1));
            string feed = servicePodcast.GetFeed();
            Console.WriteLine(feed);

            FeedService serviceBlog = new FeedService(_serviceProvider.GetServices<IFeed>().ElementAt(2));
            Console.WriteLine(serviceBlog.GetFeed());
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IFeed, YouTubeFeedReader>();
            services.AddSingleton<IFeed, PodcastFeedReader>();
            services.AddSingleton<IFeed, BlogFeedReader>();

            _serviceProvider = services.BuildServiceProvider(true);
        }
    }
}
