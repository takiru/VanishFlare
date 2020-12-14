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
    /// ���[�U�[�e�[�u���G���e�B�e�B��񋟂��܂��B
    /// </summary>
    [Table("UserInfo")]
    public partial class UserInfo
    {
        /// <summary>
        /// Id���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [StringLength(50)]
        [MapFiledName]
        public string Id { get; set; }

        /// <summary>
        /// Name���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string Name { get; set; }

        /// <summary>
        /// Tel���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Required]
        [StringLength(50)]
        [MapFiledName]
        public string Tel { get; set; }

        /// <summary>
        /// DepartmentId���擾�܂��͐ݒ肵�܂��B
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
        /// �������Ă��镔�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [MapFiledName]
        public virtual Department Department { get; set; }

        /// <summary>
        /// �����������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [MapFiledName]
        public List<OrderHistory> OrderHistories { get; set; }
    }
}
