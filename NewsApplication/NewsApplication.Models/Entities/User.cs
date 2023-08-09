﻿using Microsoft.AspNetCore.Identity;

namespace NewsApplication.Models.Entities;

public class User : IdentityUser<int>
{
    public string Name { get; set; }
}