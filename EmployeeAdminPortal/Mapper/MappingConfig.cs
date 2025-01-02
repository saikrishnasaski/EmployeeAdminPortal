using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Mapster;

namespace EmployeeAdminPortal.Mapper;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateEmployeeRequest, Employee>.NewConfig();
        TypeAdapterConfig<UpdateEmployeeRequest, Employee>.NewConfig();
    }
}