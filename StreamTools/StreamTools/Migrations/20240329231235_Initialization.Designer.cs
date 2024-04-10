﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreamTools.Data;

#nullable disable

namespace StreamTools.Migrations
{
    [DbContext(typeof(StreamToolsContext))]
    [Migration("20240329231235_Initialization")]
    partial class Initialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CheerShocker", b =>
                {
                    b.Property<int>("CheerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShockersCode")
                        .HasColumnType("TEXT");

                    b.HasKey("CheerId", "ShockersCode");

                    b.HasIndex("ShockersCode");

                    b.ToTable("CheerShocker");
                });

            modelBuilder.Entity("RedeemShocker", b =>
                {
                    b.Property<int>("RedeemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShockersCode")
                        .HasColumnType("TEXT");

                    b.HasKey("RedeemId", "ShockersCode");

                    b.HasIndex("ShockersCode");

                    b.ToTable("RedeemShocker");
                });

            modelBuilder.Entity("ShockerSuperChat", b =>
                {
                    b.Property<string>("ShockersCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuperChatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShockersCode", "SuperChatId");

                    b.HasIndex("SuperChatId");

                    b.ToTable("ShockerSuperChat");
                });

            modelBuilder.Entity("StreamTools.Components.Models.Cheer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intensity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Method")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumCheer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Warning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cheers", (string)null);
                });

            modelBuilder.Entity("StreamTools.Components.Models.Redeem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intensity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Method")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Warning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Redeems", (string)null);
                });

            modelBuilder.Entity("StreamTools.Components.Models.Shocker", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Shockers", (string)null);
                });

            modelBuilder.Entity("StreamTools.Components.Models.SuperChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intensity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Method")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumAmount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Warning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Superchats", (string)null);
                });

            modelBuilder.Entity("CheerShocker", b =>
                {
                    b.HasOne("StreamTools.Components.Models.Cheer", null)
                        .WithMany()
                        .HasForeignKey("CheerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StreamTools.Components.Models.Shocker", null)
                        .WithMany()
                        .HasForeignKey("ShockersCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RedeemShocker", b =>
                {
                    b.HasOne("StreamTools.Components.Models.Redeem", null)
                        .WithMany()
                        .HasForeignKey("RedeemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StreamTools.Components.Models.Shocker", null)
                        .WithMany()
                        .HasForeignKey("ShockersCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShockerSuperChat", b =>
                {
                    b.HasOne("StreamTools.Components.Models.Shocker", null)
                        .WithMany()
                        .HasForeignKey("ShockersCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StreamTools.Components.Models.SuperChat", null)
                        .WithMany()
                        .HasForeignKey("SuperChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}