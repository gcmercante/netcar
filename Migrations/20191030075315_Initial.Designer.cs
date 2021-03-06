// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Migrations
{
    [DbContext(typeof(net_car_ASPNETCOREContext))]
    [Migration("20191030075315_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Cliente", b =>
                {
                    b.Property<string>("cnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segmento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cnpj");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
