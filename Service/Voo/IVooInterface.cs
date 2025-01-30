using CrudDoYT.Models;
using CrudDoYT.Models.Voo;

namespace CrudDoYT.Service;

public interface IVooInterface 
{
    Task<ServiceResponse<String>> Create(Voo[] voos);
}