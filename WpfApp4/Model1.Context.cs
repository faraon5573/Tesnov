﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WpfApp4
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Entities1 : DbContext
{
    public Entities1()
        : base("name=Entities1")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<auth> auth { get; set; }

    public virtual DbSet<genders> genders { get; set; }

    public virtual DbSet<roles> roles { get; set; }

    public virtual DbSet<traits> traits { get; set; }

    public virtual DbSet<users> users { get; set; }

    public virtual DbSet<users_to_traits> users_to_traits { get; set; }

    public virtual DbSet<usersimage> usersimage { get; set; }

}

}

