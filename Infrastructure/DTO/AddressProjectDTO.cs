﻿namespace CredensPet.Infrastructure.DTO;

public class AddressProjectDTO
{
    public string Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? ResidentialComplex { get; set; }

    public string? TypeStreet { get; set; }

    public string? Street { get; set; }

    public string? BuildingNumber { get; set; }

    public string? Litera { get; set; }

    public string? BuildingPart { get; set; }

    public int? Apt { get; set; }

    public string? Floor { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public string ProjectId { get; set; }

}