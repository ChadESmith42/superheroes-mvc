﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperheroesInc.DATA.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SuperherosIncEntities : DbContext
    {
        public SuperherosIncEntities()
            : base("name=SuperherosIncEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alignment> Alignments { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<SourceOfPower> SourceOfPowers { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CourseCharacter> CourseCharacters { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
    }
}