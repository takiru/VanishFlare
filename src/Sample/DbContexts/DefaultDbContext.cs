using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DbContexts
{
    /// <summary>
    /// mssqlのDBコンテキストを提供します。
    /// </summary>
    class DefaultDbContext : DbContext
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public DefaultDbContext() : base("mssql")
        {
            // 実行時の自動マイグレーションを無効にする
            Database.SetInitializer<DefaultDbContext>(null);
        }

        /// <summary>
        /// ユーザーテーブル操作を行います。
        /// </summary>
        public DbSet<UserInfo> UserInfos { get; set; }

        /// <summary>
        /// 部署テーブル操作を行います。
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// ロールテーブル操作を行います。
        /// </summary>
        public DbSet<OrderHistory> OrderHistories { get; set; }

        /// <summary>
        /// テーブルの関係性を構築します。
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder オブジェクト。</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // UserInfo.DepartmentIdを、Department.Idの外部キーとする
            modelBuilder.Entity<Department>()
                .HasMany(e => e.UserInfos)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            // UserInfo.RoleIdを、UserRole.Idの外部キーとする
            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.OrderHistories)
                .WithRequired(e => e.UserInfo)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
