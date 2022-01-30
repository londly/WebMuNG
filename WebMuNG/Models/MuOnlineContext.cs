using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebMuNG
{
    public partial class MuOnlineContext : DbContext
    {
        public MuOnlineContext()
        {
        }

        public MuOnlineContext(DbContextOptions<MuOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountCharacter> AccountCharacters { get; set; }
        public virtual DbSet<CMonsterKillCount> CMonsterKillCounts { get; set; }
        public virtual DbSet<CPlayerKillerInfo> CPlayerKillerInfos { get; set; }
        public virtual DbSet<ChangeClass> ChangeClasses { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterRealTime> CharacterRealTimes { get; set; }
        public virtual DbSet<ConnectionHistory> ConnectionHistories { get; set; }
        public virtual DbSet<DefaultClassType> DefaultClassTypes { get; set; }
        public virtual DbSet<EventEntryCount> EventEntryCounts { get; set; }
        public virtual DbSet<EventLeoTheHelper> EventLeoTheHelpers { get; set; }
        public virtual DbSet<EventSantaClau> EventSantaClaus { get; set; }
        public virtual DbSet<ExtWarehouse> ExtWarehouses { get; set; }
        public virtual DbSet<GameServerInfo> GameServerInfos { get; set; }
        public virtual DbSet<GuideQuest> GuideQuests { get; set; }
        public virtual DbSet<Guild> Guilds { get; set; }
        public virtual DbSet<GuildMember> GuildMembers { get; set; }
        public virtual DbSet<HelperDatum> HelperData { get; set; }
        public virtual DbSet<MasterSkillTree> MasterSkillTrees { get; set; }
        public virtual DbSet<MembCredit> MembCredits { get; set; }
        public virtual DbSet<MembInfo> MembInfos { get; set; }
        public virtual DbSet<MembStat> MembStats { get; set; }
        public virtual DbSet<MuDbid> MuDbids { get; set; }
        public virtual DbSet<MuHelper> MuHelpers { get; set; }
        public virtual DbSet<MultiWarehouse> MultiWarehouses { get; set; }
        public virtual DbSet<RankingBloodCastle> RankingBloodCastles { get; set; }
        public virtual DbSet<RankingCastleSiege> RankingCastleSieges { get; set; }
        public virtual DbSet<RankingChaosCastle> RankingChaosCastles { get; set; }
        public virtual DbSet<RankingDevilSquare> RankingDevilSquares { get; set; }
        public virtual DbSet<RankingDuel> RankingDuels { get; set; }
        public virtual DbSet<RankingIllusionTemple> RankingIllusionTemples { get; set; }
        public virtual DbSet<ReconnectDatum> ReconnectData { get; set; }
        public virtual DbSet<ReconnectOfflineDatum> ReconnectOfflineData { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SCG107I;Database=MuOnline;User Id=sa;Password=test;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountCharacter>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("AccountCharacter");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameId1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameID1");

                entity.Property(e => e.GameId2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameID2");

                entity.Property(e => e.GameId3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameID3");

                entity.Property(e => e.GameId4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameID4");

                entity.Property(e => e.GameId5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameID5");

                entity.Property(e => e.GameIdc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GameIDC");

                entity.Property(e => e.MoveCnt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Number).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CMonsterKillCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("C_Monster_KillCount");

                entity.HasIndex(e => new { e.Name, e.MonsterId }, "IX_C_Monster_KillCount")
                    .IsUnique();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CPlayerKillerInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("C_PlayerKiller_Info");

                entity.Property(e => e.KillDate).HasColumnType("datetime");

                entity.Property(e => e.Killer)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Victim)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChangeClass>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("ChangeClass");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .IsClustered(false);

                entity.ToTable("Character");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Bp).HasColumnName("BP");

                entity.Property(e => e.CLevel)
                    .HasColumnName("cLevel")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ChatLimitTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.CtlCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.DbVersion).HasDefaultValueSql("((0))");

                entity.Property(e => e.DmnLastServerPkCount).HasColumnName("dmn_last_server_pk_count");

                entity.Property(e => e.DmnPkCount).HasColumnName("dmn_pk_count");

                entity.Property(e => e.EffectList).HasMaxLength(208);

                entity.Property(e => e.Experience).HasDefaultValueSql("((0))");

                entity.Property(e => e.FruitPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrandResets).HasColumnName("grand_resets");

                entity.Property(e => e.Inventory).HasMaxLength(3776);

                entity.Property(e => e.LastGresetTime).HasColumnName("last_greset_time");

                entity.Property(e => e.LastResetTime).HasColumnName("last_reset_time");

                entity.Property(e => e.Ldate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("LDate");

                entity.Property(e => e.Leadership).HasDefaultValueSql("((0))");

                entity.Property(e => e.LevelUpPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.MagicList).HasMaxLength(180);

                entity.Property(e => e.MapDir).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxBp).HasColumnName("MaxBP");

                entity.Property(e => e.Mdate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Money).HasDefaultValueSql("((0))");

                entity.Property(e => e.MuId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("mu_id");

                entity.Property(e => e.PkCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.PkLevel).HasDefaultValueSql("((3))");

                entity.Property(e => e.PkTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quest)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Resets).HasColumnName("resets");
            });

            modelBuilder.Entity<CharacterRealTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CharacterRealTime");

                entity.Property(e => e.AIndex).HasColumnName("aIndex");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Attacker)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DiscordEvent)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Killer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Party)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartyNumber).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Pklevel).HasColumnName("PKLevel");

                entity.Property(e => e.Serial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConnectionHistory>(entity =>
            {
                entity.ToTable("ConnectionHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Hwid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HWID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<DefaultClassType>(entity =>
            {
                entity.HasKey(e => e.Class);

                entity.ToTable("DefaultClassType");

                entity.Property(e => e.EffectList).HasMaxLength(208);

                entity.Property(e => e.Inventory).HasMaxLength(3776);

                entity.Property(e => e.Leadership).HasDefaultValueSql("((0))");

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");

                entity.Property(e => e.LevelUpPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.MagicList).HasMaxLength(180);

                entity.Property(e => e.Quest).HasMaxLength(50);
            });

            modelBuilder.Entity<EventEntryCount>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.Type });

                entity.ToTable("EventEntryCount");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventLeoTheHelper>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("EventLeoTheHelper");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventSantaClau>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtWarehouse>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Number });

                entity.ToTable("ExtWarehouse");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Items).HasMaxLength(3840);
            });

            modelBuilder.Entity<GameServerInfo>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .IsClustered(false);

                entity.ToTable("GameServerInfo");

                entity.Property(e => e.Number).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuideQuest>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("GuideQuest");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.QuestList)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Guild>(entity =>
            {
                entity.HasKey(e => e.GName);

                entity.ToTable("Guild");

                entity.Property(e => e.GName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("G_Name");

                entity.Property(e => e.GCount).HasColumnName("G_Count");

                entity.Property(e => e.GMark)
                    .HasMaxLength(32)
                    .HasColumnName("G_Mark");

                entity.Property(e => e.GMaster)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("G_Master");

                entity.Property(e => e.GNotice)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("G_Notice");

                entity.Property(e => e.GRival).HasColumnName("G_Rival");

                entity.Property(e => e.GScore)
                    .HasColumnName("G_Score")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GType).HasColumnName("G_Type");

                entity.Property(e => e.GUnion).HasColumnName("G_Union");

                entity.Property(e => e.MemberCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Number).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GuildMember>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("GuildMember");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GLevel).HasColumnName("G_Level");

                entity.Property(e => e.GName)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("G_Name");

                entity.Property(e => e.GStatus).HasColumnName("G_Status");

                entity.HasOne(d => d.GNameNavigation)
                    .WithMany(p => p.GuildMembers)
                    .HasForeignKey(d => d.GName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuildMember_Guild");
            });

            modelBuilder.Entity<HelperDatum>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasMaxLength(256)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MasterSkillTree>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("MasterSkillTree");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MasterSkill).HasMaxLength(180);
            });

            modelBuilder.Entity<MembCredit>(entity =>
            {
                entity.HasKey(e => e.MembId);

                entity.ToTable("MEMB_CREDITS");

                entity.Property(e => e.MembId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("memb___id");

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.Used).HasColumnName("used");
            });

            modelBuilder.Entity<MembInfo>(entity =>
            {
                entity.HasKey(e => e.MembGuid)
                    .HasName("PK_MEMB_INFO_1")
                    .IsClustered(false);

                entity.ToTable("MEMB_INFO");

                entity.Property(e => e.MembGuid).HasColumnName("memb_guid");

                entity.Property(e => e.AccountExpireDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Activated).HasColumnName("activated");

                entity.Property(e => e.ActivationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("activation_id");

                entity.Property(e => e.AddrDeta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("addr_deta");

                entity.Property(e => e.AddrInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("addr_info");

                entity.Property(e => e.ApplDays)
                    .HasColumnType("datetime")
                    .HasColumnName("appl_days");

                entity.Property(e => e.Auth2fa).HasColumnName("auth2fa");

                entity.Property(e => e.BlocCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("bloc_code")
                    .IsFixedLength(true);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Ctl1Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ctl1_code")
                    .IsFixedLength(true);

                entity.Property(e => e.Discord)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscordName)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Discord_Name");

                entity.Property(e => e.DmnCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dmn_country");

                entity.Property(e => e.FpasAnsw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fpas_answ");

                entity.Property(e => e.FpasQues)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fpas_ques");

                entity.Property(e => e.Hwid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hwid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("job__code")
                    .IsFixedLength(true);

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_login_ip");

                entity.Property(e => e.MailAddr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail_addr");

                entity.Property(e => e.MailChek)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("mail_chek")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true);

                entity.Property(e => e.MembId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("memb___id");

                entity.Property(e => e.MembName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("memb_name");

                entity.Property(e => e.MembPwd)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("memb__pwd");

                entity.Property(e => e.ModiDays)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_days");

                entity.Property(e => e.OutDays)
                    .HasColumnType("datetime")
                    .HasColumnName("out__days");

                entity.Property(e => e.PhonNumb)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phon_numb");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("post_code")
                    .IsFixedLength(true);

                entity.Property(e => e.SnoNumb)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("sno__numb")
                    .IsFixedLength(true);

                entity.Property(e => e.TelNumb)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tel__numb");

                entity.Property(e => e.TrueDays)
                    .HasColumnType("datetime")
                    .HasColumnName("true_days");
            });

            modelBuilder.Entity<MembStat>(entity =>
            {
                entity.HasKey(e => e.MembId);

                entity.ToTable("MEMB_STAT");

                entity.Property(e => e.MembId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("memb___id");

                entity.Property(e => e.ConnectTm)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ConnectTM");

                entity.Property(e => e.DisConnectTm)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DisConnectTM");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuDbid>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Mu_DBID");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESC");

                entity.Property(e => e.Version).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MuHelper>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("MuHelper");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasMaxLength(512);
            });

            modelBuilder.Entity<MultiWarehouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MultiWarehouse");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Items).HasMaxLength(7680);
            });

            modelBuilder.Entity<RankingBloodCastle>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingBloodCastle");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankingCastleSiege>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingCastleSiege");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankingChaosCastle>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingChaosCastle");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankingDevilSquare>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingDevilSquare");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankingDuel>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingDuel");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankingIllusionTemple>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("RankingIllusionTemple");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReconnectDatum>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.ServerCode });

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ReconnectOfflineDatum>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.ServerCode });

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("warehouse");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.DbVersion).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndUseDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Items).HasMaxLength(3840);

                entity.Property(e => e.Money).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pw)
                    .HasColumnName("pw")
                    .HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
