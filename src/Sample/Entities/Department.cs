using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using VanishFlare.DataAnnotations;

namespace Sample.Entities
{
    /// <summary>
    /// �����e�[�u���G���e�B�e�B��񋟂��܂��B
    /// </summary>
    [Table("Department")]
    public partial class Department
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
        /// Id�ɏ������郆�[�U�[�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public List<UserInfo> UserInfos { get; set; }
    }
}
