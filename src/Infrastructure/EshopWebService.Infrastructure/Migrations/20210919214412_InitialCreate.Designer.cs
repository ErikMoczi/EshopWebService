// <auto-generated />
using EshopWebService.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EshopWebService.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210919214412_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EshopWebService.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "HelloWorld-1",
                            ImgUri = "/media/1/file1.png",
                            Name = "Product-1",
                            Price = 2.3m
                        },
                        new
                        {
                            Id = 2,
                            Description = "HelloWorld-2",
                            ImgUri = "/media/2/file2.png",
                            Name = "Product-2",
                            Price = 4.6m
                        },
                        new
                        {
                            Id = 3,
                            Description = "HelloWorld-3",
                            ImgUri = "/media/3/file3.png",
                            Name = "Product-3",
                            Price = 6.9m
                        },
                        new
                        {
                            Id = 4,
                            Description = "HelloWorld-4",
                            ImgUri = "/media/4/file4.png",
                            Name = "Product-4",
                            Price = 9.2m
                        },
                        new
                        {
                            Id = 5,
                            Description = "HelloWorld-5",
                            ImgUri = "/media/5/file5.png",
                            Name = "Product-5",
                            Price = 11.5m
                        },
                        new
                        {
                            Id = 6,
                            Description = "HelloWorld-6",
                            ImgUri = "/media/6/file6.png",
                            Name = "Product-6",
                            Price = 13.8m
                        },
                        new
                        {
                            Id = 7,
                            Description = "HelloWorld-7",
                            ImgUri = "/media/7/file7.png",
                            Name = "Product-7",
                            Price = 16.1m
                        },
                        new
                        {
                            Id = 8,
                            Description = "HelloWorld-8",
                            ImgUri = "/media/8/file8.png",
                            Name = "Product-8",
                            Price = 18.4m
                        },
                        new
                        {
                            Id = 9,
                            Description = "HelloWorld-9",
                            ImgUri = "/media/9/file9.png",
                            Name = "Product-9",
                            Price = 20.7m
                        },
                        new
                        {
                            Id = 10,
                            Description = "HelloWorld-10",
                            ImgUri = "/media/10/file10.png",
                            Name = "Product-10",
                            Price = 23.0m
                        },
                        new
                        {
                            Id = 11,
                            Description = "HelloWorld-11",
                            ImgUri = "/media/11/file11.png",
                            Name = "Product-11",
                            Price = 25.3m
                        },
                        new
                        {
                            Id = 12,
                            Description = "HelloWorld-12",
                            ImgUri = "/media/12/file12.png",
                            Name = "Product-12",
                            Price = 27.6m
                        },
                        new
                        {
                            Id = 13,
                            Description = "HelloWorld-13",
                            ImgUri = "/media/13/file13.png",
                            Name = "Product-13",
                            Price = 29.9m
                        },
                        new
                        {
                            Id = 14,
                            Description = "HelloWorld-14",
                            ImgUri = "/media/14/file14.png",
                            Name = "Product-14",
                            Price = 32.2m
                        },
                        new
                        {
                            Id = 15,
                            Description = "HelloWorld-15",
                            ImgUri = "/media/15/file15.png",
                            Name = "Product-15",
                            Price = 34.5m
                        },
                        new
                        {
                            Id = 16,
                            Description = "HelloWorld-16",
                            ImgUri = "/media/16/file16.png",
                            Name = "Product-16",
                            Price = 36.8m
                        },
                        new
                        {
                            Id = 17,
                            Description = "HelloWorld-17",
                            ImgUri = "/media/17/file17.png",
                            Name = "Product-17",
                            Price = 39.1m
                        },
                        new
                        {
                            Id = 18,
                            Description = "HelloWorld-18",
                            ImgUri = "/media/18/file18.png",
                            Name = "Product-18",
                            Price = 41.4m
                        },
                        new
                        {
                            Id = 19,
                            Description = "HelloWorld-19",
                            ImgUri = "/media/19/file19.png",
                            Name = "Product-19",
                            Price = 43.7m
                        },
                        new
                        {
                            Id = 20,
                            Description = "HelloWorld-20",
                            ImgUri = "/media/20/file20.png",
                            Name = "Product-20",
                            Price = 46.0m
                        },
                        new
                        {
                            Id = 21,
                            Description = "HelloWorld-21",
                            ImgUri = "/media/21/file21.png",
                            Name = "Product-21",
                            Price = 48.3m
                        },
                        new
                        {
                            Id = 22,
                            Description = "HelloWorld-22",
                            ImgUri = "/media/22/file22.png",
                            Name = "Product-22",
                            Price = 50.6m
                        },
                        new
                        {
                            Id = 23,
                            Description = "HelloWorld-23",
                            ImgUri = "/media/23/file23.png",
                            Name = "Product-23",
                            Price = 52.9m
                        },
                        new
                        {
                            Id = 24,
                            Description = "HelloWorld-24",
                            ImgUri = "/media/24/file24.png",
                            Name = "Product-24",
                            Price = 55.2m
                        },
                        new
                        {
                            Id = 25,
                            Description = "HelloWorld-25",
                            ImgUri = "/media/25/file25.png",
                            Name = "Product-25",
                            Price = 57.5m
                        },
                        new
                        {
                            Id = 26,
                            Description = "HelloWorld-26",
                            ImgUri = "/media/26/file26.png",
                            Name = "Product-26",
                            Price = 59.8m
                        },
                        new
                        {
                            Id = 27,
                            Description = "HelloWorld-27",
                            ImgUri = "/media/27/file27.png",
                            Name = "Product-27",
                            Price = 62.1m
                        },
                        new
                        {
                            Id = 28,
                            Description = "HelloWorld-28",
                            ImgUri = "/media/28/file28.png",
                            Name = "Product-28",
                            Price = 64.4m
                        },
                        new
                        {
                            Id = 29,
                            Description = "HelloWorld-29",
                            ImgUri = "/media/29/file29.png",
                            Name = "Product-29",
                            Price = 66.7m
                        },
                        new
                        {
                            Id = 30,
                            Description = "HelloWorld-30",
                            ImgUri = "/media/30/file30.png",
                            Name = "Product-30",
                            Price = 69.0m
                        },
                        new
                        {
                            Id = 31,
                            Description = "HelloWorld-31",
                            ImgUri = "/media/31/file31.png",
                            Name = "Product-31",
                            Price = 71.3m
                        },
                        new
                        {
                            Id = 32,
                            Description = "HelloWorld-32",
                            ImgUri = "/media/32/file32.png",
                            Name = "Product-32",
                            Price = 73.6m
                        },
                        new
                        {
                            Id = 33,
                            Description = "HelloWorld-33",
                            ImgUri = "/media/33/file33.png",
                            Name = "Product-33",
                            Price = 75.9m
                        },
                        new
                        {
                            Id = 34,
                            Description = "HelloWorld-34",
                            ImgUri = "/media/34/file34.png",
                            Name = "Product-34",
                            Price = 78.2m
                        },
                        new
                        {
                            Id = 35,
                            Description = "HelloWorld-35",
                            ImgUri = "/media/35/file35.png",
                            Name = "Product-35",
                            Price = 80.5m
                        },
                        new
                        {
                            Id = 36,
                            Description = "HelloWorld-36",
                            ImgUri = "/media/36/file36.png",
                            Name = "Product-36",
                            Price = 82.8m
                        },
                        new
                        {
                            Id = 37,
                            Description = "HelloWorld-37",
                            ImgUri = "/media/37/file37.png",
                            Name = "Product-37",
                            Price = 85.1m
                        },
                        new
                        {
                            Id = 38,
                            Description = "HelloWorld-38",
                            ImgUri = "/media/38/file38.png",
                            Name = "Product-38",
                            Price = 87.4m
                        },
                        new
                        {
                            Id = 39,
                            Description = "HelloWorld-39",
                            ImgUri = "/media/39/file39.png",
                            Name = "Product-39",
                            Price = 89.7m
                        },
                        new
                        {
                            Id = 40,
                            Description = "HelloWorld-40",
                            ImgUri = "/media/40/file40.png",
                            Name = "Product-40",
                            Price = 92.0m
                        },
                        new
                        {
                            Id = 41,
                            Description = "HelloWorld-41",
                            ImgUri = "/media/41/file41.png",
                            Name = "Product-41",
                            Price = 94.3m
                        },
                        new
                        {
                            Id = 42,
                            Description = "HelloWorld-42",
                            ImgUri = "/media/42/file42.png",
                            Name = "Product-42",
                            Price = 96.6m
                        },
                        new
                        {
                            Id = 43,
                            Description = "HelloWorld-43",
                            ImgUri = "/media/43/file43.png",
                            Name = "Product-43",
                            Price = 98.9m
                        },
                        new
                        {
                            Id = 44,
                            Description = "HelloWorld-44",
                            ImgUri = "/media/44/file44.png",
                            Name = "Product-44",
                            Price = 101.2m
                        },
                        new
                        {
                            Id = 45,
                            Description = "HelloWorld-45",
                            ImgUri = "/media/45/file45.png",
                            Name = "Product-45",
                            Price = 103.5m
                        },
                        new
                        {
                            Id = 46,
                            Description = "HelloWorld-46",
                            ImgUri = "/media/46/file46.png",
                            Name = "Product-46",
                            Price = 105.8m
                        },
                        new
                        {
                            Id = 47,
                            Description = "HelloWorld-47",
                            ImgUri = "/media/47/file47.png",
                            Name = "Product-47",
                            Price = 108.1m
                        },
                        new
                        {
                            Id = 48,
                            Description = "HelloWorld-48",
                            ImgUri = "/media/48/file48.png",
                            Name = "Product-48",
                            Price = 110.4m
                        },
                        new
                        {
                            Id = 49,
                            Description = "HelloWorld-49",
                            ImgUri = "/media/49/file49.png",
                            Name = "Product-49",
                            Price = 112.7m
                        },
                        new
                        {
                            Id = 50,
                            Description = "HelloWorld-50",
                            ImgUri = "/media/50/file50.png",
                            Name = "Product-50",
                            Price = 115.0m
                        },
                        new
                        {
                            Id = 51,
                            Description = "HelloWorld-51",
                            ImgUri = "/media/51/file51.png",
                            Name = "Product-51",
                            Price = 117.3m
                        },
                        new
                        {
                            Id = 52,
                            Description = "HelloWorld-52",
                            ImgUri = "/media/52/file52.png",
                            Name = "Product-52",
                            Price = 119.6m
                        },
                        new
                        {
                            Id = 53,
                            Description = "HelloWorld-53",
                            ImgUri = "/media/53/file53.png",
                            Name = "Product-53",
                            Price = 121.9m
                        },
                        new
                        {
                            Id = 54,
                            Description = "HelloWorld-54",
                            ImgUri = "/media/54/file54.png",
                            Name = "Product-54",
                            Price = 124.2m
                        },
                        new
                        {
                            Id = 55,
                            Description = "HelloWorld-55",
                            ImgUri = "/media/55/file55.png",
                            Name = "Product-55",
                            Price = 126.5m
                        },
                        new
                        {
                            Id = 56,
                            Description = "HelloWorld-56",
                            ImgUri = "/media/56/file56.png",
                            Name = "Product-56",
                            Price = 128.8m
                        },
                        new
                        {
                            Id = 57,
                            Description = "HelloWorld-57",
                            ImgUri = "/media/57/file57.png",
                            Name = "Product-57",
                            Price = 131.1m
                        },
                        new
                        {
                            Id = 58,
                            Description = "HelloWorld-58",
                            ImgUri = "/media/58/file58.png",
                            Name = "Product-58",
                            Price = 133.4m
                        },
                        new
                        {
                            Id = 59,
                            Description = "HelloWorld-59",
                            ImgUri = "/media/59/file59.png",
                            Name = "Product-59",
                            Price = 135.7m
                        },
                        new
                        {
                            Id = 60,
                            Description = "HelloWorld-60",
                            ImgUri = "/media/60/file60.png",
                            Name = "Product-60",
                            Price = 138.0m
                        },
                        new
                        {
                            Id = 61,
                            Description = "HelloWorld-61",
                            ImgUri = "/media/61/file61.png",
                            Name = "Product-61",
                            Price = 140.3m
                        },
                        new
                        {
                            Id = 62,
                            Description = "HelloWorld-62",
                            ImgUri = "/media/62/file62.png",
                            Name = "Product-62",
                            Price = 142.6m
                        },
                        new
                        {
                            Id = 63,
                            Description = "HelloWorld-63",
                            ImgUri = "/media/63/file63.png",
                            Name = "Product-63",
                            Price = 144.9m
                        },
                        new
                        {
                            Id = 64,
                            Description = "HelloWorld-64",
                            ImgUri = "/media/64/file64.png",
                            Name = "Product-64",
                            Price = 147.2m
                        },
                        new
                        {
                            Id = 65,
                            Description = "HelloWorld-65",
                            ImgUri = "/media/65/file65.png",
                            Name = "Product-65",
                            Price = 149.5m
                        },
                        new
                        {
                            Id = 66,
                            Description = "HelloWorld-66",
                            ImgUri = "/media/66/file66.png",
                            Name = "Product-66",
                            Price = 151.8m
                        },
                        new
                        {
                            Id = 67,
                            Description = "HelloWorld-67",
                            ImgUri = "/media/67/file67.png",
                            Name = "Product-67",
                            Price = 154.1m
                        },
                        new
                        {
                            Id = 68,
                            Description = "HelloWorld-68",
                            ImgUri = "/media/68/file68.png",
                            Name = "Product-68",
                            Price = 156.4m
                        },
                        new
                        {
                            Id = 69,
                            Description = "HelloWorld-69",
                            ImgUri = "/media/69/file69.png",
                            Name = "Product-69",
                            Price = 158.7m
                        },
                        new
                        {
                            Id = 70,
                            Description = "HelloWorld-70",
                            ImgUri = "/media/70/file70.png",
                            Name = "Product-70",
                            Price = 161.0m
                        },
                        new
                        {
                            Id = 71,
                            Description = "HelloWorld-71",
                            ImgUri = "/media/71/file71.png",
                            Name = "Product-71",
                            Price = 163.3m
                        },
                        new
                        {
                            Id = 72,
                            Description = "HelloWorld-72",
                            ImgUri = "/media/72/file72.png",
                            Name = "Product-72",
                            Price = 165.6m
                        },
                        new
                        {
                            Id = 73,
                            Description = "HelloWorld-73",
                            ImgUri = "/media/73/file73.png",
                            Name = "Product-73",
                            Price = 167.9m
                        },
                        new
                        {
                            Id = 74,
                            Description = "HelloWorld-74",
                            ImgUri = "/media/74/file74.png",
                            Name = "Product-74",
                            Price = 170.2m
                        },
                        new
                        {
                            Id = 75,
                            Description = "HelloWorld-75",
                            ImgUri = "/media/75/file75.png",
                            Name = "Product-75",
                            Price = 172.5m
                        },
                        new
                        {
                            Id = 76,
                            Description = "HelloWorld-76",
                            ImgUri = "/media/76/file76.png",
                            Name = "Product-76",
                            Price = 174.8m
                        },
                        new
                        {
                            Id = 77,
                            Description = "HelloWorld-77",
                            ImgUri = "/media/77/file77.png",
                            Name = "Product-77",
                            Price = 177.1m
                        },
                        new
                        {
                            Id = 78,
                            Description = "HelloWorld-78",
                            ImgUri = "/media/78/file78.png",
                            Name = "Product-78",
                            Price = 179.4m
                        },
                        new
                        {
                            Id = 79,
                            Description = "HelloWorld-79",
                            ImgUri = "/media/79/file79.png",
                            Name = "Product-79",
                            Price = 181.7m
                        },
                        new
                        {
                            Id = 80,
                            Description = "HelloWorld-80",
                            ImgUri = "/media/80/file80.png",
                            Name = "Product-80",
                            Price = 184.0m
                        },
                        new
                        {
                            Id = 81,
                            Description = "HelloWorld-81",
                            ImgUri = "/media/81/file81.png",
                            Name = "Product-81",
                            Price = 186.3m
                        },
                        new
                        {
                            Id = 82,
                            Description = "HelloWorld-82",
                            ImgUri = "/media/82/file82.png",
                            Name = "Product-82",
                            Price = 188.6m
                        },
                        new
                        {
                            Id = 83,
                            Description = "HelloWorld-83",
                            ImgUri = "/media/83/file83.png",
                            Name = "Product-83",
                            Price = 190.9m
                        },
                        new
                        {
                            Id = 84,
                            Description = "HelloWorld-84",
                            ImgUri = "/media/84/file84.png",
                            Name = "Product-84",
                            Price = 193.2m
                        },
                        new
                        {
                            Id = 85,
                            Description = "HelloWorld-85",
                            ImgUri = "/media/85/file85.png",
                            Name = "Product-85",
                            Price = 195.5m
                        },
                        new
                        {
                            Id = 86,
                            Description = "HelloWorld-86",
                            ImgUri = "/media/86/file86.png",
                            Name = "Product-86",
                            Price = 197.8m
                        },
                        new
                        {
                            Id = 87,
                            Description = "HelloWorld-87",
                            ImgUri = "/media/87/file87.png",
                            Name = "Product-87",
                            Price = 200.1m
                        },
                        new
                        {
                            Id = 88,
                            Description = "HelloWorld-88",
                            ImgUri = "/media/88/file88.png",
                            Name = "Product-88",
                            Price = 202.4m
                        },
                        new
                        {
                            Id = 89,
                            Description = "HelloWorld-89",
                            ImgUri = "/media/89/file89.png",
                            Name = "Product-89",
                            Price = 204.7m
                        },
                        new
                        {
                            Id = 90,
                            Description = "HelloWorld-90",
                            ImgUri = "/media/90/file90.png",
                            Name = "Product-90",
                            Price = 207.0m
                        },
                        new
                        {
                            Id = 91,
                            Description = "HelloWorld-91",
                            ImgUri = "/media/91/file91.png",
                            Name = "Product-91",
                            Price = 209.3m
                        },
                        new
                        {
                            Id = 92,
                            Description = "HelloWorld-92",
                            ImgUri = "/media/92/file92.png",
                            Name = "Product-92",
                            Price = 211.6m
                        },
                        new
                        {
                            Id = 93,
                            Description = "HelloWorld-93",
                            ImgUri = "/media/93/file93.png",
                            Name = "Product-93",
                            Price = 213.9m
                        },
                        new
                        {
                            Id = 94,
                            Description = "HelloWorld-94",
                            ImgUri = "/media/94/file94.png",
                            Name = "Product-94",
                            Price = 216.2m
                        },
                        new
                        {
                            Id = 95,
                            Description = "HelloWorld-95",
                            ImgUri = "/media/95/file95.png",
                            Name = "Product-95",
                            Price = 218.5m
                        },
                        new
                        {
                            Id = 96,
                            Description = "HelloWorld-96",
                            ImgUri = "/media/96/file96.png",
                            Name = "Product-96",
                            Price = 220.8m
                        },
                        new
                        {
                            Id = 97,
                            Description = "HelloWorld-97",
                            ImgUri = "/media/97/file97.png",
                            Name = "Product-97",
                            Price = 223.1m
                        },
                        new
                        {
                            Id = 98,
                            Description = "HelloWorld-98",
                            ImgUri = "/media/98/file98.png",
                            Name = "Product-98",
                            Price = 225.4m
                        },
                        new
                        {
                            Id = 99,
                            Description = "HelloWorld-99",
                            ImgUri = "/media/99/file99.png",
                            Name = "Product-99",
                            Price = 227.7m
                        },
                        new
                        {
                            Id = 100,
                            Description = "HelloWorld-100",
                            ImgUri = "/media/100/file100.png",
                            Name = "Product-100",
                            Price = 230.0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
