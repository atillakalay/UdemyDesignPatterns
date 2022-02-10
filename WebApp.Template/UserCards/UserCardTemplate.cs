using BaseProject.Models;
using System;
using System.Text;
using WebApp.Template.Models;

namespace WebApp.Template.UserCards
{
    public abstract class UserCardTemplate
    {
        protected AppUser AppUser { get; set; }

        public void SetUser(AppUser appUser)
        {
            AppUser = appUser;
        }

        public string Build()
        {
            if (AppUser == null) throw new ArgumentNullException(nameof(AppUser));

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<div class='card'>");
            stringBuilder.Append(SetPitcure());
            stringBuilder.Append($@"<div class='card-body'> <h5>{AppUser.UserName}</h5><p>{AppUser.Description}</p>");
            stringBuilder.Append(SetFooter());
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();

        }

        protected abstract string SetFooter();
        protected abstract string SetPitcure();
    }
}
