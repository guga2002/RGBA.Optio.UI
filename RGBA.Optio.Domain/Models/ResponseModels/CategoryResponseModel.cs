
namespace RGBA.Optio.Domain.Models.ResponseModels
{
    public class CategoryResponseModel
    {
        public  string TransactionCategory { get; set; }
        public  long TransactionTypeID { get; set; }
        public long TransactionCount {  get; set; }
        public long TransactionVolume {  get; set; }
    }
}
