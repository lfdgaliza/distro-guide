﻿// <auto-generated />
using System;
using DistroGuide.Domain.Repository.Impl.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    [DbContext(typeof(DistroGuideContext))]
    partial class DistroGuideContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Distros.Distro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BasedOnId");

                    b.Property<DateTime?>("End");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("BasedOnId");

                    b.ToTable("Distro");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Distros.PackageDistro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DistroId");

                    b.Property<bool>("IsOficial");

                    b.Property<bool>("IsPrincipal");

                    b.Property<Guid>("PackageId");

                    b.HasKey("Id");

                    b.HasIndex("DistroId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDistro");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.ExternalReferences.ExternalReference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExternalReferenceTypeId");

                    b.Property<bool>("IsPrincipal");

                    b.Property<string>("Reference")
                        .HasMaxLength(250);

                    b.Property<Guid>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("ExternalReferenceTypeId");

                    b.HasIndex("TargetId");

                    b.ToTable("ExternalReference");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.ExternalReferences.ExternalReferenceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ResourceId");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("ExternalReferenceType");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Packages.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<Guid>("PackageTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PackageTypeId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Packages.PackageType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ResourceId")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("PackageType");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Resources.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<Guid>("ResourceGroupId");

                    b.HasKey("Id");

                    b.HasIndex("ResourceGroupId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Resources.ResourceGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ResourceGroup");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Resources.ResourceTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language")
                        .HasMaxLength(2);

                    b.Property<Guid>("ResourceId");

                    b.Property<string>("Translation")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceTranslation");
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Distros.Distro", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Distros.Distro", "BasedOn")
                        .WithMany("ChildList")
                        .HasForeignKey("BasedOnId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Distros.PackageDistro", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Distros.Distro", "Distro")
                        .WithMany("PackageDistroList")
                        .HasForeignKey("DistroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DistroGuide.Domain.Model.Entities.Packages.Package", "Package")
                        .WithMany("PackageDistroList")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.ExternalReferences.ExternalReference", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.ExternalReferences.ExternalReferenceType", "ExternalReferenceType")
                        .WithMany("ExternalReferenceList")
                        .HasForeignKey("ExternalReferenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DistroGuide.Domain.Model.Entities.Distros.Distro")
                        .WithMany("ExternalReferenceList")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.ExternalReferences.ExternalReferenceType", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Resources.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Packages.Package", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Packages.PackageType", "PackageType")
                        .WithMany("PackageList")
                        .HasForeignKey("PackageTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Packages.PackageType", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Resources.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Resources.Resource", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Resources.ResourceGroup", "ResourceGroup")
                        .WithMany("ResourceList")
                        .HasForeignKey("ResourceGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistroGuide.Domain.Model.Entities.Resources.ResourceTranslation", b =>
                {
                    b.HasOne("DistroGuide.Domain.Model.Entities.Resources.Resource", "Resource")
                        .WithMany("ResourceTranslations")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
