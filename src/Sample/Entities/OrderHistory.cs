using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using VanishFlare.DataAnnotations;

namespace Sample.Entities
{
    /// <summary>
    /// ロールエンティティを提供します。
    /// </summary>
    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        /// <summary>
        /// Idを取得または設定します。
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string Id { get; set; }

        /// <summary>
        /// UserIdを取得または設定します。
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string UserId { get; set; }

        /// <summary>
        /// Nameを取得または設定します。
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string OrderName { get; set; }

        /// <summary>
        /// /// <summary>
        /// UserIdに所属するユーザー情報を取得または設定します。
        /// </summary>
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }
    }
}
