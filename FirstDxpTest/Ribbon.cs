using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;

namespace FirstDxpTest
{
    public partial class Ribbon : DevExpress.XtraEditors.XtraForm
    {
        public Ribbon()
        {
            InitializeComponent();
            //皮肤组件的引用
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
        }
    }
}