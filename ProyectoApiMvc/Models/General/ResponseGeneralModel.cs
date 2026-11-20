using System;

namespace ProyectoApiMvc.Models.General;

public class ResponseGeneralModel<T>
{
    public bool success { get; set; }
    public T data { get; set; }
    public string message { get; set; }
    public string? messageDev { get; private set; }
    IConfiguration _configuration;

    public ResponseGeneralModel(bool success, T data, string message, string? messageDev)
    {
        this.success = success;
        this.data = data;
        this.message = message;
        this.messageDev = messageDev;
    }
}
