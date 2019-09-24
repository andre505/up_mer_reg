using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UPMerchantRegistration
{
    public partial class UPAGENTMANAGERContext : DbContext
    {
        public UPAGENTMANAGERContext()
        {
        }

        public UPAGENTMANAGERContext(DbContextOptions<UPAGENTMANAGERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acctype> Acctype { get; set; }
        public virtual DbSet<Agentlga> Agentlga { get; set; }
        public virtual DbSet<Businessproprietors> Businessproprietors { get; set; }
        public virtual DbSet<Companyshareholders> Companyshareholders { get; set; }
        public virtual DbSet<Lga> Lga { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Upagent> Upagent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("host=localhost;database=UPAGENTMANAGER;user id=postgres;Password=salvador");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Acctype>(entity =>
            {
                entity.ToTable("acctype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accounttype)
                    .HasColumnName("accounttype")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Agentlga>(entity =>
            {
                entity.ToTable("agentlga");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('agent_lga_id_seq'::regclass)");

                entity.Property(e => e.Agentid)
                    .IsRequired()
                    .HasColumnName("agentid")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga10id)
                    .HasColumnName("lga10id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga1id)
                    .IsRequired()
                    .HasColumnName("lga1id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga2id)
                    .HasColumnName("lga2id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga3id)
                    .HasColumnName("lga3id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga4id)
                    .HasColumnName("lga4id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga5id)
                    .HasColumnName("lga5id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga6id)
                    .HasColumnName("lga6id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga7id)
                    .HasColumnName("lga7id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga8id)
                    .HasColumnName("lga8id")
                    .HasMaxLength(255);

                entity.Property(e => e.Lga9id)
                    .HasColumnName("lga9id")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Businessproprietors>(entity =>
            {
                entity.ToTable("businessproprietors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Lgaid).HasColumnName("lgaid");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Businessproprietors)
                    .HasForeignKey(d => d.Agentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("bus_props_agent_fk");

                entity.HasOne(d => d.Lga)
                    .WithMany(p => p.Businessproprietors)
                    .HasForeignKey(d => d.Lgaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("bus_props_lga_fk");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Businessproprietors)
                    .HasForeignKey(d => d.Stateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("bus_props_state_fk");
            });

            modelBuilder.Entity<Companyshareholders>(entity =>
            {
                entity.ToTable("companyshareholders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Lgaid).HasColumnName("lgaid");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.HasOne(d => d.Lga)
                    .WithMany(p => p.Companyshareholders)
                    .HasForeignKey(d => d.Lgaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("bus_props_lga_fk");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Companyshareholders)
                    .HasForeignKey(d => d.Stateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("comp_shldrs_state_fk");
            });

            modelBuilder.Entity<Lga>(entity =>
            {
                entity.ToTable("lga");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lganame)
                    .HasColumnName("lganame")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Lga)
                    .HasForeignKey(d => d.Stateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("lg_state_fk");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Statecode)
                    .IsRequired()
                    .HasColumnName("statecode")
                    .HasMaxLength(255);

                entity.Property(e => e.Statename)
                    .IsRequired()
                    .HasColumnName("statename")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Upagent>(entity =>
            {
                entity.ToTable("upagent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acctypeid).HasColumnName("acctypeid");

                entity.Property(e => e.Businessemail)
                    .HasColumnName("businessemail")
                    .HasMaxLength(255);

                entity.Property(e => e.Businessname)
                    .HasColumnName("businessname")
                    .HasMaxLength(255);

                entity.Property(e => e.Businessphone)
                    .HasColumnName("businessphone")
                    .HasMaxLength(255);

                entity.Property(e => e.Trandate)
                    .HasColumnName("trandate")
                    .HasMaxLength(255);

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("paymentstatus")
                    .HasMaxLength(255);

                entity.Property(e => e.Deslgaid).HasColumnName("deslgaid");

                entity.Property(e => e.Desstateid).HasColumnName("desstateid");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255);

                entity.Property(e => e.Homeaddress)
                    .HasColumnName("homeaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Selectedshareholders)
                   .HasColumnName("selectedshareholders")
                   .HasMaxLength(255);

                entity.Property(e => e.Selectedproprietors)
                   .HasColumnName("selectedproprietors")
                   .HasMaxLength(255);

                entity.Property(e => e.invoiceNumber)
                    .HasColumnName("invoicenumber")
                    .HasMaxLength(255);

                entity.Property(e => e.PATransactionid)
                    .HasColumnName("patransactionid")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Lgaid).HasColumnName("lgaid");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Natureofbusiness)
                    .IsRequired()
                    .HasColumnName("natureofbusiness")
                    .HasMaxLength(255);

                entity.Property(e => e.Noofbusinessyears)
                    .HasColumnName("noofbusinessyears")
                    .HasMaxLength(255);

                entity.Property(e => e.Noofproprietors)
                    .HasColumnName("noofproprietors")
                    .HasMaxLength(255);

                entity.Property(e => e.Noofshareholders)
                    .HasColumnName("noofshareholders")
                    .HasMaxLength(255);

                entity.Property(e => e.Officeaddress)
                    .HasColumnName("officeaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Officelgaid).HasColumnName("officelgaid");

                entity.Property(e => e.Officestateid).HasColumnName("officestateid");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(11);

                entity.Property(e => e.Profitbeforetax)
                    .HasColumnName("profitbeforetax")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcnumber)
                    .HasColumnName("rcnumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Turnover)
                    .HasColumnName("turnover")
                    .HasMaxLength(255);

                entity.Property(e => e.Personalemail)
                    .HasColumnName("personalemail")
                    .HasMaxLength(255);

                entity.Property(e => e.Selectedlgas)
                    .HasColumnName("selectedlgas")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Acctype)
                    .WithMany(p => p.Upagent)
                    .HasForeignKey(d => d.Acctypeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("acctype_accs_fk");

                entity.HasOne(d => d.Lga)
                    .WithMany(p => p.UpagentLga)
                    .HasForeignKey(d => d.Lgaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("agent_lga_fk");

                entity.HasOne(d => d.Officelga)
                    .WithMany(p => p.UpagentOfficelga)
                    .HasForeignKey(d => d.Officelgaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("des_lga_fk");

                entity.HasOne(d => d.Officestate)
                    .WithMany(p => p.UpagentOfficestate)
                    .HasForeignKey(d => d.Officestateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("des_state_fk");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.UpagentState)
                    .HasForeignKey(d => d.Stateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("agent_state_fk");
            });

            modelBuilder.HasSequence<int>("agent_lga_id_seq");
        }
    }
}
