using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.Entity;

public partial class ToyNjoyContext : DbContext
{
    public ToyNjoyContext()
    {
    }

    public ToyNjoyContext(DbContextOptions<ToyNjoyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<FriendGroup> FriendGroups { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<LibraryGroup> LibraryGroups { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsType> NewsTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductHardwareRequirement> ProductHardwareRequirements { get; set; }

    public virtual DbSet<ProductPhotoGallery> ProductPhotoGalleries { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ShoppingCar> ShoppingCars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ToyNJoy;User ID=sa;Password=sa;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_System");

            entity.ToTable("Administrator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sa_name");
            entity.Property(e => e.SaPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sa_password");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.ToTable("Friend");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FriendName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("friend_name");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Nickname)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.FriendNameNavigation).WithMany(p => p.FriendFriendNameNavigations)
                .HasForeignKey(d => d.FriendName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_Friend_name");

            entity.HasOne(d => d.Group).WithMany(p => p.Friends)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Friend_group_id");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.FriendUserNameNavigations)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_username");
        });

        modelBuilder.Entity<FriendGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Friend_Group_User_name");

            entity.ToTable("Friend_Group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupName)
                .IsUnicode(false)
                .HasColumnName("group_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.FriendGroups)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_Group_user_name");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_library");

            entity.ToTable("Library");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.JoinTime)
                .HasColumnType("datetime")
                .HasColumnName("join_time");
            entity.Property(e => e.LastTime)
                .HasColumnType("datetime")
                .HasColumnName("last_time");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.TotalHours).HasColumnName("total_hours");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Group).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Library_Library_Group_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_library_product_id");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_user_name");
        });

        modelBuilder.Entity<LibraryGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_varchar(32)");

            entity.ToTable("Library_Group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupName)
                .IsUnicode(false)
                .HasColumnName("group_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.LibraryGroups)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_Group_user_name");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Commend).HasColumnName("commend");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.PageView).HasColumnName("page_view");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Text)
                .IsUnicode(false)
                .HasColumnName("text");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Trample).HasColumnName("trample");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");

            entity.HasOne(d => d.Type).WithMany(p => p.News)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_News_Type_id");
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.ToTable("News_Type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Games");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgeGrading).HasColumnName("age_grading");
            entity.Property(e => e.Browse).HasColumnName("browse");
            entity.Property(e => e.Developers)
                .IsUnicode(false)
                .HasColumnName("developers");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Intro)
                .IsUnicode(false)
                .HasColumnName("intro");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Publisher)
                .IsUnicode(false)
                .HasColumnName("publisher");
            entity.Property(e => e.Purchases).HasColumnName("purchases");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Type_id");
        });

        modelBuilder.Entity<ProductHardwareRequirement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Game_hardware_requirements");

            entity.ToTable("Product_hardware_requirements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpu)
                .IsUnicode(false)
                .HasColumnName("CPU");
            entity.Property(e => e.Cpu1)
                .IsUnicode(false)
                .HasColumnName("CPU_");
            entity.Property(e => e.DirectX).IsUnicode(false);
            entity.Property(e => e.DirectX1)
                .IsUnicode(false)
                .HasColumnName("DirectX_");
            entity.Property(e => e.Gpu)
                .IsUnicode(false)
                .HasColumnName("GPU");
            entity.Property(e => e.Gpu1)
                .IsUnicode(false)
                .HasColumnName("GPU_");
            entity.Property(e => e.Os)
                .IsUnicode(false)
                .HasColumnName("OS");
            entity.Property(e => e.Os1)
                .IsUnicode(false)
                .HasColumnName("OS_");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.Ram)
                .IsUnicode(false)
                .HasColumnName("RAM");
            entity.Property(e => e.Ram1)
                .IsUnicode(false)
                .HasColumnName("RAM_");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductHardwareRequirements)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_hardware_requirements_Product_id");
        });

        modelBuilder.Entity<ProductPhotoGallery>(entity =>
        {
            entity.ToTable("Product_Photo_Gallery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.JoinDate)
                .HasColumnType("datetime")
                .HasColumnName("join_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPhotoGalleries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Photo_Gallery_Product_ID");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("Product_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<ShoppingCar>(entity =>
        {
            entity.ToTable("Shopping_Car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCars)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shopping_Car_product_name");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.ShoppingCars)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shopping_Car_user_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nickname)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RegisterTime)
                .HasColumnType("date")
                .HasColumnName("register_time");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.VirtualImage)
                .IsUnicode(false)
                .HasColumnName("virtual_image");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("User_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Gender)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Idcard)
                .IsUnicode(false)
                .HasColumnName("IDCard");
            entity.Property(e => e.Phone)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Signature)
                .IsUnicode(false)
                .HasColumnName("signature");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.WrapperImage)
                .IsUnicode(false)
                .HasColumnName("wrapper_image");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_info_User_name");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("Wish_List");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JoinDate)
                .HasColumnType("date")
                .HasColumnName("join_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SerialNamber).HasColumnName("serial_namber");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Product).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wish_List_product_id");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wish_List_user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
