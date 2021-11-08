﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturacion.Core.Entities;

namespace Facturacion.Core.Data
{
    public class FacturacionContext : DbContext
    {
        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<Producto> Producto { get; set; }

    }
}
