﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectDBEntities : DbContext
    {
        public ProjectDBEntities()
            : base("name=ProjectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CodigoPostal> CodigoPostal { get; set; }
        public virtual DbSet<InformacoesUteis> InformacoesUteis { get; set; }
        public virtual DbSet<Ocorrencias> Ocorrencias { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoOcorrencias> TipoOcorrencias { get; set; }
        public virtual DbSet<TipoUtilizador> TipoUtilizador { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
    }
}
