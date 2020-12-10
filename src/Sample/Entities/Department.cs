using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using VanishFlare.DataAnnotations;

namespace Sample.Entities
{
    /// <summary>
    /// 部署テーブルエンティティを提供します。
    /// </summary>
    [Table("Department")]
    public partial class Department
    {
        /// <summary>
        /// Idを取得または設定します。
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string Id { get; set; }

        /// <summary>
        /// Nameを取得または設定します。
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string Name { get; set; }

        /// <summary>
        /// Idに所属するユーザー情報を取得または設定します。
        /// </summary>
        public List<UserInfo> UserInfos { get; set; }
    }
}
