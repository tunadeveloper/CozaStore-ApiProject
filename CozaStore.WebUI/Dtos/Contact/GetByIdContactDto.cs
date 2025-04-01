namespace CozaStore.WebUI.Dtos.Contact
{
    public class GetByIdContactDto
    {
        public int ContactID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MapURL { get; set; }
    }
}
