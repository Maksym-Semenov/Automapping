﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Project
{
    [Key]
    public int ProjectId { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; }

    public int? OrderYear { get; set; }

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public int? CustomerId { get; set; }

    public int? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }

    public int? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; }


    public virtual ContactProject? ContactProject { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
