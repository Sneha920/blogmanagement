namespace BlogManagement.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public string[] Tags { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
