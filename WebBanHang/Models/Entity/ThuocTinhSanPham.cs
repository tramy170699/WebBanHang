namespace WebBanHang.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuocTinhSanPham")]
    public partial class ThuocTinhSanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThuocTinhSanPhamID { get; set; }

        public int? SanPhamID { get; set; }

        public int? ThuocTinhID { get; set; }

        public string NoiDungMoTa { get; set; }

        public string GhiChu { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual ThuocTinh ThuocTinh { get; set; }
    }
}
