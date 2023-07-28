namespace Blogging.DTO
{
    public class AddExternalDto
    {
        public string BlogID { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;
    }
}
