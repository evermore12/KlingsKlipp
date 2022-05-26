namespace KlingsKlipp.AutoMapperProfiles;
using AutoMapper;
public class ClientApp : Profile
{
	public ClientApp()
	{
		CreateMap<Customer, CustomerDTO>();
        CreateMap<Booking, BookingDTO>();
        CreateMap<Day, DayDTO>();
        CreateMap<Treatment, TreatmentDTO>();
	}
}