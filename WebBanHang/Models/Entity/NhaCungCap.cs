namespace WebBanHang.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int NhaCungCapID { get; set; }

        [StringLength(500)]
        public string TenNhaCungCap { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(300)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
