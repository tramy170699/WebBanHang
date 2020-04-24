namespace WebBanHang.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanLoai")]
    public partial class PhanLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanLoai()
        {
            LoaiSanPhams = new HashSet<LoaiSanPham>();
        }

        public int PhanLoaiID { get; set; }

        [StringLength(50)]
        public string TenPhanLoai { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
