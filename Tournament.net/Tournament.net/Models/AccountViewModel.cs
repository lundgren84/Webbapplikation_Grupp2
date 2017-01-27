using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.net.Models
{
    public class AccountViewModel
    {
        public Guid id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }
    }
    public class AccountInTournamentViewModel
    {
        public Guid id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }
        public int WindowSpot { get; set; }
        public int TournamentPosition { get; set; }
    }
    public class AccountInHighscoreViewModel
    {
        public Guid id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }
        public int Score { get; set; }
    }
}