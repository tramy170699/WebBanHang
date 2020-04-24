namespace WebBanHang.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ThuocTinhSanPhams = new HashSet<ThuocTinhSanPham>();
        }

        public int SanPhamID { get; set; }

        public int? LoaiSanPhamID { get; set; }

        public int? DonViTinhID { get; set; }

        [StringLength(50)]
        public string KyHieuSanPham { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(500)]
        public string AnhSanPham { get; set; }

        [StringLength(300)]
        public string MoTaNgan { get; set; }

        public string MoTa { get; set; }

        [StringLength(10)]
        public string ThuongHieu { get; set; }

        public bool? AnHienSanPham { get; set; }

        public double? GiaBan { get; set; }

        public DateTime? NgayDang { get; set; }

        public bool? LaSanPhamMoi { get; set; }

        public int? NhaCungCapID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuocTinhSanPham> ThuocTinhSanPhams { get; set; }
    }
}
