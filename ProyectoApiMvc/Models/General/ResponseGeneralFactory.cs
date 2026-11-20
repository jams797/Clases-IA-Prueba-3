using System;

namespace ProyectoApiMvc.Models.General;

public class ResponseGeneralFactory : IResponseGeneralFactory
{
    private readonly IConfiguration _configuration;
    public ResponseGeneralFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public ResponseGeneralModel<T> Create<T>(
        bool success,
        T data,
        string message,
        string? messageDev
    )
    {
        return new ResponseGeneralModel<T>(
            success,
            data,
            message,
            _configuration.GetValue<bool>("Debug") ? messageDev : null
        );
    }
}
