using Microsoft.EntityFrameworkCore;
using NetCore.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Data
{
    // 2. FluentAPI

    // 상속 
    // CodeFirstDbContext : 자식 클래스
    // DbContext : 부모 클래스
  public  class CodeFirstDbContext :DbContext { 
    // 생성자 상속
    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options) { 
    }

    public DbSet<User> Users { get; set; }

    // 메서드 상속, 부모클래스에서 OnModelCreating 메서드가
    // Virtual 키워드로 지정이 되어있어야만 상속 받을 수 있다.
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      //4가지 작업
      // DB 테이블 이름 변경
      modelBuilder.Entity<User>().ToTable(name: "User");

      // 복합Key
      modelBuilder.Entity<UserRolesByUser>().HasKey(c => new { c.UserId, c.RoleId });

      // 기본값 지정
      modelBuilder.Entity<User>(e => { 
        e.Property(c => c.IsMembershipWithdrawn).HasDefaultValue(value: false);
      });

      // 인덱스 지정
      modelBuilder.Entity<User>().HasIndex(c => new { c.UserEmail });
    }
  }
}
