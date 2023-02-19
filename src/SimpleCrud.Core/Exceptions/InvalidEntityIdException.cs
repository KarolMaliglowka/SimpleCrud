﻿namespace SimpleCrud.Core.Exceptions;

public class InvalidEntityIdException : CustomException
{
    private object Id { get; }

    public InvalidEntityIdException(object id) : base($"Cannot set: {id}  as entity identifier.")
        => Id = id;
}