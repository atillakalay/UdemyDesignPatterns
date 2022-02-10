namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {


        protected override string SetFooter()
        {
            return string.Empty;
        }

        protected override string SetPitcure()
        {
            return $"<img src='/UserPictures/defaultUser.png' class='card - img - top'>";
        }
    }
}
