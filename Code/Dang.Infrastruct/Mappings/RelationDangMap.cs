using Dang.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dang.Infrastruct.Mappings
{
    public class RelationDangMap:IEntityTypeConfiguration<RelationDang>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<RelationDang> builder)
        {
            //映射表
            builder.ToTable("relation_dang");

            // keys
            builder.HasKey(t => t.Id);

            //实体属性Map
            //
            builder.Property(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            //角色ID
            builder.Property(t => t.Name)
                .HasColumnName("name")
                .IsRequired();
            //关系类型
            builder.Property(t => t.RelationType)
                .HasColumnName("relation_type")
                .IsRequired();
            //当评价
            builder.Property(t => t.EstimateDang)
                .HasColumnName("estimate_dang")
                .HasMaxLength(200)
                .IsRequired();
            //其他评价
            builder.Property(t => t.EstimateOther)
                .HasColumnName("estimate_other")
                .HasMaxLength(400)
                .IsRequired();
            //修改时间
            builder.Property(t => t.UpdateTime)
                .HasColumnName("update_time")
                .HasMaxLength(400)
                .IsRequired();

            //备注
            builder.Property(t => t.Remark)
                .HasColumnName("remark")
                .HasMaxLength(80)
                .IsRequired();

        }
    }
}
