namespace HotelListing.api.Data;

public class Hotel
{
   public int Id { get; set; }
    public string Name { get; set; }

    public string Adress { get; set; }

    public string Ratting { get; set; }
    public int CountryId { get; set; }
    public  Country? country { get; set; }

}
