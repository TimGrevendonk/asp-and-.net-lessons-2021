using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
//          een variabele met een _ voor is automatish als private gezien.
        private readonly IFeed _reader;

        public FeedService(IFeed reader)
        {
            _reader = reader;
        }
        public string GetFeed()
        {
            //PodcastFeedReader podcast = new PodcastFeedReader();
            //return podcast.GetSingleFeed() ;

            return _reader.GetSingleFeed();
        }
    }
}
