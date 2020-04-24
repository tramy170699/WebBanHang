namespace WebBanHang.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            DonDatHangs = new HashSet<DonDatHang>();
            DonDatHangs1 = new HashSet<DonDatHang>();
        }

        public int UserID { get; set; }

        public DateTime? NgayLap { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string GhiChu { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        public int? LoaiUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs1 { get; set; }
    }
}
