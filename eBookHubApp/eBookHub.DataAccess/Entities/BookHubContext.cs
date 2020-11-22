using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eBookHub.DataAccess.Entities
{
    public partial class BookHubContext : DbContext
    {
        public BookHubContext()
        {
        }

        public BookHubContext(DbContextOptions<BookHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Discussion> Discussion { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK_LoginID");

                entity.ToTable("Account", "BookHub");

                entity.HasIndex(e => e.DisplayName)
                    .HasName("UQ__Account__4E3E687D83E05B58")
                    .IsUnique();

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("UQ__Account__49A14740120AD85D")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Account__C9F284568013B78B")
                    .IsUnique();

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Administrator).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpcomingBooks)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK_BookID");

                entity.ToTable("Books", "BookHub");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookVersion).HasDefaultValueSql("((1))");

                entity.Property(e => e.PublishDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.TextOfBook)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksGenreId");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksLoginId");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "BookHub");

                entity.Property(e => e.CommentDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CommentString)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Discussion)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.DiscussionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentDiscussionId");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentLoginId");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.ToTable("Discussion", "BookHub");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Discussion)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscussionBookId");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "BookHub");

                entity.HasIndex(e => e.GenreName)
                    .HasName("UQ__Genre__BBE1C339A8FE9D68")
                    .IsUnique();

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review", "BookHub");

                entity.Property(e => e.ReviewString)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewBookId");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewLoginId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
