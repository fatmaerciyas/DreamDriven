using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class BackgroundImage : EntityBase
    {
        public BackgroundImage()
        {
        }

        public BackgroundImage(string url, DateTime updated_date, int categoryId)
        {
            Updated_Date = updated_date;
            CategoryId = categoryId;
            Url = url;
        }

        public string Url { get; set; }
        public DateTime Updated_At { get; set; }

        //Category
        public int Category_Id { get; set; }
        public Category Category { get; set; }
        public DateTime Updated_Date { get; }
        public int CategoryId { get; }
    }
}
