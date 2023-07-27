namespace Blogging.DTO
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
