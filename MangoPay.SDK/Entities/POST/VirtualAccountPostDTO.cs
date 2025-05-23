namespace MangoPay.SDK.Entities.POST
{
    public class VirtualAccountPostDTO : EntityPostBase
    {
        public VirtualAccountPostDTO()
        {
            
        }

        public string VirtualAccountPurpose { get; set; }

        public string Country { get; set; }
    }
}