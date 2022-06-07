﻿// <auto-generated />
using System;
using H3LibraryProject.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace H3LibraryProject.Repositories.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("LeasePeriod")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            LeasePeriod = (short)30,
                            Name = "Skønlitteratur"
                        },
                        new
                        {
                            GenreId = 2,
                            LeasePeriod = (short)7,
                            Name = "Quicklån"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Dansk"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Engelsk"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Japansk"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("date");

                    b.Property<int>("LoanerId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.HasKey("LoanId");

                    b.HasIndex("LoanerId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Loaner", b =>
                {
                    b.Property<int>("LoanerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoanerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("LoanerId");

                    b.HasIndex("LoanerTypeId");

                    b.ToTable("Loaner");

                    b.HasData(
                        new
                        {
                            LoanerId = 1,
                            LoanerTypeId = 2,
                            Name = "Simon",
                            Password = "Passw0rd"
                        },
                        new
                        {
                            LoanerId = 2,
                            LoanerTypeId = 2,
                            Name = "Robin",
                            Password = "Passw0rd"
                        },
                        new
                        {
                            LoanerId = 3,
                            LoanerTypeId = 1,
                            Name = "Flemming",
                            Password = "Passw0rd"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.LoanerType", b =>
                {
                    b.Property<int>("LoanerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("LoanerTypeId");

                    b.ToTable("LoanerTypes");

                    b.HasData(
                        new
                        {
                            LoanerTypeId = 1,
                            Name = "Låner"
                        },
                        new
                        {
                            LoanerTypeId = 2,
                            Name = "Ansat"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            Name = "Bibliotek Vest"
                        },
                        new
                        {
                            LocationId = 2,
                            Name = "Bibliotek Øst"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Home")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("MaterialId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TitleId");

                    b.ToTable("Material");

                    b.HasData(
                        new
                        {
                            MaterialId = 1,
                            Home = true,
                            LocationId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            MaterialId = 2,
                            Home = true,
                            LocationId = 2,
                            TitleId = 1
                        },
                        new
                        {
                            MaterialId = 3,
                            Home = true,
                            LocationId = 1,
                            TitleId = 2
                        },
                        new
                        {
                            MaterialId = 4,
                            Home = true,
                            LocationId = 1,
                            TitleId = 3
                        },
                        new
                        {
                            MaterialId = 5,
                            Home = true,
                            LocationId = 2,
                            TitleId = 3
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BYear")
                        .HasColumnType("int");

                    b.Property<int?>("DYear")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("MName")
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BYear = 973,
                            DYear = 1031,
                            FName = "Shibiku",
                            LName = "Murasaki",
                            NationalityId = 2
                        },
                        new
                        {
                            AuthorId = 2,
                            BYear = 1805,
                            DYear = 1875,
                            FName = "Hans",
                            LName = "Andersen",
                            MName = "Christian",
                            NationalityId = 1
                        },
                        new
                        {
                            AuthorId = 3,
                            BYear = 1821,
                            DYear = 1881,
                            FName = "Fjodor",
                            LName = "Dostoyevskij",
                            MName = "Mikhájlovitj",
                            NationalityId = 5
                        },
                        new
                        {
                            AuthorId = 4,
                            BYear = 1960,
                            FName = "Elsebeth",
                            LName = "Egholm",
                            NationalityId = 1
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Models.AuthorTitle", b =>
                {
                    b.Property<int>("AuthorTitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("AuthorTitleId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TitleId");

                    b.ToTable("AuthorTitle");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("NationalityId");

                    b.ToTable("Nationality");

                    b.HasData(
                        new
                        {
                            NationalityId = 1,
                            Name = "Danmark"
                        },
                        new
                        {
                            NationalityId = 2,
                            Name = "Japan"
                        },
                        new
                        {
                            NationalityId = 3,
                            Name = "Storbritanien"
                        },
                        new
                        {
                            NationalityId = 4,
                            Name = "USA"
                        },
                        new
                        {
                            NationalityId = 5,
                            Name = "Rusland"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            Name = "Gyldendal"
                        },
                        new
                        {
                            PublisherId = 2,
                            Name = "Lindhardt & Ringhoff"
                        },
                        new
                        {
                            PublisherId = 3,
                            Name = "People's Press"
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.Property<short>("Pages")
                        .HasColumnType("smallint");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<short>("RYear")
                        .HasColumnType("smallint");

                    b.HasKey("TitleId");

                    b.HasIndex("GenreId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Title");

                    b.HasData(
                        new
                        {
                            TitleId = 1,
                            AuthorId = 1,
                            GenreId = 1,
                            LanguageId = 3,
                            Name = "Fortællingen om Genji",
                            Pages = (short)224,
                            PublisherId = 1,
                            RYear = (short)1021
                        },
                        new
                        {
                            TitleId = 2,
                            AuthorId = 2,
                            GenreId = 1,
                            LanguageId = 1,
                            Name = "Eventyr, fortalt for Børn",
                            Pages = (short)300,
                            PublisherId = 2,
                            RYear = (short)1837
                        },
                        new
                        {
                            TitleId = 3,
                            AuthorId = 3,
                            GenreId = 1,
                            LanguageId = 1,
                            Name = "Forbrydelse og Straf",
                            Pages = (short)684,
                            PublisherId = 1,
                            RYear = (short)1866
                        },
                        new
                        {
                            TitleId = 4,
                            AuthorId = 3,
                            GenreId = 1,
                            LanguageId = 2,
                            Name = "Idioten",
                            Pages = (short)843,
                            PublisherId = 1,
                            RYear = (short)1869
                        },
                        new
                        {
                            TitleId = 5,
                            AuthorId = 4,
                            GenreId = 2,
                            LanguageId = 1,
                            Name = "Den Røde Glente",
                            Pages = (short)408,
                            PublisherId = 3,
                            RYear = (short)2022
                        });
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Loan", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.Loaner", "LoanerLoaning")
                        .WithMany("Loans")
                        .HasForeignKey("LoanerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H3LibraryProject.Repositories.Database.Material", "MaterialLoaned")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanerLoaning");

                    b.Navigation("MaterialLoaned");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Loaner", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.LoanerType", "TypeOfLoaner")
                        .WithMany()
                        .HasForeignKey("LoanerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfLoaner");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Material", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.Location", "Location")
                        .WithMany("Materials")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H3LibraryProject.Repositories.Database.Title", "Title")
                        .WithMany("Materials")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Models.Author", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Models.AuthorTitle", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H3LibraryProject.Repositories.Database.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Title", b =>
                {
                    b.HasOne("H3LibraryProject.Repositories.Database.Genre", "Genre")
                        .WithMany("Titles")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H3LibraryProject.Repositories.Database.Language", null)
                        .WithMany("Titles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Genre", b =>
                {
                    b.Navigation("Titles");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Language", b =>
                {
                    b.Navigation("Titles");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Loaner", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Location", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("H3LibraryProject.Repositories.Database.Title", b =>
                {
                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
