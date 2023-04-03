﻿namespace Psysup.DataContracts;

public class ErrorResponse
{
    public int Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}