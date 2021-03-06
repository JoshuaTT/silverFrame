﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilverFrame.Model;

namespace SilverFrame.Model.Migrations
{
    [DbContext(typeof(SilverFrameContext))]
    [Migration("20181203013009_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("SilverFrame.Model.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<string>("PicturePath");

                    b.Property<bool>("include");

                    b.HasKey("PictureId");

                    b.ToTable("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
