using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using VanishFlare.DataAnnotations;

namespace Sample.Entities
{
    /// <summary>
    /// ユーザーテーブルエンティティを提供します。
    /// </summary>
    [Table("UserInfo")]
    public partial class UserInfo
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
        /// Telを取得または設定します。
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string Tel { get; set; }

        /// <summary>
        /// DepartmentIdを取得または設定します。
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string DepartmentId { get; set; }

        [Required]
        [Range(0, 1)]
        [MapFiledName]
        public int IsValid { get; set; }

        /// <summary>
        /// 所属している部署を取得または設定します。
        /// </summary>
        [MapFiledName]
        public virtual Department Department { get; set; }

        /// <summary>
        /// 注文履歴を取得または設定します。
        /// </summary>
        [MapFiledName]
        public List<OrderHistory> OrderHistories { get; set; }
    }
}
