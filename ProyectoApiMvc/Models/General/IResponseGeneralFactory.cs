using System;

namespace ProyectoApiMvc.Models.General;

public interface IResponseGeneralFactory
{
    public ResponseGeneralModel<T> Create<T>(
        bool success,
        T data,
        string message,
        string? messageDev
    );
}
