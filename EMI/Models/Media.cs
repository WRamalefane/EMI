using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMI.Models
{
    public class Media
    {
      

        public string VideoID { get; set; }


        public string VideoTitle { get; set; }


        public string VideoSource { get; set; }

        public List<Media> GetMedia()
        {

            List<Media> medium = new List<Media>();

            Media mediaItem = new Media();

            mediaItem.VideoID = "1";
            mediaItem.VideoSource = "https://www.youtube.com/embed/5PVwtF2Ir_c?rel=0";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);

            mediaItem = new Media();
            mediaItem.VideoID = "2";
            mediaItem.VideoSource = "https://www.youtube.com/embed/fa6L_QnAEn4?rel=0";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);

            mediaItem = new Media();
            mediaItem.VideoID = "3";
            mediaItem.VideoSource = "https://www.youtube.com/embed/TWsEuBcVVkc?rel=0";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);

            mediaItem = new Media();
            mediaItem.VideoID = "4";
            mediaItem.VideoSource = "https://www.youtube.com/embed/AC4GCyz-0No?rel=0";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);

            mediaItem = new Media();
            mediaItem.VideoID = "5";
            mediaItem.VideoSource = "https://www.youtube.com/embed/_DvIN7AewPE?rel=0";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);

            mediaItem = new Media();
            mediaItem.VideoID = "6";
            mediaItem.VideoSource = "https://www.youtube.com/embed/gyG_SkvslYk";
            mediaItem.VideoTitle = "";
            medium.Add(mediaItem);
            return medium;

        }
 
    }
}