﻿using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class CoincideContext : DbContext
{
    public CoincideContext(DbContextOptions<CoincideContext> options) : base(options) { }

}
