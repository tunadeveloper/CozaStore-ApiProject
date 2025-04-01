namespace CozaStore.WebUI.Dtos.Contact
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MapURL { get; set; }
    }
}
