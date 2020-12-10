using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using VanishFlare.DataAnnotations;

namespace Sample.Entities
{
    /// <summary>
    /// ���[���G���e�B�e�B��񋟂��܂��B
    /// </summary>
    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        /// <summary>
        /// Id���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string Id { get; set; }

        /// <summary>
        /// UserId���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string UserId { get; set; }

        /// <summary>
        /// Name���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string OrderName { get; set; }

        /// <summary>
        /// /// <summary>
        /// UserId�ɏ������郆�[�U�[�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }
    }
}
