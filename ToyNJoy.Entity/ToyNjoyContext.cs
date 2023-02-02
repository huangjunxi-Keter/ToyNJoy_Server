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

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

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

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.SaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("账号")
                .HasColumnName("sa_name");
            entity.Property(e => e.SaPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("密码")
                .HasColumnName("sa_password");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.ToTable("Friend");

            entity.Property(e => e.Id)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.FriendName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("好友 用户名")
                .HasColumnName("friend_name");
            entity.Property(e => e.GroupId)
                .HasComment("分组id")
                .HasColumnName("group_id");
            entity.Property(e => e.Nickname)
                .IsUnicode(false)
                .HasComment("好友 备注")
                .HasColumnName("nickname");
            entity.Property(e => e.State)
                .HasComment("状态")
                .HasColumnName("state");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
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

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.GroupName)
                .IsUnicode(false)
                .HasComment("分组名")
                .HasColumnName("group_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
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

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.GroupId)
                .HasComment("分组主键")
                .HasColumnName("group_id");
            entity.Property(e => e.JoinTime)
                .HasComment("添加时间")
                .HasColumnType("datetime")
                .HasColumnName("join_time");
            entity.Property(e => e.LastTime)
                .HasComment("最后操作时间")
                .HasColumnType("datetime")
                .HasColumnName("last_time");
            entity.Property(e => e.ProductId)
                .HasComment("商品主键")
                .HasColumnName("product_id");
            entity.Property(e => e.TotalHours)
                .HasComment("总操作时间（运行时长）")
                .HasColumnName("total_hours");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("user_name");

            entity.HasOne(d => d.Group).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Library_Library_Group_id");

            //entity.HasOne(d => d.Product).WithMany(p => p.Libraries)
            //    .HasForeignKey(d => d.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_library_product_id");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_user_name");
        });

        modelBuilder.Entity<LibraryGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_varchar(32)");

            entity.ToTable("Library_Group");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.GroupName)
                .IsUnicode(false)
                .HasComment("分组名")
                .HasColumnName("group_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("user_name");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.LibraryGroups)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_Group_user_name");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.Commend)
                .HasComment("点赞")
                .HasColumnName("commend");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasComment("封面")
                .HasColumnName("image");
            entity.Property(e => e.PageView)
                .HasComment("浏览量")
                .HasColumnName("page_view");
            entity.Property(e => e.ProductId)
                .HasComment("相关产品id")
                .HasColumnName("product_id");
            entity.Property(e => e.Text)
                .IsUnicode(false)
                .HasComment("内容")
                .HasColumnName("text");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasComment("标题")
                .HasColumnName("title");
            entity.Property(e => e.Trample)
                .HasComment("点踩")
                .HasColumnName("trample");
            entity.Property(e => e.TypeId)
                .HasComment("分类")
                .HasColumnName("type_id");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
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

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.TypeName)
                .IsUnicode(false)
                .HasComment("类型名")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F7AE28124");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.State)
                .HasComment("状态 0未支付 1支付")
                .HasColumnName("state");
            entity.Property(e => e.TotalAmount)
                .HasComment("总价")
                .HasColumnType("float")
                .HasColumnName("total_amount");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userOrder");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order_It__3213E83F3899028B");

            entity.ToTable("Order_Item");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("订单id")
                .HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasComment("价格（根据商品价格和折扣计算）")
                .HasColumnType("float")
                .HasColumnName("price");
            entity.Property(e => e.ProductId)
                .HasComment("商品id")
                .HasColumnName("product_id");

            //entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
            //    .HasForeignKey(d => d.OrderId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("inOrder");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itemProduct");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Games");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.AgeGrading)
                .HasComment("年龄分级")
                .HasColumnName("age_grading");
            entity.Property(e => e.Browse)
                .HasComment("浏览量")
                .HasColumnName("browse");
            entity.Property(e => e.Developers)
                .IsUnicode(false)
                .HasComment("开发商")
                .HasColumnName("developers");
            entity.Property(e => e.Discount)
                .HasComment("折扣")
                .HasColumnName("discount");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasComment("商品封面")
                .HasColumnName("image");
            entity.Property(e => e.Intro)
                .IsUnicode(false)
                .HasComment("介绍")
                .HasColumnName("intro");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasComment("商品名")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasComment("价格")
                .HasColumnType("float")
                .HasColumnName("price");
            entity.Property(e => e.Publisher)
                .IsUnicode(false)
                .HasComment("发行商")
                .HasColumnName("publisher");
            entity.Property(e => e.Purchases)
                .HasComment("销量")
                .HasColumnName("purchases");
            entity.Property(e => e.ReleaseDate)
                .HasComment("发行时间")
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.TypeId)
                .HasComment("类型id")
                .HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Type_id");
        });

        modelBuilder.Entity<ProductHardwareRequirement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Game_hardware_requirements");

            entity.ToTable("Product_hardware_requirements");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.Cpu)
                .IsUnicode(false)
                .HasComment("标准配置 处理器")
                .HasColumnName("CPU");
            entity.Property(e => e.Cpu1)
                .IsUnicode(false)
                .HasComment("推荐配置 处理器")
                .HasColumnName("CPU_");
            entity.Property(e => e.DirectX)
                .IsUnicode(false)
                .HasComment("标准配置 DX版本");
            entity.Property(e => e.DirectX1)
                .IsUnicode(false)
                .HasComment("推荐配置 DX版本")
                .HasColumnName("DirectX_");
            entity.Property(e => e.Gpu)
                .IsUnicode(false)
                .HasComment("标准配置 显卡")
                .HasColumnName("GPU");
            entity.Property(e => e.Gpu1)
                .IsUnicode(false)
                .HasComment("推荐配置 显卡")
                .HasColumnName("GPU_");
            entity.Property(e => e.Os)
                .IsUnicode(false)
                .HasComment("标准配置 系统")
                .HasColumnName("OS");
            entity.Property(e => e.Os1)
                .IsUnicode(false)
                .HasComment("推荐配置 系统")
                .HasColumnName("OS_");
            entity.Property(e => e.ProductId)
                .HasComment("产品id")
                .HasColumnName("Product_id");
            entity.Property(e => e.Ram)
                .IsUnicode(false)
                .HasComment("标准配置 运行内存")
                .HasColumnName("RAM");
            entity.Property(e => e.Ram1)
                .IsUnicode(false)
                .HasComment("推荐配置 运行内存")
                .HasColumnName("RAM_");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductHardwareRequirements)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_hardware_requirements_Product_id");
        });

        modelBuilder.Entity<ProductPhotoGallery>(entity =>
        {
            entity.ToTable("Product_Photo_Gallery");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasComment("图片名称")
                .HasColumnName("image");
            entity.Property(e => e.JoinDate)
                .HasComment("添加日期")
                .HasColumnType("datetime")
                .HasColumnName("join_date");
            entity.Property(e => e.ProductId)
                .HasComment("商品id")
                .HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPhotoGalleries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Photo_Gallery_Product_ID");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("Product_type");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.TypeName)
                .IsUnicode(false)
                .HasComment("类型名称")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<ShoppingCar>(entity =>
        {
            entity.ToTable("Shopping_Car");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.ProductId)
                .HasComment("商品id")
                .HasColumnName("product_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("user_name");

            //entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCars)
            //    .HasForeignKey(d => d.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Shopping_Car_product_name");

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
                .HasComment("主键（用户名）")
                .HasColumnName("username");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasComment("邮箱")
                .HasColumnName("email");
            entity.Property(e => e.Lv).HasComment("等级");
            entity.Property(e => e.Nickname)
                .IsUnicode(false)
                .HasComment("昵称")
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasComment("密码")
                .HasColumnName("password");
            entity.Property(e => e.RegisterTime)
                .HasComment("注册时间")
                .HasColumnType("date")
                .HasColumnName("register_time");
            entity.Property(e => e.State)
                .HasComment("状态")
                .HasColumnName("state");
            entity.Property(e => e.VirtualImage)
                .IsUnicode(false)
                .HasComment("头像")
                .HasColumnName("virtual_image");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("User_info");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasComment("地址")
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Gender)
                .IsUnicode(false)
                .HasComment("性别")
                .HasColumnName("gender");
            entity.Property(e => e.Idcard)
                .IsUnicode(false)
                .HasComment("身份证")
                .HasColumnName("IDCard");
            entity.Property(e => e.Phone)
                .IsUnicode(false)
                .HasComment("手机号")
                .HasColumnName("phone");
            entity.Property(e => e.Signature)
                .IsUnicode(false)
                .HasComment("签名")
                .HasColumnName("signature");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("user_name");
            entity.Property(e => e.WrapperImage)
                .IsUnicode(false)
                .HasComment("个人空间背景")
                .HasColumnName("wrapper_image");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_info_User_name");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("Wish_List");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.JoinDate)
                .HasComment("添加时间")
                .HasColumnType("date")
                .HasColumnName("join_date");
            entity.Property(e => e.ProductId)
                .HasComment("商品id")
                .HasColumnName("product_id");
            entity.Property(e => e.SerialNamber)
                .HasComment("排序顺序")
                .HasColumnName("serial_namber");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("用户名")
                .HasColumnName("user_name");

            //entity.HasOne(d => d.Product).WithMany(p => p.WishLists)
            //    .HasForeignKey(d => d.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Wish_List_product_id");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wish_List_user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
