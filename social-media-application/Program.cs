using social_media_application.Classes;

try
{
    SocialMediaSystem.SetUser("XiaoGou", 5);
    SocialMediaSystem.SetUser("NuoMi", 4);
    User XiaoGou = SocialMediaSystem.GetUser("XiaoGou");
    User NuoMi = SocialMediaSystem.GetUser("NuoMi");
    SocialMediaSystem.CreatePost("Nuomi shi huaimao, dan shi mei you zha zha huai", XiaoGou);
    SocialMediaSystem.GetAllPostsByUser(XiaoGou);
    SocialMediaSystem.GetPostIdFromUser(1, XiaoGou);
    SocialMediaSystem.SetReaction("bad", NuoMi, 1);
    SocialMediaSystem.SetReaction("bad", NuoMi, 1);
    SocialMediaSystem.SetReaction("good", NuoMi, 1);
    SocialMediaSystem.SetReaction("good", XiaoGou, 1);
    SocialMediaSystem.PrintAllReactions();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}