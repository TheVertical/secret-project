namespace SecretProject.VisualElements.Elements
{
    public class LinkItem
    {
        public LinkItem()
        {

        }
        public LinkItem(int id, string title, string link)
        {
            Id = id;
            Title = title;
            Link = link;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

    }
}